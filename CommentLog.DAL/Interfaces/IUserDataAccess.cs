using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public interface IUserDataAccess
    {
        void Add(Users user);
        Users GetUserByLoginName(string loginName);
    }
}
