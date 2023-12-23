using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.entity
{
    public class Order : EntityBase
    {
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}