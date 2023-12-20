using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.webui.Dtos.DiscountDto
{
    public class CreateDiscountDto
    {
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}