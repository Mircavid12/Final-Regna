using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class DeveloperDetails
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Degree { get; set; }
        public string experience { get; set; }
        public string hobbies { get; set; }
        public string faculty { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Developers")]
        public int DeveloperId { get; set; }
        public virtual Developers Developers { get; set; }
        public ICollection<ContactInfos> ContactInfos { get; set; }
    }
}
