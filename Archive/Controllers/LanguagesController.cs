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

        [HttpPut]
        [Route("languages")]
        public async Task AddLanguage([FromBody] CreateLanguageRequest request) => await _manager.AddLanguage(request.Name);

        [HttpGet]
        [Route("languages")]
        public async Task<IList<Language>> GetAllLanguage() => await _manager.GetAllLanguage();

        [HttpDelete]
        [Route("languages/{name}")]
        public async Task DeleteLanguage(string name) => await _manager.DeleteLanguage(name);

        [HttpGet]
        [Route("languages/{id:int}")]
        public async Task<Language> GetLanguageById(int id) => await _manager.GetLanguageById(id);

        [HttpGet]
        [Route("languages/{name}")]
        public async Task<Language> GetLanguageByName(string name) => await _manager.GetLanguageByName(name);




        public IActionResult Index()
        {
            return View();
        }
    }
}
