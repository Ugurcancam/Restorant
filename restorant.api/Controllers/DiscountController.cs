using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.DiscountDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private IMapper _mapper;

        public DiscountController(IDiscountService discountService,IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto discountDto)
        {
            var values = _mapper.Map<Discount>(discountDto);
            _discountService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.GetById(id);
            _discountService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto discountDto)
        {
            var values = _mapper.Map<Discount>(discountDto);
            _discountService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.GetById(id);
            return Ok(value);
        }         
    }
}