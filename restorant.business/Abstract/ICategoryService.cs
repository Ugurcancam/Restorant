using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.entity;

namespace restorant.business.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        int CategoryCount(); 
        int ActiveCategoryCount();
        int PassiveCategoryCount();
        
    }
}