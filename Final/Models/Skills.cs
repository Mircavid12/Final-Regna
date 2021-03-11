using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Skills
    {
        public int id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
        public ICollection<DeveloperSkills> DeveloperSkills { get; set; }
    }
}
