using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveStorage.Entities
{
    public class TTag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public TTag(string name, int userId,string? description)
        {
            Name = name;
            UserId = userId;
            Description = description;
        }
    }
}
