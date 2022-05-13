using ArchiveLogic.Reactions;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ReactionController : Controller
    {

        private readonly IReactionManager _manager;

        public ReactionController(IReactionManager manager)
        {
            _manager = manager;
        }

        [HttpPut]
        [Route("reactions")]
        public async Task AddReaction([FromBody] CreateReactionRequest request) => await _manager.AddReaction(request.UserId, request.ItemId, request.Rating, request.Text);


        [HttpGet]
        [Route("reactions")]
        public async Task<IList<Reaction>> GetAllReactions() => await _manager.GetAllReactions();

        [HttpGet]
        [Route("reactions/itemid/{itemid}")]
        public async Task<IList<Reaction>> GetByItem(int itemid) => await _manager.GetByItem(itemid);


        [HttpGet]
        [Route("reactions/userid/{userid}")]
        public async Task<IList<Reaction>> GetByUser(int userid) => await _manager.GetByUser(userid);


        [HttpDelete]
        [Route("reactions/{reactionid}")]
        public async Task DeleteReaction(int reactionid) => await _manager.DeleteReaction(reactionid);


        [HttpPut]
        [Route("reactions/text/{reactionid}")]
        public async Task EditReactionText(int reactionid, [FromBody] CreateReactionRequest request) => await _manager.EditReactionText(reactionid, request.Text);

        [HttpPut]
        [Route("reactions/rating/{reactionid}")]
        public async Task EditReactionRating(int reactionid, [FromBody] CreateReactionRequest request) =>  await _manager.EditReactionRating(reactionid, request.Rating);

        public IActionResult Index()
        {
            return View();
        }
    }
}
