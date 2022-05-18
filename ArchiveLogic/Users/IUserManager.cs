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





        Task<IList<User>> GetAllUsers();
        Task DeleteUser(int id);
        User GetUserByEmail(string email);





        Task EditUserName(int id, string name);
        Task EditUserMail(int id, string email);
        Task EditUserPassword (int id ,string password);
        Task EditUserRole (int id, usersituation role);
        Task EditUser(int id, string name, string email, string password, usersituation role);

        
        //Task<User> GetUserByTtag(int tagId);
        //Task<User> GetUserByCollection(int collectionId);






    }
}
