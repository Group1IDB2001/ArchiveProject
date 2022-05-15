using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Users
{
    public interface IUserManager
    {
        Task AddUser(string name, string email, string password, int role);
        Task<IList<User>> GetAllUsers();
        Task DeleteUser(int id);
        Task<User> GetUserById (int id);
        Task<User> GetUserByName(string name);
        Task<User> UserLogin(string name , string password);
        Task EditUserName(int id, string name);
        Task EditUserMail(int id, string email);
        Task EditUserPassword (int id ,string password);
        Task EditUserRole (int id,int role);
        Task EditUser(int id, string name, string email, string password, int role);
        //Task<User> GetUserByTtag(int tagId);
        //Task<User> GetUserByCollection(int collectionId);






    }
}
