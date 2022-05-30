using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class CountrysController : Controller
    {
        private readonly ICountryManager _manager;

        public CountrysController(ICountryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
