using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Responses
{
    public interface IResponseManager
    {
        Task<bool> AddResponse(int? userid, int? qestionid, string text, int? itemid, int? collectionid);
        Task<bool> FindResponse(string name, int born);



        Task<IList<Response>> GetAllResponse();
        Task<IList<Response>> GetResponseByUser(int userid);
        Task<IList<Response>> GetResponseByQestion(int qestionid);
        Task DeleteResponse(int responseId);





        Task EditResponse (int responseId,string newtext,int? itemId,int? collectionId);
        Task EditResponseText(int responseId, string newtext);
        Task EditResponseItem(int responseId,int? itemId);
        Task EditResponseCollection(int responseId,int? collectionId);



    }
}
