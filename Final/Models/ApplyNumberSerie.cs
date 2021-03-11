using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ApplyNumberSerie
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateTime { get; set; }
        public virtual Apply Apply { get; set; }
        public int ApplyId { get; set; }
    }
}
