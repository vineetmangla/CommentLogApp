using CommentLog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.Process
{
    public interface ICommentProcess
    {
        void AddComment(CommentsDTO commentsDto);
        List<CommentsDTO> GetAll();

        List<CommentsDTO> Search(string searchTerm,int userId);
    }
}
