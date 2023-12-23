using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.entity;

namespace restorant.business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> GetProductsWithCategories();
        int ProductCount();
        string ProductsByMaxPrice();
        string ProductsByMinPrice();
    }
}