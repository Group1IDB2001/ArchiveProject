using ArchiveLogic.IItemLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemLanguagesController : Controller
    {
        private readonly IItemLanguageManager _manager;

        public ItemLanguagesController(IItemLanguageManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
