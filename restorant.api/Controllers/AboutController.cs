using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.AboutDto;
using restorant.entity;

namespace restorant.api.Mapping
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private IMapper _mapper;

        public AboutController(IAboutService aboutService,IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            _aboutService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto aboutDto)
        {
            var values = _mapper.Map<About>(aboutDto);
            _aboutService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }        
    }
}