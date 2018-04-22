using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentLog.DTO;
using CommentLog.DAL;
using CommentLog.Utility;

namespace CommentLog.Process
{
    public class CommentProcess : ICommentProcess
    {
        private ICommentsDataAccess _commentsDataAccess = null;
        public CommentProcess(ICommentsDataAccess commentsDataAccess)
        {
            _commentsDataAccess = commentsDataAccess;
        }
        public void AddComment(CommentsDTO commentsDto)
        {
            _commentsDataAccess.Add(commentsDto.ToDomainModel());
        }

        public List<CommentsDTO> GetAll()
        {
            return _commentsDataAccess.GetAll().ToDto();
        }

        public List<CommentsDTO> Search(string searchTerm,int userId)
        {
            return _commentsDataAccess.Search(searchTerm, userId).ToDto();
        }
    }
}
