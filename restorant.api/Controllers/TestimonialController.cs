using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.TestimonialDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService,IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            var values = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.GetById(id);
            _testimonialService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto testimonialDto)
        {
            var values = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.GetById(id);
            return Ok(value);
        }         
    }
}