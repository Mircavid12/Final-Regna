using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class HomeVM
    {
        public Intro Intro { get; set; }
        public About About { get; set; }
        public List<AboutDetail> AboutDetails { get; set; }
        public Facts Facts { get; set; }
        public List<FactCounters> FactCounters { get; set; }
        public List<Services> Services { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<Developers> Developers { get; set; }
        public List<PortfolioImages> PortfolioImages { get; set; }
        public Parallax Parallax { get; set; }
    }
}
