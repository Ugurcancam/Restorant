using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.FeatureDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private IMapper _mapper;

        public FeatureController(IFeatureService featureService,IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto featureDto)
        {
            var values = _mapper.Map<Feature>(featureDto);
            _featureService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.GetById(id);
            _featureService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto featureDto)
        {
            var values = _mapper.Map<Feature>(featureDto);
            _featureService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.GetById(id);
            return Ok(value);
        }         
    }
}