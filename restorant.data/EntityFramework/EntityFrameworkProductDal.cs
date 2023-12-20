using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using restorant.data.Abstract;
using restorant.data.Repository;
using restorant.entity;

namespace restorant.data.EntityFramework
{
    public class EntityFrameworkProductDal : GenericRepository<Product>, IProductDal
    {
        public EntityFrameworkProductDal(RestorantContext context) : base(context)
        {
            
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new RestorantContext();
            var values = context.Products.Include(product => product.Category).ToList();
            return values;
        }
    }
}