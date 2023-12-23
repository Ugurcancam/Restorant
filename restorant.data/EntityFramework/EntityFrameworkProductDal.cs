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
            return context.Products.Include(product => product.Category).ToList();
        }

        public int ProductCount()
        {
            using var context = new RestorantContext();
            return context.Products.Count();
        }

        public string ProductsByMaxPrice()
        {
            using var context = new RestorantContext();
            return context.Products.Where(x=> x.Price == (context.Products.Max(y=> y.Price))).Select(z=>z.Name).FirstOrDefault();

        }

        public string ProductsByMinPrice()
        {
            using var context = new RestorantContext();
             return context.Products.Where(x=> x.Price == (context.Products.Min(y=> y.Price))).Select(z=>z.Name).FirstOrDefault();
        }
    }
}