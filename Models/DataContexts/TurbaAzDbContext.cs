using Microsoft.EntityFrameworkCore;
using TurboAzORM.Models.Entities;

namespace TurboAzORM.Models.DataContexts
{
    public class TurbaAzDbContext : DbContext
    {
        public TurbaAzDbContext()
            : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Database=TurbaAzProjectInAcedemy;User Id=sa;Password=!Dquery20@4;Encrypt=false;App=Orm");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TurbaAzDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> models { get; set; }
        public DbSet<Announcement> announcements { get; set; }
    }
}
