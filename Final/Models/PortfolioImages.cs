using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class PortfolioImages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedTime { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
