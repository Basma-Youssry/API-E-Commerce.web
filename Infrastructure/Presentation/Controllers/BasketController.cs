using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransfareObjects.BasketModuleDTos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController(IServiceManager _serviceManager) : ControllerBase
    {
        //Get Basket
        [HttpGet] //GET BaseUrl/api/Basket
        public async Task<ActionResult<BasketDTo>> GetBasket(string key)
        {
            var Basket = await _serviceManager.BasketService.GetBasketAsync(key);
            return Ok(Basket);
        }

        //Create Or Update Basket
        [HttpPost]
        public async Task<ActionResult<BasketDTo>> CreateOrUpdateBasket(BasketDTo basket)
        {
            var Basket = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);

            return Ok(Basket);
        }

        //Delete Basket
        [HttpDelete("{key}")] //DELETE BaseUrl/api/Basket/hdhhdjhjdh(Guid)
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            var Result = await _serviceManager.BasketService.DeleteBasketAsync(key);
            return Ok(Result);
        }


    }
}
