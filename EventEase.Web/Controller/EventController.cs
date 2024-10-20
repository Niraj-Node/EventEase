using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Web.Models;
using EventEase.Infrastructure.Repository;
using EventEase.Core.Entities;
using EventEase.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TSWebApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventPageService _eventPageService;

        public EventController(IEventPageService eventPageService)
        {
            this._eventPageService = eventPageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewDetails(int? id)
        {
            var details = await _eventPageService.ViewDetails(id.Value);
            var ans = await _eventPageService.GetAllCommentByEventId(id.Value);
            details.Comments = ans;
            if (details == null)
            {
                return RedirectToAction("GetEvents");
            }
            return View(details);
        }

        [Authorize]
        public ViewResult CreateEvent(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            ViewData["ActivePage"] = "CreateEvent"; // Set active page
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateEvent(EventViewModel eventViewModel, string organiser)
        {
            if (ModelState.IsValid)
            {
                var result = await _eventPageService.CreateEvent(eventViewModel, organiser);
                if (result > 0)
                {
                    return RedirectToAction(nameof(CreateEvent), new { isSuccess = true, bookId = result });
                }
            }

            ViewData["ActivePage"] = "CreateEvent"; // Set active page again in case of failure
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UpdateEvent(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("GetEvents");
            }
            var ans = await _eventPageService.ViewDetails(id.Value);

            if (ans == null)
            {
                return RedirectToAction("GetEvents");
            }

            ViewData["ActivePage"] = "UpdateEvent"; // Set active page
            return View(ans);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateEvent(EventViewModel eventViewModel)
        {
            var _id = _eventPageService.UpdateEvent(eventViewModel);

            if (_id > 0)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }

            ViewData["ActivePage"] = "UpdateEvent"; // Set active page again in case of failure
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MyEvents()
        {
            var organiser = User.Identity.Name;
            var eventList = await _eventPageService.MyEvents(organiser);
            ViewData["ActivePage"] = "MyEvents"; // Set active page
            return View(eventList);
        }

        [Authorize]
        public async Task<IActionResult> EventsInvitedTo()
        {
            var eventList = await _eventPageService.GetEvents();
            ViewData["ActivePage"] = "EventsInvitedTo"; // Set active page
            return View(eventList);
        }

        public async Task<IActionResult> GetAllCommentByEventId(int _id)
        {
            var ans = await _eventPageService.GetAllCommentByEventId(_id);
            if (ans == null)
            {
                return RedirectToAction("ViewDetails", new { id = _id });
            }
            return View(ans);
        }

        [Authorize]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventToDelete = await _eventPageService.ViewDetails(id);
            if (eventToDelete == null)
            {
                return NotFound();
            }

            // Logic to delete the event from the database
            await _eventPageService.DeleteEvent(id);

            return RedirectToAction("MyEvents");
        }
    }
}
