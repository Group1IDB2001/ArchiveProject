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
            var newlike = await _manager.AddLike(GlobalData.uid, id);
            return View(id);
        }

        public async Task<IActionResult> UserLike()
        {
            GlobalData.ids.Clear();
            var It = await _manager.GetByUser(GlobalData.uid);
            if(It == null)
            {
                return Redirect("/Items/ItemsIn");
            }
            else
            {
                foreach (var item in It)
                GlobalData.ids.Add((int)item.ItemId);
                return Redirect("/Items/ItemsIn");
            }
                

        }
    }
}
