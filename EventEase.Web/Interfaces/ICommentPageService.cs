using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventEase.Web.Models;

namespace EventEase.Web.Interfaces
{
    public interface ICommentPageService
    {

        Task<int> PostComment(CommentViewModel response);

        Task<IList<CommentViewModel>> GetComments();

        Task<CommentViewModel> ViewComment(int commentId);

        int EditComment(CommentViewModel response);
    }
}
