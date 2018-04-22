using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public class CommentsDataAccess : ICommentsDataAccess
    {
        private IEFRepository<Comments> _commentsRepository = null;
        public CommentsDataAccess(IEFRepository<Comments> commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        public void Add(Comments comment)
        {
            _commentsRepository.Add(comment);
        }

        public List<Comments> GetAll()
        {
            return _commentsRepository.GetAll().ToList();
        }       
        public List<Comments> Search(string searchTerm,int userId)
        {
            return _commentsRepository.FindBy(f => f.UserId==userId && f.CommentMsg.ToLower().Contains(searchTerm.ToLower())).ToList();
        }
    }
}
