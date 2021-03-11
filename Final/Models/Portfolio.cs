using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Required,StringLength(15)]
        public string Category { get; set; }
        [Required, StringLength(20)]
        public string Folder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public PortfolioDetails PortfolioDetails { get; set; }
        public ICollection<PortfolioImages> PortfolioImages { get; set; }
        public ICollection<PortfolioNavRelations> PortfolioNavRelations { get; set; }
        public ICollection<PortfolioDevelopers> PortfolioDevelopers { get; set; }


    }
}
