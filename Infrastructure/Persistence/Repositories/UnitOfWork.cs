using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //Get Type Name. (Name of model)
            var typeName = typeof(TEntity).Name;
            //Dic<string, Object> => string key [Name of type] -- Object (Object from Generic Reprosatory).

            //if (_repositories.ContainsKey(typeName))
            //    return (IGenericRepository<TEntity, TKey>)_repositories[typeName];
            //Or(Another syntax)
            if (_repositories.TryGetValue(typeName, out object? vlaue))
                return (IGenericRepository<TEntity, TKey>)vlaue;

            else
            {
                //Create Object(Repository)
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);
                //Store Object in Dic
                _repositories["typeName"] = Repo;
                //Return Object
                return Repo;

            }
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
       
    }
}
