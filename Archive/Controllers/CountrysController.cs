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

        [HttpPut]
        [Route("countrys")]
        public async Task AddCountry([FromBody] CreateCountryRequest request) => await _manager.AddCountry(request.Name);

        [HttpGet]
        [Route("countrys")]
        public async Task<IList<Country>> GetAllCountries() => await _manager.GetAllCountries();

        [HttpDelete]
        [Route("countrys/{id:int}")]
        public Task DeleteCountry(int id) => _manager.DeleteCountry(id);


        [HttpGet]
        [Route("countrys/{id:int}")]
        public async Task<Country> GetCountryById(int id) => await _manager.GetCountryById(id);

        [HttpGet]
        [Route("countrys/{name}")]
        public async Task<Country> GetCountryByName(string name) => await _manager.GetCountryByName(name);

        public IActionResult Index()
        {
            return View();
        }

    }
}
