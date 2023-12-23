using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.business.Abstract;
using restorant.data.Abstract;
using restorant.entity;

namespace restorant.business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);

        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public int ProductCount()
        {
            return _productDal.ProductCount();
        }

        public string ProductsByMaxPrice()
        {
            return _productDal.ProductsByMaxPrice();
        }

        public string ProductsByMinPrice()
        {
            return _productDal.ProductsByMinPrice();

        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}