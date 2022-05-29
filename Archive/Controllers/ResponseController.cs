using ArchiveLogic.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IResponseManager _manager;

        public ResponseController(IResponseManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index(int id,int pg = 1)
        {
            var items = await _manager.GetResponseByQestion(id);
            GlobalData.qid = id;
            int counter = items.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }


        public IActionResult Create(int id)
        {
            GlobalData.qid = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Response response)
        {

                response.UserId = GlobalData.uid;
                response.QestionId = GlobalData.qid;
                var respo = await _manager.AddResponse(response.UserId, response.QestionId, response.Text, response.ItemId,response.CollectionId);
                if (respo)
                    return RedirectToRoute(new { controller = "Qestion", action = "Index" });
            else
                {
                    var respo_1 = await _manager.FindResponse(response.UserId, response.QestionId);
                    if (respo_1) ModelState.AddModelError("", "Response is already existing");
                }
            return View();
        }

       
        
    }
}
