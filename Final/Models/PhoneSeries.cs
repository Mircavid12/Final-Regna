using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PhoneSeries
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public bool isDeleted { get; set; }
    }
}
