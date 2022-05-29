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

        [HttpGet]
        [Route("qestions")]
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


        [HttpPut]
        [Route("questions")]
        public async Task AddQestion([FromBody] CreateQestionRequest request) => await _manager.AddQestion(request.UserId, request.Text);

        [HttpGet]
        [Route("questions")]
        public async Task<IList<Qestion>> GetAllQestion() => await _manager.GetAllQestion();

        [HttpGet]
        [Route("questions/{userid:int}")]
        public async Task<IList<Qestion>> GetByUser(int userid) => await _manager.GetByUser(userid);

        [HttpDelete]
        [Route("questions/{qestionid:int}")]
        public async Task DeleteQestion(int qestionid) => await _manager.DeleteQestion(qestionid);

        [HttpPut]
        [Route("questions/qestionid/{qestionid:int}")]
        public async Task EditQestion(int qestionid, [FromBody] CreateQestionRequest request) => await _manager.EditQestion(qestionid,request.Text);

        public IActionResult Index()
        {
            return View();
        }
    }
}
