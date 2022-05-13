using ArchiveLogic.Saves;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveManager _manager;

        public SaveController(ISaveManager manager)
        {
            _manager = manager;
        }

        [HttpPut]
        [Route("saves")]
        public async Task AddSaved([FromBody] CreateSaveRequest request) => await _manager.AddSaved(request.UserId, request.CollectionId);

        [HttpGet]
        [Route("saves")]
        public async Task<IList<Saved>> GetAllSaves() => await _manager.GetAllSaves();

        [HttpGet]
        [Route("saves/userid/{userid}")]
        public async Task<IList<Saved>> GetSavedByUser(int userid) => await _manager.GetSavedByUser(userid);


        [HttpGet]
        [Route("saves/collectionid/{collectionid}")]
        public async Task<IList<Saved>> GetSavedByCollection(int collectionid) => await _manager.GetSavedByCollection(collectionid);

        [HttpDelete]
        [Route("saves/{userId}/{collectionid}")]
        public async Task DeleteSaved(int userId, int collectionId) => await _manager.DeleteSaved(userId, collectionId);




        public IActionResult Index()
        {
            return View();
        }
    }
}
