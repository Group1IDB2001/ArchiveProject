using ArchiveLogic.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class TagController : Controller
    {
        private readonly ITtagManager _manager;

        public TagController(ITtagManager manager)
        {
            _manager = manager;
        }

        [HttpPut]
        [Route("tags")]
        public async Task AddTtag([FromBody] CreateTagRequest request) => await _manager.AddTtag(request.Name, request.UserId, request.Description);


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

        public IActionResult Index()
        {
            return View();
        }
    }
}
