using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Qestions
{
    public interface IQestionManager
    {
        Task<bool> AddQestion(int? userid, string text);
        Task<bool> FindQestion(int? userid, string text);
        Task<IList<Qestion>> GetAllQestion();
        
    }
}
