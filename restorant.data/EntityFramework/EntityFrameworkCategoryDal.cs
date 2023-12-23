using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.data.Abstract;
using restorant.data.Repository;
using restorant.entity;

namespace restorant.data.EntityFramework
{
    public class EntityFrameworkCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EntityFrameworkCategoryDal(RestorantContext context) : base(context)
        {

        }



        public int CategoryCount()
        {
            using var context = new RestorantContext();
            return context.Categorys.Count();
        }
        public int ActiveCategoryCount()
        {
            using var context = new RestorantContext();
            return context.Categorys.Where(x => x.Status == true).Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new RestorantContext();
            return context.Categorys.Where(x => x.Status == false).Count();
        }
    }
}