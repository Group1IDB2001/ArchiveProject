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


        public async Task<IActionResult> Index(int pg = 1)
        {
            var authors = await _manager.GetAllAuthors();
            int counter = authors.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = authors.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Born ,Death ,About")] CreateAuthorRequest author)
        {
            if (ModelState.IsValid)
            {
                var Author = await _manager.AddAuthor(author.Name,author.Born,author.Death,author.About);
                if (Author)
                    return Redirect("Index");
                else
                {
                    var Author_1 = await _manager.FindAuthor(author.Name,author.Born);
                    if (Author_1) ModelState.AddModelError("", "Author is already existing");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var author = await _manager.GetAuthorById(id);
            return View(author);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var author = await _manager.GetAuthorById(id);
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,Born ,Death ,About")] Author author)
        {
            if (ModelState.IsValid)
            {
                var Author = await _manager.EditAuthor(id,author.Name, author.Born, author.Death, author.About);
                if (Author)
                    return RedirectToAction("Index");
                else
                {
                    var Author_1 = await _manager.FindAuthor(author.Name, author.Born);
                    if (Author_1) ModelState.AddModelError("", "Author is already existing");
                    
                }
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var author = await _manager.GetAuthorById(id);
            return View(author);
        }


        [HttpPost ,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _manager.DeleteAuthor(id);
            if (author) return RedirectToAction("Index");
            else
            {
                ModelState.AddModelError("", "Author is already not existing");
                return RedirectToAction("Index");
            }
        }
       
        public async Task<IActionResult> AuthorPage(int id)
        {
            var author = await _manager.GetAuthorsByItemId(id);
            return View(author);
        }





        //[HttpPut]
        //[Route("authors")]
        //public async Task AddAuthor([FromBody] CreateAuthorRequest request) => await _manager.AddAuthor(request.Name, request.Born, request.Death, request.About);

        //[HttpGet]
        //[Route("authors")]
        //public async Task<IList<Author>> GetAllAuthors() => await _manager.GetAllAuthors();


        //[HttpDelete]
        //[Route("authors/{id:int}")]
        //public async Task DeleteAuthor(int id) => await _manager.DeleteAuthor(id);


        //[HttpGet]
        //[Route("authors/{id:int}")]
        //public async Task<Author> GetAuthorById(int id) => await _manager.GetAuthorById(id);

        //[HttpGet]
        //[Route("authors/itemid/{itemid:int}")]
        //public async Task<IList<Author>> GetAuthorsByItemId(int itemId) => await _manager.GetAuthorsByItemId(itemId);


        //[HttpGet]
        //[Route("authors/{name}")]
        //public async Task<Author> GetAuthorByName(string name) => await _manager.GetAuthorByName(name);

        //[HttpGet]
        //[Route("authors/year/{year:int}")]
        //public async Task<IList<Author>> GetAuthorsByYear(int year) => await _manager.GetAuthorsByYear(year);

        //[HttpPut]
        //[Route("authors/name/{id:int}")]
        //public async Task EditAuthorName(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorName(id, request.Name);

        //[HttpPut]
        //[Route("authors/born/{id:int}")]
        //public async Task EditAuthorBorn(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorBorn(id, request.Born);

        //[HttpPut]
        //[Route("authors/death/{id:int}")]
        //public async Task EditAuthorDeath(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorDeath(id, request.Death);

        //[HttpPut]
        //[Route("authors/about/{id:int}")]
        //public async Task EditAuthorAbout(int id, [FromBody] CreateAuthorRequest request) => await _manager.EditAuthorAbout(id, request.About);

        ////Page





    }
}
