using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects.OrderDTOs;

namespace ServiceAbstraction
{
    public interface IOrderService
    {
        //Create Order
        //Creating order will take Basket Id, shippping Address , Delivery method Id, Customet Email
        //And Return Order Details
        //(Id, User Email, OrderDate, Items(Product Name - Picture Url - Price - Quantity)
        //,Address, Delivery Method Name, Order Status Value, Sub Total, Total Price)
        Task<OrderToReturnDTo> CreateOrderAsync(OrderDTo orderDTo, string Email);

        //Get Delivery Methods
        Task<IEnumerable<DeliveryMethodDTo>> GetDeliveryMethodsAsync();

        //Get All Orders
        Task<IEnumerable<OrderToReturnDTo>> GetAllOrdersAsync(string Email);

        //Get Order By Id
        Task<OrderToReturnDTo> GetOrderByIdAsync(Guid id);
    }

}
