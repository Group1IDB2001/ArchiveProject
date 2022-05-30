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


            //if(qestion.UserId == userid) throw new Exception("Can not respond to yourself");

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








        public async Task<IList<Response>> GetAllResponse()
        {
            return await _context.Responses.ToListAsync();
        }
        
        public async Task<IList<Response>> GetResponseByUser(int userid)
        {
            List<Response> responses = new List<Response>();

            foreach (var response in _context.Responses)
            {
                if (response.UserId == userid) responses.Add(response);
            }
            if (responses.Count == 0) throw new Exception("There is not Response with the same User Id");

            return responses;
        }
        
        

        public async Task DeleteResponse(int responseId)
        {
            var response = _context.Responses.SingleOrDefault( r => r.Id == responseId);
            if(response == null) throw new Exception("There is not Response with the same Id");
            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();
        }




        public async Task EditResponse(int responseId, string newtext, int? itemId, int? collectionId)
        {
            var response = _context.Responses.SingleOrDefault(r => r.Id == responseId);
            if (response == null) throw new Exception("There is not Response with the same Id");

            var item = _context.Items.FirstOrDefault(C => C.Id == itemId);
            if (item == null) throw new Exception("There is not Item with the same Id");

            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == collectionId);
            if (collection == null) throw new Exception("There is not collection with the same Id");

            response.Text = newtext;
            response.ItemId= itemId;
            response.CollectionId= collectionId;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditResponseText(int responseId, string newtext)
        {
            var response = _context.Responses.SingleOrDefault(r => r.Id == responseId);
            if (response == null) throw new Exception("There is not Response with the same Id");
            response.Text = newtext;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditResponseItem(int responseId, int? itemId)
        {
            var response = _context.Responses.SingleOrDefault(r => r.Id == responseId);
            if (response == null) throw new Exception("There is not Response with the same Id");

            var item = _context.Items.FirstOrDefault(C => C.Id == itemId);
            if (item == null) throw new Exception("There is not Item with the same Id");

            response.ItemId = itemId;
            await _context.SaveChangesAsync();
        }
        
        public async Task EditResponseCollection(int responseId, int? collectionId)
        {
            var response = _context.Responses.SingleOrDefault(r => r.Id == responseId);
            if (response == null) throw new Exception("There is not Response with the same Id");

            var collection = await _context.Collections.FirstOrDefaultAsync(g => g.Id == collectionId);
            if (collection == null) throw new Exception("There is not collection with the same Id");

            response.CollectionId = collectionId;
            await _context.SaveChangesAsync();
        }
    }
}
