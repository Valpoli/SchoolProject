using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Classe> Classes { get; set; }


    }

    
}