namespace Archive.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorManager _manager;
        public AuthorsController(IAuthorManager manager)
        {
            _manager=manager;
        }

        [HttpGet]
        [Route("authors")]
        public async Task<IList<Author>> GetAllAuthors() => await _manager.GetAllAuthors();


        [HttpDelete]
        [Route("authors/{id}")]
        public Task DeleteAuthor(int id) => _manager.DeleteAuthor(id);


        [HttpGet]
        [Route("authors/{id}")]
        public async Task<Author> GetAuthorById(int id) => await _manager.GetAuthorById(id);

        [HttpPut]
        [Route("authors")]
        public async Task AddAuthor([FromBody] CreateAuthorRequest request) => await _manager.AddAuthor(request.Name, request.Born, request.Death, request.About);



        public IActionResult Index()
        {
            return View();
        }
    }
}
