using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Pleace enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public int Role { get; set; }
    }
}
