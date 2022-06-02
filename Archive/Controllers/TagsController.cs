using ArchiveLogic.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class TagsController : Controller
    {
        private readonly ITtagManager _manager;

        public TagsController(ITtagManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index(int id)
        {
            var tags = await _manager.GetAllTtags();
            return View(tags);
        }

        public async Task<IActionResult> PickTag(int id)
        {
            var tags = await _manager.GetAllTtags();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> TagPage(int id)
        {
            GlobalData.iid = id;
            var tags = await _manager.GetTtagsByItem(id);
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            GlobalData.TN.Clear();
            var tags = await _manager.GetTtagsByItem(GlobalData.iid);
            if (tags != null)
            {
                foreach (var a in tags)
                {
                    GlobalData.TN.Add(a.Name);
                }
            }
            else
                GlobalData.TN.Add("Тегов пока нет");
            return Redirect("/Items/ItemPageW");
        }
        [HttpGet]
        public async Task<IActionResult> TagListC()
        {
            GlobalData.TN.Clear();
            var tags = await _manager.GetTtagsByItem(GlobalData.iid);
            if (tags != null)
            {
                foreach (var a in tags)
                {
                    GlobalData.TN.Add(a.Name);
                }
            }
            else
                GlobalData.TN.Add("Тегов пока нет");
            return Redirect("/Items/ItemPageCollectionW");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ttag col)
        {
            col.UserId = GlobalData.uid;
            var tatego = await _manager.AddTtag(col.Name, col.UserId, col.Description);
            if(tatego)
                return RedirectToRoute(new { controller = "Tags", action = "Index" });
            else
            {
                var tatego_1 = await _manager.FindTtag(col.Name);
                if (tatego_1) ModelState.AddModelError("", "Tag is already existing");
            }
            return View();
        }
    }
}
