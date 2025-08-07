using Microsoft.EntityFrameworkCore;
using RegisterandLoginForm.Models;
using System.Collections.Generic;


namespace RegisterandLoginForm.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        
        public DbSet<Qualification> Qualifications { get; set; }
    }
}
