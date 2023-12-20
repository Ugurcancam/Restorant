using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.entity
{
    public class Feature : EntityBase
    {
        public string? Title { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? Description{ get; set; }
        public string? Description2 { get; set; }
        public string? Description3 { get; set; }
    }
}