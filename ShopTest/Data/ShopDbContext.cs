using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public partial class ShopDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.TotalPrice)
                .HasComputedColumnSql("Price * Count", true);

            modelBuilder.Entity<Client>()
                .Property(x => x.FullName)
                .HasComputedColumnSql("[LastName] + ' ' + [Name] +  ' ' + [Patronimic]");
            
            AddSampleData(modelBuilder);
        }
    }
}
