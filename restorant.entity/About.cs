using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.entity
{
    public class About : EntityBase
    {
        public string? ImageUrl { get; set; }
        public string?Title { get; set; }
        public string? Description { get; set; }
    }
}