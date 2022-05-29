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


        public async Task<IActionResult> Index(int id, int pg = 1)
        {
            var reactions = await _manager.GetByItem(id);

            if (reactions == null)
            {
                GlobalData.iid = id;
                return View(reactions);
            }
            else
            {
                GlobalData.iid = id;

                int counter = reactions.Count();

                const int pagesize = 12;

                if (pg < 1) pg = 1;

                var pager = new Pager(counter, pg, pagesize);

                int recSkip = (pg - 1) * pagesize;

                var data = reactions.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

        }

        public IActionResult Create(int id)
        {
            GlobalData.iid = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reaction reaction)
        {

            reaction.UserId = GlobalData.uid;
            reaction.ItemId = GlobalData.iid;
            var reac = await _manager.AddReaction(reaction.UserId, reaction.ItemId, reaction.Rating, reaction.Text);
            if (reac)
                return RedirectToAction("Index", new { Id = reaction.ItemId });
            else
            {
                var reac_1 = await _manager.FindReaction(reaction.UserId, reaction.ItemId);
                if (reac_1) ModelState.AddModelError("", "Reaction is already existing,No more than one can be added");
            }
            return View();
        }




    }
}
