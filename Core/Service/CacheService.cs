using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using ServiceAbstraction;

namespace Service
{
    class CacheService(ICacheRepository cacheRepository) : ICacheService
    {
        
       public async Task<string?> GetAsync(string cacheKey) => await cacheRepository.GetAsync(cacheKey);
        

        public async Task SetAsync(string cacheKey, object cacheValue, TimeSpan timeToLive)
        {
            var value = JsonSerializer.Serialize(cacheValue);
            await cacheRepository.SetAsync(cacheKey, value, timeToLive);
        }
    }
}
