using ArchiveLogic.IItemLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemLanguageController : Controller
    {
        private readonly IItemLanguageManager _manager;

        public ItemLanguageController(IItemLanguageManager manager)
        {
            _manager = manager;
        }

        [HttpPut]
        [Route("itemlanguages")]
        public async Task AddItemLanguage([FromBody] CreateItemLanguageRequest request) => await _manager.AddItemLanguage(request.LanguageId, request.ItemId);


        [HttpGet]
        [Route("itemlanguages")]
        public async Task<IList<ItemLanguage>> GetAllItemLanguages() => await _manager.GetAllItemLanguages();

        [HttpPut]
        [Route("itemlanguages/itemid/{id:int}")]
        public async Task EditItemId(int id, [FromBody] CreateItemLanguageRequest request) => await _manager.EditItemId(id, request.ItemId);

        [HttpPut]
        [Route("itemlanguages/languageid/{id:int}")]
        public async Task EditLanguageId(int id, [FromBody] CreateItemLanguageRequest request) => await _manager.EditLanguageId(id, request.LanguageId);










        public IActionResult Index()
        {
            return View();
        }
    }
}
