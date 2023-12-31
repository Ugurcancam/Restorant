using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.entity;

namespace restorant.data.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        string ProductsByMaxPrice();
        string ProductsByMinPrice();
    }
}