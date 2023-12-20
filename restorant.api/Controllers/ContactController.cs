using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.ContactDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private IMapper _mapper;

        public ContactController(IContactService contactService,IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contactDto)
        {
            var values = _mapper.Map<Contact>(contactDto);
            _contactService.Add(values);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.GetById(id);
            _contactService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto contactDto)
        {
            var values = _mapper.Map<Contact>(contactDto);
            _contactService.Update(values);
            return Ok("Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.GetById(id);
            return Ok(value);
        }         
    }
}