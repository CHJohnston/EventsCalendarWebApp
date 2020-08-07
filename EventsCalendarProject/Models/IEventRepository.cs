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
        public void InsertEvent(Event eventToInsert);
        public IEnumerable<Category> GetCategories();
        public Event AssignCategory();
        public void DeleteEvent(Event e);
        public void UpdateEvent(Event e);
    }
}
