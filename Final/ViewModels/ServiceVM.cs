using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.ViewModels
{
    public class ServiceVM
    {
        public List<Services> Services { get; set; }
        public List<Developers> Developers { get; set; }
        public ServiceDetails ServiceDetails { get; set; }

    }
}
