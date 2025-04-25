using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
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
            var Products = await _uitOfWork.GetRepository<Product, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTo>>(Products);
        }

        public async Task<IEnumerable<TypeDTo>> GetAllTypesAsync()
        {
            var Types = await _uitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesDTo = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDTo>>(Types);
            return TypesDTo;
        }

        public async Task<ProductDTo> GetProductById(int Id)
        {
            var Product = await _uitOfWork.GetRepository<Product, int>().GetByIdAsync(Id);

            return _mapper.Map<Product, ProductDTo>(Product);
        }
    }
}
