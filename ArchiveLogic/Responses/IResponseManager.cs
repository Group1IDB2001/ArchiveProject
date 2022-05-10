using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Responses
{
    public interface IResponseManager
    {
        Task AddResponse(int userId, int qestionId, string text);
        Task AddResponse(int userId, int qestionId, string text,int itemId,int collectionId);
        Task DeleteResponse(int responseId);
        Task EditResponse (int responseId,string newtext,int? itemId,int? collectionId);
        Task<IList<Response>> GetResponseByUser(int userId);
        Task<IList<Response>> GetResponseByQestion(int qestionId);
        

    }
}
