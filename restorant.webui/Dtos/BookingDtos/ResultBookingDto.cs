using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restorant.webui.Dtos.BookingDto
{
    public class ResultBookingDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description {get; set;}
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? PersonCount { get; set; }
        public DateTime Date { get; set; }
	}
}
