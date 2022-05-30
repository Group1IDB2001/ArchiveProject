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
        Task<bool> FindResponse(int? userid, int? qestionid);
        Task<IList<Response>> GetResponseByQestion(int qestionid);
    }
}
