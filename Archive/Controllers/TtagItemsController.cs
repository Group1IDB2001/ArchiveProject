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

        [HttpGet]
        public async Task<IActionResult> ItemsByTag(int id)
        {
            var lis = await _manager.GetByTtag(id);
            GlobalData.ids.Clear();
            int ii;
            foreach (var col in lis)
            {
                if (col.ItemId != null)
                {
                    ii = ((int)col.ItemId);
                    GlobalData.ids.Add(ii);
                }
            }
            return Redirect("/Items/ItemsIn");
        }

        public async Task<IActionResult> PickTag(int id)
        {
            GlobalData.iid = id;

            return Redirect("/Tags/PickTag");
        }

        public async Task<IActionResult> AddTagToItem(int id)
        {
            await _manager.AddTtagToItem(GlobalData.iid, id);

            return Redirect("/Items/Index");
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
