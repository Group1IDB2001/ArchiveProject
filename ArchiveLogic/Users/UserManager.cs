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
        enum usersituation
        {
            no_info = 0,
            Admin = 1,
            Moderator = 2,
            User = 3,
        }
        public async Task AddUser(string name, string email, string password, int role)
        {
            var user_1 = _context.Users.FirstOrDefault(u => u.Name == name);
            if(user_1 == null)
            {
                var user = new User { Name = name, Email = email, Password = password, Role = (int)(usersituation)role };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is such a Usre");
            }
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
        
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            return user;
        }
        
        public async Task<User> GetUserByName(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            return user;
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

        public async Task EditUserRole(int id, int role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Role = (int)(usersituation)role;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditUser(int id, string name, string email, string password, int role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Error,I can't found ,There is not User");
            }
            user.Name = name;
            user.Email = email;
            user.Password = password;
            user.Role = (int)(usersituation)role;
            await _context.SaveChangesAsync();
        }
    }
}
