using ArchiveLogic.Qestions;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class QestionController : Controller
    {

        private readonly IQestionManager _manager;

        public QestionController(IQestionManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index(int pg = 1)
        {
            var items = await _manager.GetAllQestion();
            int counter = items.Count();
            const int pagesize = 12;
            if (pg < 1) pg = 1;

            var pager = new Pager(counter, pg, pagesize);

            int recSkip = (pg - 1) * pagesize;

            var data = items.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            return View(data);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Qestion qestion)
        {
            qestion.UserId = GlobalData.uid;
            var ques = await _manager.AddQestion(qestion.UserId, qestion.Text);
            if (ques)
                return Redirect("Index");
            else
            {
                var ques_1 = await _manager.FindQestion(qestion.UserId, qestion.Text);
                if (ques_1) ModelState.AddModelError("", "Вопрос уже существует");
            }
            return View();
        }

    }
}
