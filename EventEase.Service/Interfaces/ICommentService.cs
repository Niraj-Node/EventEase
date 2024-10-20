using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventEase.Application.Models;

namespace EventEase.Application.Interfaces
{
    public interface ICommentService
    {
        Task<int> PostComment(CommentModel response);

        Task<IList<CommentModel>> GetComments();

        Task<CommentModel> ViewComment(int commentId);

        int EditComment(CommentModel response);
      
    }
}
