using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class Qestion
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        
        public int? UserId { get; set; }
        //[ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public Qestion(string text, int? userId)
        {
            Text = text;
            UserId = userId;
        }
    }
}
