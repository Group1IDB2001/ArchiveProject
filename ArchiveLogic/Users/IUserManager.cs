using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Users
{
    public interface IUserManager
    {
        Task<bool> AddUser(string name, string email, string password, usersituation role);
        Task<bool> SingIn(string email, string password);
        Task<bool> FindUserByEmail(string email);
        Task<User> GetUserByEmail(string email);
        Task<int> GetUserRole(string email);
    }
}
