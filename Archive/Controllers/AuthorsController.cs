using Microsoft.AspNetCore.Mvc;
using ArchiveLogic.Authors;
using ArchiveStorage.Entities;
namespace Archive.Controllers

{
    public class AuthorsController : Controller
    {
        private readonly IAuthorManager _manager;

        public AuthorsController(IAuthorManager manager)
        {
            _manager=manager;
        }

        [HttpGet]
        [Route("authors")]
        public async Task<IList<Author>> GetAllAuthors() => await _manager.GetAllAuthors();


        [HttpDelete]
        [Route("authors/{id:int}")]
        public Task DeleteAuthor(int id) => _manager.DeleteAuthor(id);


        [HttpGet]
        [Route("authors/{id:int}")]
        public async Task<Author> GetAuthorById(int id) => await _manager.GetAuthorById(id);



        [HttpPut]
        [Route("authors")]
        public async Task AddAuthor([FromBody] CreateAuthorRequest request) => await _manager.AddAuthor(request.Name, request.Born, death: request.Death, about: request.About);

        [HttpGet]
        [Route("authors/{name}")]
        public async Task<Author> GetAuthorByName(string name) => await _manager.GetAuthorByName(name);

        [HttpGet]
        [Route("authors/year/{year:int}")]
        public async Task<IList<Author>> GetAuthorsByYear(int year) => await _manager.GetAuthorsByYear(year);

        [HttpPost]
        [Route("authors/{id}/name/{name}")]
        public async Task EditAuthorName(int id, string name)=> await _manager.EditAuthorName(id, name);

        [HttpPost]
        [Route("authors/{id}/born/{born:int}")]
        public async Task EditAuthorBorn(int id, int born) => await _manager.EditAuthorBorn(id, born);

        [HttpPost]
        [Route("authors/{id}/death/{death:int}")]
        public async Task EditAuthorDeath(int id, int? death) => await _manager.EditAuthorDeath(id, death);

        [HttpPost]
        [Route("authors/{id}/about/{about}")]
        public async Task EditAuthorAbout(int id, string? about)=> await _manager.EditAuthorAbout(id, about);

        public IActionResult Index()
        {
            return View();
        }

    }
}
