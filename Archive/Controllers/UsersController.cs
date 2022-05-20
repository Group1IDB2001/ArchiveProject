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
        



        //login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.Name != null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UserPage(string mail)
        {
            
            var us =  _manager.GetUserByEmail("Oliver.Jackson@gmail.com");
            var data = us;
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CreateUserRequest Request)
        {
            if (ModelState.IsValid)
            {
                var Account = await _manager.SingIn(Request.Name, Request.Password);
                if (Account)
                {
                    //await Authenticate(Request.Email);//аутентификация
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    var account_1 = await _manager.FindUserByEmail(Request.Email);
                    if (account_1) ModelState.AddModelError("", "The password is incorrect");
                    else ModelState.AddModelError("", "The account does not exist");
                }

            }
            return View();
        }







        //Register
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.Name != null)
                return RedirectToRoute(new { controller = "Home", action = "Index" });
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
                    if (account_1) ModelState.AddModelError("", "Email is already in use");
                    else ModelState.AddModelError("", "Nickname is already in use");
                }
            }
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public Task<bool> SignIn([FromBody] CreateUserRequest request) => _manager.SingIn(request.Email, request.Password);

        [HttpPost]
        [Route("Register")]
        public Task<bool> AddUser([FromBody] CreateUserRequest request) => _manager.AddUser(request.Name, request.Email, request.Password , request.Role);

        private async Task Authenticate(string email)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }



        [HttpGet]
        [Route("users")]
        public async Task<IList<User>> GetAllUsers() => await _manager.GetAllUsers();

        [HttpDelete]
        [Route("users/{id:int}")]
        public async Task DeleteUser(int id) => await _manager.DeleteUser(id);


        [HttpPut]
        [Route("users/name/{id:int}")]
        public async Task EditUserName(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserName(id, request.Name);

        [HttpPut]
        [Route("users/email/{id:int}")]
        public async Task EditUserMail(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserMail(id, request.Email);

        [HttpPut]
        [Route("users/password/{id:int}")]
        public async Task EditUserPassword(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserPassword(id, request.Password);

        [HttpPut]
        [Route("users/role/{id:int}")]
        public async Task EditUserRole(int id, [FromBody] CreateUserRequest request) => await _manager.EditUserRole(id, request.Role);

        [HttpPut]
        [Route("users/edit/{id:int}")]
        public async Task EditUser(int id, [FromBody] CreateUserRequest request) => await _manager.EditUser(id, request.Name, request.Email, request.Password, request.Role);


        
    }
}
