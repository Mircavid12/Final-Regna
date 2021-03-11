using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ServiceDevelopers
    {
        public int Id { get; set; }
        public virtual Developers Developers { get; set; }
        public int DevelopersId { get; set; }
        public virtual Services Services { get; set; }
        public int ServicesId { get; set; }
    }
}
