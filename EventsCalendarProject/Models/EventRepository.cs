using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using EventsCalendarProject.Models;
using Dapper;

namespace EventsCalendarProject.Models
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _conn;
        public EventRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            {
                return _conn.Query<Event>("SELECT * FROM EVENTS;");             //Regular Dapper                                                                                 
            }
        }

        public Event GetEvent(int id)
        {
              return _conn.QuerySingle<Event>("SELECT * FROM EVENTS WHERE EVENTID = @id", new { id = id });            
        }
    }
}
