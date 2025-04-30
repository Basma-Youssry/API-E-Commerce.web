using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.ProductModule;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DataTransfareObjects.ProductModuleDTos;

namespace Service
{
    public class ProductService(IUnitOfWork _uitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDTo>> GetAllBrandsAsync()
        {
            var Repo = _uitOfWork.GetRepository<ProductBrand, int>();
            var Brands = await Repo.GetAllAsync();
            var BrandsDTo = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDTo>>(Brands);

            return BrandsDTo;
        }

        public async Task<PaginatedResult<ProductDTo>> GetAllProductsAsync(ProductQueryParams queryParams)
        {
            var Repo =  _uitOfWork.GetRepository<Product, int>();
            var Specifications = new ProductWithBrandAndTypeSpecifications(queryParams);
            var AllProducts = await Repo.GetAllAsync(Specifications);
            var Data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTo>>(AllProducts);
            var ProductCount = AllProducts.Count();
            var CountSpec = new ProductCountSpecifications(queryParams);
            var TotalCount = await Repo.CountAsync(CountSpec);
            return new PaginatedResult<ProductDTo>(queryParams.PageIndex, ProductCount, TotalCount, Data);
        }

        public async Task<IEnumerable<TypeDTo>> GetAllTypesAsync()
        {
           
            var Types = await _uitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesDTo = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTo>>(Types);
            return TypesDTo;
        }

        public async Task<ProductDTo> GetProductById(int id)
        {
            var Specifications = new ProductWithBrandAndTypeSpecifications(id);

            var Product = await _uitOfWork.GetRepository<Product, int>().GetByIdAsync(Specifications);
            if(Product is null)
            {
                throw new ProductNotFoundException(id);
            }
            var ProductDto = _mapper.Map<Product, ProductDTo>(Product);

            return ProductDto;
        }
    }
}
