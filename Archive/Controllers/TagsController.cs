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

        [HttpGet]
        [Route ("Tags")]
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
            var tags = await _manager.GetTtagsByItem(id);



            return View(tags);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPut]
        
        public async Task AddTtag([FromBody] CreateTagRequest request) => await _manager.AddTtag(request.Name, request.UserId, request.Description);
        

        [HttpGet]
        //[Route("tags")]
        public async Task<IList<Ttag>> GetAllTtags() => await _manager.GetAllTtags();


        [HttpGet]
        //[Route("tags/{id:int}")]
        public async Task<Ttag> GetTtagById(int id) => await _manager.GetTtagById(id);


        [HttpGet]
        //[Route("tags/{name}")]
        public async Task<Ttag> GetTtagByName(string name) => await _manager.GetTtagByName(name);

        [HttpDelete]
        //[Route("tags/{id:int}")]
        public async Task DeleteTtag(int id) => await _manager.DeleteTtag(id);

        [HttpGet]
        [Route("tags/userId/{userId}")]
        public async Task<IList<Ttag>> GetTtagsByUser(int userId) => await _manager.GetTtagsByUser(userId);

        [HttpGet]
        [Route("tags/itemId/{itemId}")]
        public async Task<IList<Ttag>> GetTtagsByItem(int itemId) => await _manager.GetTtagsByItem(itemId);
        [HttpPost]
        public async Task<IActionResult> Create(Ttag col)
        {
            col.UserId = GlobalData.uid;
            await _manager.AddTtag(col.Name, col.UserId, col.Description);

            return RedirectToRoute(new { controller = "Tags", action = "Index" });
        }

        
    }
}
