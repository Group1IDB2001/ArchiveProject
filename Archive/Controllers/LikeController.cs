using ArchiveLogic.Likes;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class LikeController : Controller
    {

        private readonly ILikeManager _manager;

        public LikeController(ILikeManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> AddLikes(int id)
        {
            await _manager.AddLike(GlobalData.uid, id);
            {

            }
            return View(id);
        }

        [HttpPut]
        //[Route("likes")]
        public async Task AddLike([FromBody] CreateLikeRequest request) => await _manager.AddLike(request.UserId , request.ItemId);

        [HttpGet]
        //[Route("likes")]
        public async Task<IList<Like>> GetAllLike() => await _manager.GetAllLike();

        [HttpGet]
        //[Route("likes/userid/{userid:int}")]
        public async Task<IList<Like>> GetByUser(int userid) => await _manager.GetByUser(userid);

        [HttpGet]
        //[Route("likes/itemid/{itemid:int}")]
        public async Task<IList<Like>> GetByItem(int itemid) => await _manager.GetByItem(itemid);

        [HttpDelete]
        //[Route("likes/{userid}/{itemid}")]
        public async Task DeleteLike(int userid, int itemid) => await _manager.DeleteLike(userid, itemid);

        public IActionResult Index()
        {
            return View();
        }
    }
}
