using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Email
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Service { get; set; }
        [Required]
        public string PhoneSerie { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
