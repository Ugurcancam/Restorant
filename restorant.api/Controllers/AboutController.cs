using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;

namespace restorant.api.Mapping
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.GetAll();
            return Ok(values);
        }
        // [HttpPost]
        // public IActionResult CreateAbout(CreateAboutDto dto)
        // {
            
        // }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            return Ok("Silindi");
        }
        // [HttpPut]
        // public IActionResult UpdateAbout(UpdateAboutDto dto)
        // {

        // }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }        
    }
}