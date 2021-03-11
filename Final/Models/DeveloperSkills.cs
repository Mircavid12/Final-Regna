using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class DeveloperSkills
    {
        public int id { get; set; }
        public virtual Developers Developers { get; set; }
        public int DevelopersId { get; set; }
        public virtual Skills Skills { get; set; }
        public int SkillsId { get; set; }
        public double? Percentage { get; set; }
    }
}
