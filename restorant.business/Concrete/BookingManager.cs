using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.business.Abstract;
using restorant.data.Abstract;
using restorant.entity;

namespace restorant.business.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void Add(Booking entity)
        {
            _bookingDal.Add(entity);

        }

        public void Delete(Booking entity)
        {
           _bookingDal.Delete(entity);
        }

        public List<Booking> GetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking GetById(int id)
        {
           return _bookingDal.GetById(id);
        }

        public void Update(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}