using ArchiveLogic.Users;
using ArchiveStorage;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Archive.Controllers
{
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
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(string name , string email , string password , int role)
        {
            if (ModelState.IsValid)
            {
                await _manager.AddUser(name, email, password, role);
                ModelState.Clear();
                ViewBag.Message = name + " " + " successfully register.";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string name , string password)
        {
            var user = _manager.UserLogin(name, password);
            if(user != null) return RedirectToAction("Index", "Home");
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }





        [HttpPut]
        [Route("users")]
        public async Task AddUser([FromBody] CreateUserRequest request) => await _manager.AddUser(request.Name, request.Email, request.Password, request.Role);



















        [HttpGet]
        [Route("users")]
        public async Task<IList<User>> GetAllUsers() => await _manager.GetAllUsers();

        [HttpDelete]
        [Route("users/{id:int}")]
        public async Task DeleteUser(int id) => await _manager.DeleteUser(id);

        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<User> GetUserById(int id) => await _manager.GetUserById(id);

        [HttpGet]
        [Route("users/{name}")]
        public async Task<User> GetUserByName(string name) => await _manager.GetUserByName(name);


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
