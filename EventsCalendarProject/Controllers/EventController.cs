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
    }
}
