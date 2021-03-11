using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class AboutDetail
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsDeleted { get; set; }
    }
}
