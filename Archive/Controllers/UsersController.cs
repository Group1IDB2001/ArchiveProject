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
        static private string _email;

        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserPage()
        {

            var user = await _manager.GetUserByEmail(_email);
            GlobalData.uid = user.Id;
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
        public async Task<IActionResult> Login([Bind("Email,Password")] CreateUserRequest account , string ginger)
        {
            GlobalData.gingn = ginger;
            var Account = await _manager.SingIn(account.Email, account.Password);
             if (Account)
             {
                _email= account.Email;
                return RedirectToAction("UserPage");
                //return RedirectToAction("UserPage", new { mail = account.Email });
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
        public async Task<IActionResult> Register(CreateUserRequest Request,string ginger)
        {
            GlobalData.gingn = ginger;
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

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
