using Final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Intro> Intros { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutDetail> AboutDetails { get; set; }
        public DbSet<Facts> Facts { get; set; }
        public DbSet<FactCounters> FactCounters { get; set; }
        public DbSet<Parallax> Parallaxes { get; set; }
        public DbSet<Developers> Developers { get; set; }
        public DbSet<DeveloperDetails> DeveloperDetails { get; set; }
        public DbSet<DeveloperSkills> DeveloperSkills { get; set; }
        public DbSet<DeveloperBios> DeveloperBios { get; set; }
        public DbSet<ContactInfos> ContactInfos { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioNav> PortfolioNavs { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Apply> Applies { get; set; }
        public DbSet<PortfolioImages> PortfolioImages { get; set; }
        public DbSet<ApplyNumberSerie> ApplyNumberSeries { get; set; }
        public DbSet<PhoneSeries> PhoneSeries { get; set; }
        public DbSet<ServiceDevelopers> ServiceDevelopers { get; set; }
    }
}
