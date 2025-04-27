using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
using Shared.DataTransfareObjects;

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

        public async Task<IEnumerable<ProductDTo>> GetAllProductsAsync()
        {
            var Specifications = new ProductWithBrandAndTypeSpecifications();
            var Products = await _uitOfWork.GetRepository<Product, int>().GetAllAsync(Specifications);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTo>>(Products);
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

            var ProductDto = _mapper.Map<Product, ProductDTo>(Product);

            return ProductDto;
        }
    }
}
