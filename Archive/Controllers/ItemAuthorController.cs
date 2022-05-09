using ArchiveLogic;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ItemAuthorController : Controller
    {
        private readonly IItemAuthorManager _manager;

        public ItemAuthorController(IItemAuthorManager manager)
        {
            _manager = manager;
        }
        [HttpPut]
        [Route("itemauthors")]
        public async Task AddItemAuthor([FromBody] CreateItemAuthorRequest request)=> await _manager.AddItemAuthor(request.AuthorId ,request.ItemId);

        [HttpGet]
        [Route("itemauthors")]
        public async Task<IList<ItemAuthor>> GetAllItemAuthors() => await _manager.GetAllItemAuthors();


        [HttpPut]
        [Route("itemauthors/itemid/{id:int}")]
        public async Task EditItemid(int id, [FromBody] CreateItemAuthorRequest request) => await _manager.EditItemid(id,request.ItemId);

        [HttpPut]
        [Route("itemauthors/authorid/{id:int}")]
        public async Task EditAuthorId(int id, [FromBody] CreateItemAuthorRequest request) => await _manager.EditAuthorId(id,request.AuthorId);


        public IActionResult Index()
        {
            return View();
        }
    }
}
