using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransfareObjects;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //Get All Products
        Task<IEnumerable<ProductDTo>> GetAllProductsAsync { get; set; }

        //Get Product by Id
        Task<ProductDTo> GetProductById { get; set; }
        //Get All Types
        Task<IEnumerable<TypeDTo>> GetAllTypesAsync { get; set; }
        //Get All Brands
        Task<IEnumerable<BrandDTo>> GetAllBrandsAsync { get; set; }
    }
}
