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

        [HttpPut]
        [Route("collections")]
        public async Task AddCollection([FromBody] CreateCollectionRequest request) => await _manager.AddCollection(request.Name, request.Description, request.UserId);


        [HttpGet]
        [Route("collections")]
        public async Task<IList<Collection>> GetAllCollection() => await _manager.GetAllCollection();

        [HttpGet]
        [Route("collections/{id:int}")]
        public async Task<Collection> GetCollectionById(int id) => await _manager.GetCollectionById(id);

        [HttpGet]
        [Route("collections/{name}")]
        public async Task<Collection> GetCollectionByName(string name) => await _manager.GetCollectionByName(name);

        [HttpGet]
        [Route("collections/userid/{usreid:int}")]
        public async Task<IList<Collection>> GetCollectionsByUsreId(int usreid) => await _manager.GetCollectionsByUsreId(usreid);






        [HttpPut]
        [Route("collections/name/{id}")]
        public async Task EditCollectionName(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionName(id, request.Name);

        [HttpPut]
        [Route("collections/description/{id}")]
        public async Task EditCollectionDescription(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionDescription(id, request.Description);

        [HttpPut]
        [Route("collections/userid/{id}")]
        public async Task EditCollectionUserId(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionUserId(id, request.UserId);

        [HttpDelete]
        [Route("collections/{id:int}")]
        public async Task DeleteCollection(int id) => await _manager.DeleteCollection(id);



        public IActionResult Index()
        {
            return View();
        }
    }
}
