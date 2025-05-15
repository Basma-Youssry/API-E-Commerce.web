using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTransfareObjects.ProductModuleDTos;

namespace Presentation.Controllers
{
   //BaseUrl/api/Products
    public class ProductsController(IServiceManager _serviceManager) : APIBaseController
    {

        //GetAllProducts
        //Get BaseUrl/api/Products


        //[Authorize(Roles = "Admin")]
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDTo>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
        {
            var Products = await _serviceManager.ProductService.GetAllProductsAsync(queryParams);

            return Ok(Products);
        }

        //GetProductById
        ////Get BaseUrl/api/Products/10
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTo>> GetProduct(int id)
        {
            var Product = await _serviceManager.ProductService.GetProductById(id);

            return Ok(Product);
        }

        //GetAllTypes
        //Get BaseUrl/api/Products/types
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDTo>>> GetTypes()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();

            return Ok(Types);
        }

        //GetAllBrands
        //Get BaseUrl/api/Products/brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDTo>>> GetBrands()
        {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

    }
}
