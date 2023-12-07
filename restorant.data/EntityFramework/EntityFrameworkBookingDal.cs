using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.data.Abstract;
using restorant.data.Repository;
using restorant.entity;

namespace restorant.data.EntityFramework
{
    public class EntityFrameworkBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EntityFrameworkBookingDal(RestorantContext context) : base(context)
        {
            
        }
    }
}