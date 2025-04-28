using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.DataTransfareObjects;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //Get All Products
        Task<IEnumerable<ProductDTo>> GetAllProductsAsync(ProductQueryParams queryParams);

        //Get Product by Id
        Task<ProductDTo> GetProductById(int id);
        //Get All Types
        Task<IEnumerable<TypeDTo>> GetAllTypesAsync();
        //Get All Brands
        Task<IEnumerable<BrandDTo>> GetAllBrandsAsync();
    }
}
