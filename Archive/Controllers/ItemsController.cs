using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemManager _manager;

        public ItemsController(IItemManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> Index(int pg = 1)
        {
            var items = await _manager.GetAllItems();
            int counter = items.Count();
            const int pagesize = 2;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpGet]
        
        public async Task<IActionResult> ItemPage(int pg = 1)
        {
            var items = await _manager.GetItemById(1);


            var data = items;

            

            return View(data);
        }

        [HttpGet]
        
        public async Task<IActionResult> Genre1(int pg = 1)
        {
            var items = await _manager.GetItemsByGenre((Genres)1);
            int counter = items.Count();
            const int pagesize = 2;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        //[HttpPut]
        //[Route("items")]
        //public async Task AddItem([FromBody] CreateItemRequest request) => await _manager.AddItem
        //    (request.Name, request.Description, request.Year, request.Field, request.Genre, request.CountryId);

        //[HttpGet]
        //[Route("items")]
        //public async Task<IList<Item>> GetAllItems() => await _manager.GetAllItems();
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[Route("items/{id:int}")]
        //public async Task<Item> GetItemById(int id) => await _manager.GetItemById(id);

        //[HttpGet]
        //[Route("items/{name}")]
        //public async Task<Item> GetItemByName(string name) => await _manager.GetItemByName(name);

        //[HttpGet]
        //[Route("items/year/{year:int}")]
        //public async Task<IList<Item>> GetItemsByYear(int year) => await _manager.GetItemsByYear(year);

        //[HttpGet]
        //[Route("items/genre/{genre:int}")]
        //public async Task<IList<Item>> GetItemsByGenre(Genres genre) => await _manager.GetItemsByGenre(genre);

        //[HttpGet]
        //[Route("items/field/{field}")]
        //public async Task<IList<Item>> GetItemsByField(string field) => await _manager.GetItemsByField(field);

        //[HttpDelete]
        //[Route("items/{id:int}")]
        //public async Task DeleteItem(int id) => await _manager.DeleteItem(id);











        //[HttpPut]
        //[Route("items/name/{id:int}")]
        //public async Task EditItemName(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemName(id, request.Name);

        //[HttpPut]
        //[Route("items/year/{id:int}")]
        //public async Task EditItemYear(int id, [FromBody] CreateItemRequest request) =>await _manager.EditItemYear(id, request.Year);

        //[HttpPut]
        //[Route("items/genre/{id:int}")]
        //public async Task EditItemGenre(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemGenre(id, request.Genre);

        //[HttpPut]
        //[Route("items/field/{id:int}")]
        //public async Task EditItemField(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemField(id, request.Field);

        //[HttpPut]
        //[Route("items/description/{id:int}")]
        //public async Task EditItemDescription(int id,[FromBody] CreateItemRequest request) => await _manager.EditItemDescription(id, request.Description);











        //[HttpGet]
        //[Route("items/authorid/{authorid:int}")]
        //public async Task<IList<Item>> GetItemsByAuthorId(int authorId) => await _manager.GetItemsByAuthorId(authorId);

        //[HttpGet]
        //[Route("items/authorname/{authorname}")]
        //public async Task<IList<Item>> GetItemsByAuthorName(string authorname) => await _manager.GetItemsByAuthorName(authorname);

        //[HttpPut]
        //[Route("items/{itemid:int}/authorid/{authorid:int}")]
        //public async Task AddAuthorToItem(int itemid, int authorid) => await _manager.AddAuthorToItem(itemid, authorid);

        //[HttpDelete]
        //[Route("items/itemid/{itemid:int}/authorid/{authorid:int}")]
        //public async Task DeleteAuthorFromItem(int itemid, int authorid) => await _manager.DeleteAuthorFromItem(itemid, authorid);

        //[HttpPut]
        //[Route("items/itemid/{itemid:int}/newauthorid/{newauthorid:int}")]
        //public async Task ReplaceAllAuthorsInItem(int itemid, int newauthorid) => await _manager.ReplaceAllAuthorsInItem(itemid, newauthorid);










        //[HttpGet]
        //[Route("items/languageId/{languageId:int}")]
        //public async Task<IList<Item>> GetItemsByLanguage(int languageId) => await _manager.GetItemsByLanguage(languageId);

        //[HttpPut]
        //[Route("items/{itemid:int}/languageId/{languageId:int}")]
        //public async Task AddLanguageToItem(int itemid, int languageId) => await _manager.AddLanguageToItem(itemid, languageId);

        //[HttpDelete]
        //[Route("items/itemid/{itemid:int}/languageId/{languageId:int}")]
        //public async Task DeleteLanguageFromItem(int itemid, int languageId) => await _manager.DeleteLanguageFromItem(itemid, languageId);

        //[HttpPut]
        //[Route("items/itemid/{itemid:int}/newlanguageId/{newlanguageId:int}")]
        //public async Task ReplaceAllLanguagesInItem(int itemid, int newlanguageId) => await _manager.ReplaceAllLanguagesInItem(itemid, newlanguageId);







        //[HttpPut]
        //[Route("items/{itemid:int}/ttagId/{ttagId:int}")]
        //public async Task AddTTagToItem(int itemid, int ttagId) => await _manager.AddTTagToItem(itemid , ttagId);

        //[HttpDelete]
        //[Route("items/itemid/{itemid:int}/ttagId/{ttagId:int}")]
        //public async Task DeleteTTagFromItem(int itemid, int ttagId) => await _manager.DeleteTTagFromItem(itemid, ttagId);

        //[HttpPut]
        //[Route("items/itemid/{itemid:int}/newttagId/{newttagId:int}")]
        //public async Task ReplaceAllTTagsInItem(int itemid, int newttagId) => await _manager.ReplaceAllTTagsInItem(itemid, newttagId);







    }
}
