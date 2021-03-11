using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PortfolioNav
    {
        public int Id { get; set; }
        [Required,StringLength(15)]
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public ICollection<PortfolioNavRelations> PortfolioNavRelations { get; set; }

    }
}
