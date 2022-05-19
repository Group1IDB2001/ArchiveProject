using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public enum usersituation
    {
        Admin = 1,
        Moderator = 2,
        User = 3,
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public usersituation Role { get; set; }
    }
}
