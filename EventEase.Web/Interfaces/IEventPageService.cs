using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Web.Models;

namespace EventEase.Web.Interfaces
{
    public interface IEventPageService
    {
        Task<IList<EventViewModel>> GetEvents();
        Task<EventViewModel> ViewDetails(int eventId);
        Task<int> CreateEvent(EventViewModel eventViewModel, string organiser);
        int UpdateEvent(EventViewModel eventViewModel);

        // New method for deleting an event
        Task DeleteEvent(int eventId);

        Task<IList<EventViewModel>> MyEvents(string organiser);
        Task<IList<CommentViewModel>> GetAllCommentByEventId(int eventId);
    }
}
