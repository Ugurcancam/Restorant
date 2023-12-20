using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.entity
{
    public class Discount : EntityBase
    {
        public string? Title { get; set; }
        public int? Amount { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl  { get; set; }
    }
}