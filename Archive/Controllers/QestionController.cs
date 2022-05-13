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
