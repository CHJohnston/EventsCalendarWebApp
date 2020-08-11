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

        public IEnumerable<Event> GetAllEventsbyCategory(int id)
        {
            {
                return _conn.Query<Event>("SELECT * FROM EVENTS WHERE CATEGORYID = @catid", new { catid = id});             //Regular Dapper                                                                                 
            }
        }

public Event GetEvent(int id)
        {
              return _conn.QuerySingle<Event>("SELECT * FROM EVENTS WHERE EVENTID = @id", new { id = id });            
        }

        public void InsertEvent(Event eventToInsert)
        {
            _conn.Execute("INSERT INTO events (CATEGORYID, NAME, STARTDATE, STARTTIME, ENDDATE, ENDTIME, ADMISSION, ADDRESS, " +
                "CITY, STATE, ZIP, DESCRIPTION, WEBSITE) " +
                "VALUES (@catid, @name, @startdate, @starttime, @enddate, @endtime, @admission, @address," +
                "@city, @state, @zip, @description, @website);",
                new
                {
                    catid = eventToInsert.CategoryID,
                    name = eventToInsert.Name,
                    startdate = eventToInsert.StartDate,
                    starttime = eventToInsert.StartTime,
                    enddate = eventToInsert.EndDate,
                    endtime = eventToInsert.EndTime,
                    admission = eventToInsert.Admission,
                    address = eventToInsert.Address,
                    city = eventToInsert.City,
                    state = eventToInsert.State,
                    zip = eventToInsert.Zip,
                    description = eventToInsert.Description,
                    website = eventToInsert.Website }); 
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }
        public Event AssignCategory()
        {
            var categoryList = GetCategories();
            var e = new Event();
            e.Categories = categoryList;
            return e;
        }

        public void AssignCategoryUpdate(Event e)
        {
            var categoryList = GetCategories();            
            e.Categories = categoryList;            
        }

        public void DeleteEvent(Event e)
        {
            _conn.Execute("DELETE FROM EVENTS WHERE EventID = @id;",
                                       new { id = e.EventID });            
        }
        
        public void UpdateEvent(Event e)
        {           
            _conn.Execute("UPDATE events SET CATEGORYID = @catid, NAME = @name, STARTDATE = @startdate, STARTTIME = @starttime, " +
            "ENDDATE = @enddate, ENDTIME = @endtime, ADMISSION = @admission, ADDRESS = @address, CITY = @city, STATE = @state, " +
            "ZIP = @zip, DESCRIPTION = @description, WEBSITE = @website WHERE EVENTID = @id",   
                new
                {   id = e.EventID,
                    catid = e.CategoryID,
                    name = e.Name,
                    startdate = e.StartDate,
                    starttime = e.StartTime,
                    enddate = e.EndDate,
                    endtime = e.EndTime,
                    admission = e.Admission,
                    address = e.Address,
                    city = e.City,
                    state = e.State,
                    zip = e.Zip,
                    description = e.Description,
                    website = e.Website
                });
        }
    }
}
