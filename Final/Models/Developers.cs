using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Developers
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Required, StringLength(150)]
        public string Profession { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateTime { get; set; }
        public DeveloperDetails developerDetails { get; set; }
        public ICollection<DeveloperSkills> DeveloperSkills { get; set; }
        public ICollection<DeveloperBios> DeveloperBios { get; set; }
        public ICollection<ServiceDevelopers> ServiceDevelopers { get; set; }
        public ICollection<PortfolioDevelopers> PortfolioDevelopers { get; set; }
    }
}
