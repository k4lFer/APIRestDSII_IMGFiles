using _5._0.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5._0.DataAccessLayer.Connection
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Gallery> Gallerys { get; set; }

        public DataBaseContext()
        {
            InitAutoMapper.start();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gallery>().ToTable("tgallery");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-83BGGDU\\SQLEXPRESS;Database=dbCrudGallery;User Id=N3kr;Password=@prkal3;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}