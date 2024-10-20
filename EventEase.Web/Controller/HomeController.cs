using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Web.Interfaces;
using EventEase.Infrastructure.Repository;

namespace TSWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventPageService _eventPageService;
        public HomeController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["ActivePage"] = "Home";
            var data = await _eventPageService.GetEvents();
            return View(data);
        }
    }
}
