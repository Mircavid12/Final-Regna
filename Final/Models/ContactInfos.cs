using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class ContactInfos
    {
        public int id { get; set; }
        public string Mail { get; set; }
        public string Number { get; set; }
        public string Skype { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public virtual DeveloperDetails DeveloperDetails { get; set; }
        public int DeveloperDetailsId { get; set; }
    }
}
