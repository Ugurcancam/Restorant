using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.webui.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
    }
}