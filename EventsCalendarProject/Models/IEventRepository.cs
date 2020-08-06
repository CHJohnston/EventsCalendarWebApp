using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsCalendarProject.Models
{
    public interface IEventRepository
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEvent(int id);
    }
}
