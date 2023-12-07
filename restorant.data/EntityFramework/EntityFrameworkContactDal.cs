using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.data.Abstract;
using restorant.data.Repository;
using restorant.entity;

namespace restorant.data.EntityFramework
{
    public class EntityFrameworkContactDal : GenericRepository<Contact>, IContactDal
    {
        public EntityFrameworkContactDal(RestorantContext context) : base(context)
        {
            
        }
    }
}