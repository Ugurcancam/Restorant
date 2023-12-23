using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.CategoryDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.GetAll();
            return Ok(values);
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.CategoryCount());
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.ActiveCategoryCount());
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.PassiveCategoryCount());
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto categoryDto)
        {
            var values = _mapper.Map<Category>(categoryDto);
            _categoryService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.GetById(id);
            _categoryService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var values = _mapper.Map<Category>(categoryDto);
            _categoryService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.GetById(id);
            return Ok(value);
        }         
    }
}