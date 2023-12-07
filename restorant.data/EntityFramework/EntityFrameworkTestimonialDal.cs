using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.data.Abstract;
using restorant.data.Repository;
using restorant.entity;

namespace restorant.data.EntityFramework
{
    public class EntityFrameworkTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
    {
        public EntityFrameworkTestimonialDal(RestorantContext context) : base(context)
        {
            
        }
    }
}