using ArchiveLogic.CollectionItems;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class CollectionItemController : Controller
    {
        private readonly ICollectionItemManager _manager;

        public CollectionItemController(ICollectionItemManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> ShowItems(int id)
        {
            var lis = await _manager.GetItemCollectionByCollection(id);
            GlobalData.ids = new List<int>();
            foreach(var col in lis)
            {
                GlobalData.ids.Add(col.Id);
            }
            return Redirect("/Items/ItemsIn");
        }

        [HttpPut]
        //[Route("collectionitems")]
        public async Task AddCollectionItem([FromBody] CreateCollectionItemRequest request) => await _manager.AddCollectionItem(request.CollectionId ,request.ItemId);


        [HttpGet]
        //[Route("collectionitems")]
        public async Task<IList<CollectionItem>> GetAllCollectionItem() => await _manager.GetAllCollectionItem();

        [HttpDelete]
        //[Route("collectionitems/{collectionId}/{itemId}")]
        public async Task DeleteCollectionItem(int collectionId, int itemId) => await _manager.DeleteCollectionItem(collectionId, itemId);

        [HttpGet]
        //[Route("collectionitems/collectionId/{collectionId}")]
        public async Task<IList<CollectionItem>> GetItemCollectionByCollection(int collectionId) => await _manager.GetItemCollectionByCollection(collectionId);

        [HttpGet]
        //[Route("collectionitems/itemId/{itemId}")]
        public async Task<IList<CollectionItem>> GetItemCollectionByItem(int itemId) => await _manager.GetItemCollectionByItem(itemId);












        public IActionResult Index()
        {
            return View();
        }
    }
}
