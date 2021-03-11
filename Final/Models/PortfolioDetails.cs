using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PortfolioDetails
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateTime { get; set; }
        [ForeignKey("Portfolio")]
        public int PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
