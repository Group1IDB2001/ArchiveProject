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




        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }



        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Pleace enter valid email.")]
        public string Email { get; set; }





        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }





        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required.")]
        public usersituation Role { get; set; }
    }
}
