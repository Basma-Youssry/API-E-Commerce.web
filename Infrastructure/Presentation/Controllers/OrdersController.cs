using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects.OrderDTOs;

namespace Presentation.Controllers
{
    [Authorize]
    public class OrdersController(IServiceManager _serviceManager) : APIBaseController
    {
        //Create Order
        
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTo>> CreateOrderAsync(OrderDTo orderDTo)
        {
           
            var Order = await _serviceManager.OrderService.CreateOrderAsync(orderDTo, GetEmailFromToken());

            return Ok(Order);
        }

        //Get Delivery Methods
        [AllowAnonymous]
        [HttpGet("DeliveryMethods")] // Get BaseUrl/api/Orders/DeliveryMethods
        public async Task<ActionResult<IEnumerable<DeliveryMethodDTo>>> GetDeliveryMethods()
        {
            var DeliveryMethods = await _serviceManager.OrderService.GetDeliveryMethodsAsync();
            return Ok(DeliveryMethods);
        }

        //Get All Order By Email

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderToReturnDTo>>> GetAllOrders()
        {
            var Order = await _serviceManager.OrderService.GetAllOrdersAsync(GetEmailFromToken());
            return Ok(Order);
        }

        //Get Order By Id
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderToReturnDTo>> GetOrderById(Guid id)
        {
            var Order = await _serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(Order);
        }
    }
}
