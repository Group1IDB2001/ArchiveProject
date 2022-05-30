using ArchiveLogic.Saves;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveManager _manager;

        public SaveController(ISaveManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
