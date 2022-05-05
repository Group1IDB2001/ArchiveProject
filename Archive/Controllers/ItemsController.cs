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


        [HttpPut]
        [Route("items")]
        public async Task AddItem([FromBody] CreateItemRequest request) => await _manager.AddItem
            (request.Name, request.Description, request.Year, request.Field, request.Genre, request.CountryId);

        [HttpGet]
        [Route("items")]
        public async Task<IList<Item>> GetAllItems() => await _manager.GetAllItems();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<Item> GetItemById(int id) => await _manager.GetItemById(id);

        [HttpGet]
        [Route("items/{name}")]
        public async Task<Item> GetItemByName(string name) => await _manager.GetItemByName(name);

    }
}
