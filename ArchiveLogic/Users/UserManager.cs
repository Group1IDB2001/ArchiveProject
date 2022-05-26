using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Users
{
    public class UserManager : IUserManager
    {
        private readonly ArchiveContext _context;
        public UserManager(ArchiveContext context)

        {
            _context = context;
        }



        public async Task<bool> AddUser(string name, string email, string password, usersituation role)
        {
            var user_1 = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user_1 == null)
            {
                var user = new User { Name = name, Email = email, Password = password, Role = (usersituation)role };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<bool> SingIn(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user != null) return true;
            else return false;
        }

        





        public async Task<IList<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }





        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;

        }
        public async Task<bool> FindUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null) return true;
            else return false;
        }








        public async Task EditUserName(int id, string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Name = name;
            await _context.SaveChangesAsync();
        }

        public async Task EditUserMail(int id, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Email = email;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditUserPassword(int id, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Password = password;
            await _context.SaveChangesAsync();
        }

        public async Task EditUserRole(int id, usersituation role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Role = (usersituation)role;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditUser(int id, string name, string email, string password, usersituation role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Name = name;
            user.Email = email;
            user.Password = password;
            user.Role = (usersituation)role;
            await _context.SaveChangesAsync();
        }



       
    }
}
