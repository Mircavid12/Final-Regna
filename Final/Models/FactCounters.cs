using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class FactCounters
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        public string Count { get; set; }
        public bool IsDeleted { get; set; }

    }
}
