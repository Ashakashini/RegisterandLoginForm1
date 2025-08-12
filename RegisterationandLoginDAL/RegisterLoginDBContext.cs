using Microsoft.EntityFrameworkCore;
using RegisterandLoginDAL;


namespace RegisterationandLoginDAL
{
    public class RegisterLoginDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public RegisterLoginDBContext(DbContextOptions<RegisterLoginDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Qualification>()
                .Property(q => q.Percentage)
                .HasPrecision(5, 2);
        }
    }
}
