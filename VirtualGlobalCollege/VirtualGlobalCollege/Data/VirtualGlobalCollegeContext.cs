using Microsoft.EntityFrameworkCore;
using VirtualGlobalCollege.Models;

namespace VirtualGlobalCollege.Data
{
    public class VirtualGlobalCollegeContext : DbContext
    {
        public VirtualGlobalCollegeContext(DbContextOptions<VirtualGlobalCollegeContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
