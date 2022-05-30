using ArchiveLogic;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemAuthorsController : Controller
    {
        private readonly IItemAuthorManager _manager;

        public ItemAuthorsController(IItemAuthorManager manager)
        {
            _manager = manager;
        }

        //PickAuthor добавить автора к каталогу
        public async Task<IActionResult> PickAuthor(int id)
        {
            GlobalData.iid = id;
            return Redirect("/Authors/PickAuthor");
        }

        public async Task<IActionResult> AddAuthorToItem(int id)
        {
            var newauthor =await _manager.AddItemAuthor(id,GlobalData.iid);
            return Redirect("/Items/Index");
        }
    }
}
