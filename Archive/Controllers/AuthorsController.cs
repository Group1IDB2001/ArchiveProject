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

        //PickAuthor добавить автора к каталогу
        public async Task<IActionResult> PickAuthor()
        {
            var authors = await _manager.GetAllAuthors();
            return View(authors);
        }
        
        
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //Атрибут [Bind] позволит нам указать точные свойства модели, которые следует включать или исключать при привязке
        public async Task<IActionResult> Create([Bind("Name,Born ,Death ,About")] CreateAuthorRequest author)
        {
            //ModelState.IsValid свойство который проверил две вещи:
            //1.Привязаны ли значения формы к Модели.
            //2.Все проверки, указанные внутри класса модели с использованием аннотаций данных, были переданы.
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

        //ActionName используется для другого имени метода действия(action method)
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
    }
}
