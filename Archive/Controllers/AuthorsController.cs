using Microsoft.AspNetCore.Mvc;
using ArchiveLogic.Authors;
using ArchiveStorage.Entities;
using Microsoft.EntityFrameworkCore;

namespace Archive.Controllers

{
    public class AuthorsController : Controller
    {
        private readonly IAuthorManager _manager;

        public AuthorsController(IAuthorManager manager)
        {
            _manager=manager;
        }


        [HttpPut]
        [Route("authors")]
        public async Task AddAuthor([FromBody] CreateAuthorRequest request) => await _manager.AddAuthor(request.Name, request.Born, request.Death, request.About);

        [HttpGet]
        [Route("authors")]
        public async Task<IList<Author>> GetAllAuthors() => await _manager.GetAllAuthors();


        [HttpDelete]
        [Route("authors/{id:int}")]
        public async Task DeleteAuthor(int id) => await _manager.DeleteAuthor(id);


        [HttpGet]
        [Route("authors/{id:int}")]
        public async Task<Author> GetAuthorById(int id) => await _manager.GetAuthorById(id);

        [HttpGet]
        [Route("authors/itemid/{itemid:int}")]
        public async Task<IList<Author>> GetAuthorsByItemId(int itemId) => await _manager.GetAuthorsByItemId(itemId);


        [HttpGet]
        [Route("authors/{name}")]
        public async Task<Author> GetAuthorByName(string name) => await _manager.GetAuthorByName(name);

        [HttpGet]
        [Route("authors/year/{year:int}")]
        public async Task<IList<Author>> GetAuthorsByYear(int year) => await _manager.GetAuthorsByYear(year);

        [HttpPut]
        [Route("authors/name/{id:int}")]
        public async Task EditAuthorName(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorName(id, request.Name);

        [HttpPut]
        [Route("authors/born/{id:int}")]
        public async Task EditAuthorBorn(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorBorn(id, request.Born);

        [HttpPut]
        [Route("authors/death/{id:int}")]
        public async Task EditAuthorDeath(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorDeath(id, request.Death);

        [HttpPut]
        [Route("authors/about/{id:int}")]
        public async Task EditAuthorAbout(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorAbout(id, request.About);

        //Page
        

        //

        public async Task<IActionResult> Main(int? page)
        {
            var authors = await _manager.GetAllAuthors();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }
    }
}
