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
    public class UserProcess : IUserProcess
    {
        private IUserDataAccess _userDataAccess;
        public UserProcess(IUserDataAccess userDataAccess)
        {
            this._userDataAccess = userDataAccess;
        }
        public void Add(UsersDTO usersDto)
        {
            _userDataAccess.Add(usersDto.ToDomainModel());
        }

        public UsersDTO GetUserByLoginName(string loginName)
        {
            return _userDataAccess.GetUserByLoginName(loginName).ToDto();
        }
       
    }
}
