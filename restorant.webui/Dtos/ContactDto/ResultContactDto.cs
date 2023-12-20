using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restorant.webui.Dtos.ContactDto
{
    public class ResultContactDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }        
    }
}