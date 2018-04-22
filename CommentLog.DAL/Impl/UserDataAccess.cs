using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentLog.DomainModel;

namespace CommentLog.DAL
{
    public class UserDataAccess : IUserDataAccess
    {
        private IEFRepository<Users> _usersRepository;
        public UserDataAccess(IEFRepository<Users> usersRepository)
        {
            this._usersRepository = usersRepository;
        }
        public void Add(Users model)
        {
            _usersRepository.Add(model);            
        }

        public Users GetUserByLoginName(string loginName)
        {
           var user = _usersRepository.FindBy(f => f.Email == loginName);
            return user.FirstOrDefault();
        }
    }
}
