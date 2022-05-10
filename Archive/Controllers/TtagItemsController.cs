using ArchiveLogic.TtagItems;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class TtagItemsController : Controller
    {
        private readonly ITtagItemManager _manager;

        public TtagItemsController(ITtagItemManager manager)
        {
            _manager = manager;
        }

        [HttpPut]
        [Route("Ttagitems")]
        public async Task AddTtagToItem([FromBody] CreateTtagItemRequest request) => await _manager.AddTtagToItem(request.ItemId, request.TtagId);

        [HttpGet]
        [Route("Ttagitems")]
        public async Task<IList<TtagItem>> GetAllTtagItem() => await _manager.GetAllTtagItem();

        [HttpDelete]
        [Route("Ttagitems/itemId/{itemId:int}/ttagId/{ttagId}")]
        public async Task DeleteTtagFromItem(int itemId, int ttagId) => await _manager.DeleteTtagFromItem(itemId, ttagId);

        [HttpGet]
        [Route("Ttagitems/itemId/{itemId}")]
        public async Task<IList<TtagItem>> GetByItems(int itemId) => await _manager.GetByItems(itemId);

        [HttpGet]
        [Route("Ttagitems/ttagId/{ttagId}")]

        public async Task<IList<TtagItem>> GetByTtag(int ttagId) => await _manager.GetByTtag(ttagId);



        public IActionResult Index()
        {
            return View();
        }
    }
}
