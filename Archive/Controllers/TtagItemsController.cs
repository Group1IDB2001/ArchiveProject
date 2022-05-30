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
            if (lis == null)
            {
                GlobalData.ids.Clear();
                return Redirect("/Items/ItemsIn");
            }
            else
            {
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
            
        }
        [HttpGet]
        public async Task<IActionResult> PickTag(int id)
        {
            GlobalData.iid = id;
            return Redirect("/Tags/PickTag");
        }


        

        [HttpGet]
        public async Task<IActionResult> AddTagToItem(int id)
        {
            var newtag = await _manager.AddTtagToItem(GlobalData.iid, id);
            if(newtag)
                return Redirect("/Items/Index");
            else
            {
                    var newtag_1 = await _manager.FindTagItem(GlobalData.iid, id);
                    if (newtag_1) ModelState.AddModelError("", "Tag with the same Item is already existing");
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
