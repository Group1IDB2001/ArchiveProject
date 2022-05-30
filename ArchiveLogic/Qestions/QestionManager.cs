using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Qestions
{
    public class QestionManager : IQestionManager
    {
        private readonly ArchiveContext _context;
        public QestionManager(ArchiveContext context)
        {
            _context = context;
        }


        public async Task<bool> AddQestion(int? userid, string text)
        {
            var user = _context.Users.FirstOrDefault(C => C.Id == userid);
            if (user == null) return false;

            var qestion_1 = _context.Qestiones.FirstOrDefault(n => n.UserId == userid && n.Text == text);
            if (qestion_1 == null)
            {
                var qestion = new Qestion { UserId = userid , Text = text };

                _context.Qestiones.Add(qestion);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> FindQestion(int? userid, string text)
        {
            var qestion = _context.Qestiones.FirstOrDefault(n => n.UserId == userid && n.Text == text);
            if (qestion == null) return false;
            else return true;
        }
        public async Task<IList<Qestion>> GetAllQestion()
        {
            return await _context.Qestiones.ToListAsync();
        }

    }
}
