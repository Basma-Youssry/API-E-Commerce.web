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
        Task<OrderToReturnDTo> CreateOrder(OrderDTo orderDTo, string Email);
    }

}
