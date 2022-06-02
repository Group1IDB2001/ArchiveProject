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
        public async Task<int> GetUserRole(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return (int)user.Role;
        }
    }
}
