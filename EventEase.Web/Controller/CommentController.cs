using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EventEase.Web.Interfaces;
using EventEase.Web.Models;

namespace EventEase.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentPageService _commentPageService;

        public CommentController(ICommentPageService commentPageService)
        {
            this._commentPageService = commentPageService;
        }

        // GET: CommentController
        public ActionResult Index()
        {
            ViewData["ActivePage"] = "Comments"; // Set active page
            return View();
        }

        public async Task<ActionResult> GetComments()
        {
            ViewData["ActivePage"] = "Comments"; // Set active page
            var commentList = await _commentPageService.GetComments();
            return View(commentList);
        }

        public async Task<ActionResult> ViewComment(int id)
        {
            ViewData["ActivePage"] = "Comments"; // Set active page
            var comment = await _commentPageService.ViewComment(id);
            if (comment == null)
            {
                return RedirectToAction("GetComments");
            }
            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel commentViewModel)
        {
            var result = await _commentPageService.PostComment(commentViewModel);
            return RedirectToAction("ViewDetails", "Event", new { id = commentViewModel.EventId });
        }

        public async Task<ActionResult> EditComment(int id)
        {
            ViewData["ActivePage"] = "Comments"; // Set active page
            var ans = await _commentPageService.ViewComment(id);
            if (ans == null)
            {
                return RedirectToAction("GetComments");
            }

            return View(ans);
        }

        [HttpPost]
        public ActionResult EditComment(CommentViewModel commentViewModel)
        {
            var _id = _commentPageService.EditComment(commentViewModel);
            if (_id > 0)
            {
                return RedirectToAction("ViewComment", new { id = _id });
            }
            return View();
        }
    }
}
