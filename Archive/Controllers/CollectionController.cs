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
        [HttpGet]
        [Route("collection")]
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
        //
        public async Task<IActionResult> CollectionsPage()
        {

            var col = await _manager.GetCollectionsByUsreId(GlobalData.uid);
            return View(col);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPut]
        
        public async Task AddCollection([FromBody] CreateCollectionRequest request) => await _manager.AddCollection(request.Name, request.Description, request.UserId);


        [HttpGet]
        //[Route("collections")]
        public async Task<IList<Collection>> GetAllCollection() => await _manager.GetAllCollection();

        [HttpGet]
        //[Route("collections/{id:int}")]
        public async Task<Collection> GetCollectionById(int id) => await _manager.GetCollectionById(id);

        [HttpGet]
        //[Route("collections/{name}")]
        public async Task<Collection> GetCollectionByName(string name) => await _manager.GetCollectionByName(name);

        [HttpGet]
        //[Route("collections/userid/{usreid:int}")]
        public async Task<IList<Collection>> GetCollectionsByUsreId(int usreid) => await _manager.GetCollectionsByUsreId(usreid);






        [HttpPut]
        //[Route("collections/name/{id}")]
        public async Task EditCollectionName(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionName(id, request.Name);

        [HttpPut]
        //[Route("collections/description/{id}")]
        public async Task EditCollectionDescription(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionDescription(id, request.Description);

        [HttpPut]
        //[Route("collections/userid/{id}")]
        public async Task EditCollectionUserId(int id, [FromBody] CreateCollectionRequest request) => await _manager.EditCollectionUserId(id, request.UserId);

        [HttpDelete]
        //[Route("collections/{id:int}")]
        public async Task DeleteCollection(int id) => await _manager.DeleteCollection(id);

        [HttpPost]
        public async Task<IActionResult> Create(Collection col)
        {
            col.UserId = GlobalData.uid;
            await _manager.AddCollection(col.Name, col.Description, col.UserId);

            return RedirectToRoute(new { controller = "Collection", action = "CollectionsPage" });
        }



    }
}
