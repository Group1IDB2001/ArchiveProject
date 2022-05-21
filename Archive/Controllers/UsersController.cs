using ArchiveLogic.Users;
using ArchiveStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archive.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly IUserManager _manager;

        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {
            return View();
        }
        



        


        [HttpGet]
        public async Task<IActionResult> UserPage(string mail)
        {
            
            var user = await _manager.GetUserByEmail(mail);
            return View(user);
        }


        //login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] CreateUserRequest account)
        {
             var Account = await _manager.SingIn(account.Email, account.Password);
             if (Account)
             {
                return RedirectToAction("UserPage", new { mail = account.Email });
             }
             else
             {
                 var account_1 = await _manager.FindUserByEmail(account.Email);
                 if (account_1) ModelState.AddModelError("Password", "The password is incorrect");
                 else ModelState.AddModelError("Email", "The Email or password is incorrect");

            }
            return View();
        }







        //Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserRequest Request)
        {
            if (ModelState.IsValid)
            {
                var Account = await _manager.AddUser(Request.Name , Request.Email, Request.Password, Request.Role);
                if (Account)
                    return Redirect("Login");
                else
                {
                    var account_1 = await _manager.FindUserByEmail(Request.Email);
                    if (account_1) ModelState.AddModelError("Email", "This email address already exists! Please enter a new email address!");
                }
            }
            return View();
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login", "Account");
        //}



        //[HttpGet]
        //[Route("users")]
        //public async Task<IList<User>> GetAllUsers() => await _manager.GetAllUsers();

        //[HttpDelete]
        //[Route("users/{id:int}")]
        //public async Task DeleteUser(int id) => await _manager.DeleteUser(id);


        //[HttpPut]
        //[Route("users/name/{id:int}")]
        //public async Task EditUserName(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserName(id, request.Name);

        //[HttpPut]
        //[Route("users/email/{id:int}")]
        //public async Task EditUserMail(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserMail(id, request.Email);

        //[HttpPut]
        //[Route("users/password/{id:int}")]
        //public async Task EditUserPassword(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserPassword(id, request.Password);

        //[HttpPut]
        //[Route("users/role/{id:int}")]
        //public async Task EditUserRole(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserRole(id, request.Role);

        //[HttpPut]
        //[Route("users/edit/{id:int}")]
        //public async Task EditUser(int id, [FromBody] CreateUserRequest request) => await _manager.EditUser(id, request.Name, request.Email, request.Password, request.Role);


        
    }
}
