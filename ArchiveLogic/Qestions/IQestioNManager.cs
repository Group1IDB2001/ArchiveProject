using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Qestions
{
    public interface IQestioNManager
    {
        Task AddQestion(int userId, string text);
        Task DeleteQestion(int qestionId);
        Task EditQestion (int qestionId,string newtext);
        Task<IList<Qestion>> GetByUser (int userId);
    }
}
