using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Responses
{
    public class ResponseManager:IResponseManager
    {
        private readonly ArchiveContext _context;
        public ResponseManager(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<bool> AddResponse(int? userid, int? qestionid, string text, int? itemid, int? collectionid)
        {
            if( itemid != null)
            {
                var item = _context.Items.FirstOrDefault(C => C.Id == itemid);
                if (item == null) return false;
            }
            if (collectionid != null)
            {
                var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == collectionid);
                if (collection == null) return false;
            }

            var response_1 = _context.Responses.FirstOrDefault(n => n.UserId == userid && n.QestionId == qestionid);
            if (response_1 == null)
            {
                var response = new Response { UserId = userid , QestionId = qestionid , Text = text , ItemId = itemid , CollectionId = collectionid };
                _context.Responses.Add(response);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

           
        }
        public async Task<bool> FindResponse(int? userid, int? qestionid)
        {
            var respo = await _context.Responses.FirstOrDefaultAsync(g => g.UserId == userid && g.QestionId == qestionid);
            if (respo != null) return true;
            else return false;
        }
        public async Task<IList<Response>> GetResponseByQestion(int qestionid)
        {
            List<Response> responses = new List<Response>();

            foreach (var response in _context.Responses)
            {
                if (response.QestionId == qestionid) responses.Add(response);
            }
            if (responses.Count == 0) responses = null;

            return responses;
        }
    }
}
