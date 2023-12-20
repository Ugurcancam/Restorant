using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using restorant.business.Abstract;
using restorant.dto.BookingDto;
using restorant.entity;

namespace restorant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private IMapper _mapper;

        public BookingController(IBookingService bookingService,IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto bookingDto)
        {
            Booking booking = new Booking()
            {
                Email = bookingDto.Email,
                Date = bookingDto.Date,
                Name = bookingDto.Name,
                PersonCount = bookingDto.PersonCount,
                Phone = bookingDto.Phone,
                Description= bookingDto.Description
            };
            _bookingService.Add(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.GetById(id);
            _bookingService.Delete(value);
            return Ok("Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto bookingDto)
        {
           Booking booking = new Booking()
            {
                Email = bookingDto.Email,
                Id = bookingDto.Id,
                Name = bookingDto.Name,
                PersonCount = bookingDto.PersonCount,
                Phone = bookingDto.Phone,
                Date = bookingDto.Date
            };
            _bookingService.Update(booking);
            return Ok("Rezervasyon Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.GetById(id);
            return Ok(value);
        }         
    }
}