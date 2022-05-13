using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Qestions
{
    public interface IQestionManager
    {
        Task AddQestion(int? userid, string text);
        Task<IList<Qestion>> GetAllQestion();
        Task<IList<Qestion>> GetByUser(int userid);
        Task DeleteQestion(int qestionid);
        Task EditQestion (int qestionid,string newtext);
        
    }
}
