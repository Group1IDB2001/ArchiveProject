using ArchiveLogic.Collections;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionManager _manager;

        public CollectionController(ICollectionManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index(int pg = 1)
        {
            var items = await _manager.GetAllCollection();
            int counter = items.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CollectionsPage()
        {

            var col = await _manager.GetCollectionsByUsreId(GlobalData.uid);
            return View(col);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Collection col)
        {
            col.UserId = GlobalData.uid;
            await _manager.AddCollection(col.Name, col.Description, col.UserId);

            return RedirectToRoute(new { controller = "Collection", action = "CollectionsPage" });
        }



    }
}
