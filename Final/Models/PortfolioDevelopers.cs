using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PortfolioDevelopers
    {
        public int Id { get; set; }
        public virtual Developers Developers { get; set; }
        public int DevelopersId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
