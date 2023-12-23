using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Markup;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restorant.business.Abstract;
using restorant.data;
using restorant.dto.ProductDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.GetAll();
            return Ok(values);
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.ProductCount());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto productDto)
        {
            _productService.Add(new Product()
            {
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price,
                Name = productDto.Name,
                Status = productDto.Status,
                CategoryId = productDto.CategoryId
            });
            return Ok("Ürün Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);
            _productService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto productDto)
        {
            _productService.Update(new Product()
            {
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price,
                Name = productDto.Name,
                Status = productDto.Status,
                Id = productDto.Id,
                CategoryId = productDto.CategoryId
            });
            return Ok("Ürün Bilgisi Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.GetById(id);
            return Ok(value);
        }
        [HttpGet("GetProductsWithCategory")]
        public IActionResult GetProductsWithCategory()
        {

            var context = new RestorantContext();
            var values = context.Products.Include(product => product.Category).Select(y=> new GetProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = (double)y.Price,
                Id = y.Id,
                Name = y.Name,
                Status = y.Status,
                CategoryName = y.Category.Name

            }).ToList();
            return Ok(values);
        
        }         
    }
}