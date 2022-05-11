using Microsoft.EntityFrameworkCore;

namespace MyNetMvcLab.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                modelBuilder.Entity<Product>().ToTable("Product")
                    .Property(p => p.Proid).ValueGeneratedOnAdd();
            });
        }
    }
}
