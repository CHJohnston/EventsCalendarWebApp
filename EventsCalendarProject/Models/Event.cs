using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsCalendarProject.Models
{
    public class Event
    {

        public Event() { }
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set;}
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public double Admission { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
