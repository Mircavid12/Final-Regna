using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Apply
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string FirstName { get; set; }
        [Required,StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Service { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ApplyNumberSerie> ApplyNumberSeries { get; set; }
    }
}
