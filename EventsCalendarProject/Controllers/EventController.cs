using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsCalendarProject.Models;

namespace EventsCalendarProject.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository repo;
        public EventController(IEventRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var events = repo.GetAllEvents();
            return View(events);            
        }
        public IActionResult ViewEvent(int id)
        {
            var e = repo.GetEvent(id);
            return View(e);
        }
        public IActionResult InsertEvent()
        {
            var e = repo.AssignCategory();
            return View(e);
        }
        public IActionResult InsertEventToDatabase(Event eventToInsert)
        {
            repo.InsertEvent(eventToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateEvent(int id)
        {
            Event evnt = repo.GetEvent(id);
            repo.AssignCategoryUpdate(evnt);            
            repo.UpdateEvent(evnt);

            if (evnt == null)
            {
                return View("EventNotFound");
            }
            return View(evnt);
        }

        public IActionResult UpdateEventToDatabase(Event e)
        {
            repo.UpdateEvent(e);
            return RedirectToAction("ViewEvent", new { id = e.EventID});
        }
        public IActionResult DeleteEvent(Event e)
        {
            repo.DeleteEvent(e);
            return RedirectToAction("Index");
        }
    }
}
