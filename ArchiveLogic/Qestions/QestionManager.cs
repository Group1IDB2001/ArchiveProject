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


        public async Task AddQestion(int? userid, string text)
        {
            var user = _context.Users.FirstOrDefault(C => C.Id == userid);
            if (user == null) throw new Exception("There is not User with the same Id");

            var qestion_1 = _context.Qestiones.FirstOrDefault(n => n.UserId == userid && n.Text == text);
            if (qestion_1 == null)
            {
                var qestion = new Qestion { UserId = userid , Text = text };

                _context.Qestiones.Add(qestion);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("There is Question with the same information");
            }
        }

        public async Task<IList<Qestion>> GetAllQestion()
        {
            return await _context.Qestiones.ToListAsync();
        }

        public async Task<IList<Qestion>> GetByUser(int userid)
        {
            List<Qestion> qestions = new List<Qestion>();
            
            foreach(var qestion in _context.Qestiones)
            {
                if (qestion.UserId == userid) qestions.Add(qestion);
            }
            if(qestions.Count == 0) throw new Exception("There is not Question with the same User Id");

            return qestions;
        }

        public async Task DeleteQestion(int qestionid)
        {
            var qestion = _context.Qestiones.FirstOrDefault(q => q.Id == qestionid);
            if(qestion == null) throw new Exception("There is not Question with the same Id");
            _context.Qestiones.Remove(qestion);
            await _context.SaveChangesAsync();
        }

        public async Task EditQestion(int qestionid, string newtext)
        {
            var qestion = _context.Qestiones.FirstOrDefault(q => q.Id == qestionid);
            if (qestion == null) throw new Exception("There is not Question with the same Id");
            qestion.Text = newtext;
            await _context.SaveChangesAsync();
        }

    }
}
