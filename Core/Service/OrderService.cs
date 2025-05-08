using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.BasketModule;
using DomainLayer.Models.OrderModule;
using DomainLayer.Models.ProductModule;
using ServiceAbstraction;
using Shared.DataTransfareObjects.IdentityDTO_s;
using Shared.DataTransfareObjects.OrderDTOs;

namespace Service
{
    public class OrderService(IUnitOfWork _unitOfWork, IMapper _mapper, IBasketRepository _basketRepository) : IOrderService
    {
        public async Task<OrderToReturnDTo> CreateOrder(OrderDTo orderDTo, string Email)
        {
            //Map AddressDTO To Order Address.
            var OrderAddress = _mapper.Map<AddressDTo, OrderAddress>(orderDTo.Address);

            //Get Basket.
            var Basket = await _basketRepository.GetBasketAsync(orderDTo.BasketId)
               ?? throw new BasketNotFoundException(orderDTo.BasketId);

            //Create OrderItem List.
            List<OrderItem> OrderItems = [];
            var ProductRepo = _unitOfWork.GetRepository<Product, int>();

            foreach (var item in Basket.Items)
            {
                var Product = await ProductRepo.GetByIdAsync(item.Id)
                    ?? throw new ProductNotFoundException(item.Id);

                OrderItem orderItem = CreateOrderItem(item, Product);

                OrderItems.Add(orderItem);
            }


            //Get Delivery Method.
            var DeliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderDTo.DeliveryMethodId)
                ?? throw new DeliveryMethodNotFoundException(orderDTo.DeliveryMethodId);

            //Calculate Sub Total.

            var SubTotal = OrderItems.Sum(I => I.Quantity * I.Price);

            var Order = new Order(Email, OrderAddress, DeliveryMethod, OrderItems, SubTotal);

            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(Order);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Order, OrderToReturnDTo>(Order);
        }

        private static OrderItem CreateOrderItem(BasketItem item, Product Product)
        {
            return new OrderItem()
            {
                Product = new ProductItemOrdered() { ProductId = Product.Id, PictureUrl = Product.PictureUrl, ProductName = Product.Name },
                Price = Product.Price,
                Quantity = item.Quantity
            };
        }
    }
}
