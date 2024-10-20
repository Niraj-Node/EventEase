using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventEase.Application.Models;

namespace EventEase.Application.Interfaces
{
    public interface IEventService
    {
        Task<IList<EventModel>> GetEvents();
        Task<EventModel> ViewDetails(int eventId);
        Task<int> CreateEvent(EventModel eventViewModel, string organiser);
        int UpdateEvent(EventModel eventViewModel);
        Task<IList<EventModel>> MyEvents(string organiser);
        Task<IList<CommentModel>> GetAllCommentByEventId(int eventId);
        Task DeleteEvent(int eventId);
    }
}
