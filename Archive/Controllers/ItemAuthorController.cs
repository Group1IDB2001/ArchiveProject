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


        public IActionResult Index()
        {
            return View();
        }
    }
}
