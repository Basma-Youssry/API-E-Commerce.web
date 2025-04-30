using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects.BasketModuleDTos;

namespace ServiceAbstraction
{
    public interface IBasketService
    {
        Task<BasketDTo> GetBasketAsync(string key);
        Task<BasketDTo> CreateOrUpdateBasketAsync(BasketDTo basket);
        Task<bool> DeleteBasketAsync(string key);
    }
}
