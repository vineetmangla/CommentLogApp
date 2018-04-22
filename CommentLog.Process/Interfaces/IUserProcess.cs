using CommentLog.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.Process
{
    public interface IUserProcess
    {
        UsersDTO GetUserByLoginName(string loginName);
        void Add(UsersDTO usersDto);
    }
}
