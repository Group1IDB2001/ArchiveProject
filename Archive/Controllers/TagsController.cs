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

        [HttpPut]
        [Route("TagPage")]
        public async Task AddTtag([FromBody] CreateTagRequest request) => await _manager.AddTtag(request.Name, request.UserId, request.Description);
        public async Task<IActionResult> TagPage(int id)
        {
            var tags = await _manager.GetTtagsByItem(id);

           

            return View(tags);
        }

        [HttpGet]
        [Route("tags")]
        public async Task<IList<Ttag>> GetAllTtags() => await _manager.GetAllTtags();


        [HttpGet]
        [Route("tags/{id:int}")]
        public async Task<Ttag> GetTtagById(int id) => await _manager.GetTtagById(id);


        [HttpGet]
        [Route("tags/{name}")]
        public async Task<Ttag> GetTtagByName(string name) => await _manager.GetTtagByName(name);

        [HttpDelete]
        [Route("tags/{id:int}")]
        public async Task DeleteTtag(int id) => await _manager.DeleteTtag(id);

        [HttpGet]
        [Route("tags/userId/{userId}")]
        public async Task<IList<Ttag>> GetTtagsByUser(int userId) => await _manager.GetTtagsByUser(userId);

        [HttpGet]
        [Route("tags/itemId/{itemId}")]
        public async Task<IList<Ttag>> GetTtagsByItem(int itemId) => await _manager.GetTtagsByItem(itemId);

        public IActionResult Index()
        {
            return View();
        }
    }
}
