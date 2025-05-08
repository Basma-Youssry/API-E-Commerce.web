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
    public class OrdersController(IServiceManager _serviceManager) : APIBaseController
    {
        //Create Order
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDTo>> CreateOrder(OrderDTo orderDTo)
        {
           
            var Order = await _serviceManager.OrderService.CreateOrder(orderDTo, GetEmailFromToken());

            return Ok(Order);
        }
    }
}
