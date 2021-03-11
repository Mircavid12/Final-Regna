using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PortfolioNavRelations
    {
        public int Id { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
        public virtual PortfolioNav PortfolioNav { get; set; }
        public int PortfolioNavId { get; set; }
    }
}
