using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public interface ICommentsDataAccess
    {
        void Add(Comments comment);
        List<Comments> GetAll();

        List<Comments> Search(string searchTerm,int userId);
    }
}
