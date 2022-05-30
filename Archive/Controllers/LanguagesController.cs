using ArchiveLogic.LLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageManager _manager;

        public LanguagesController(ILanguageManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
