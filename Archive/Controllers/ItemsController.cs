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

        [HttpGet]
        [Route("items/year/{year:int}")]
        public async Task<IList<Item>> GetItemsByYear(int year) => await _manager.GetItemsByYear(year);

        [HttpGet]
        [Route("items/genre/{genre:int}")]
        public async Task<IList<Item>> GetItemsByGenre(int genre) => await _manager.GetItemsByGenre(genre);
        
        [HttpGet]
        [Route("items/field/{field}")]
        public async Task<IList<Item>> GetItemsByField(string field) => await _manager.GetItemsByField(field);

        [HttpDelete]
        [Route("items/{id:int}")]
        public async Task DeleteItem(int id) => await _manager.DeleteItem(id);

        [HttpPut]
        [Route("items/name/{id:int}")]
        public async Task EditItemName(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemName(id, request.Name);

        [HttpPut]
        [Route("items/year/{id:int}")]
        public async Task EditItemYear(int id, [FromBody] CreateItemRequest request) =>await _manager.EditItemYear(id, request.Year);

        [HttpPut]
        [Route("items/genre/{id:int}")]
        public async Task EditItemGenre(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemGenre(id, request.Genre);

        [HttpPut]
        [Route("items/field/{id:int}")]
        public async Task EditItemField(int id, [FromBody] CreateItemRequest request) => await _manager.EditItemField(id, request.Field);

        [HttpPut]
        [Route("items/description/{id:int}")]
        public async Task EditItemDescription(int id,[FromBody] CreateItemRequest request) => await _manager.EditItemDescription(id, request.Description);


    }
}
