using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required,StringLength(100)]
        public string Address { get; set; }
        [Required, StringLength(100)]
        public string Mail { get; set; }
        [Required, StringLength(100)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
