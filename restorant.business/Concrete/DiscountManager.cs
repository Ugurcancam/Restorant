using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restorant.business.Abstract;
using restorant.data.Abstract;
using restorant.entity;

namespace restorant.business.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void Add(Discount entity)
        {
            _discountDal.Add(entity);

        }

        public void Delete(Discount entity)
        {
           _discountDal.Delete(entity);
        }

        public List<Discount> GetAll()
        {
            return _discountDal.GetAll();
        }

        public Discount GetById(int id)
        {
           return _discountDal.GetById(id);
        }

        public void Update(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}