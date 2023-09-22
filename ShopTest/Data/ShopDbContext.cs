using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public class ShopDbContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public ShopDbContext() { }
       
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Product>()
                .Property(x => x.TotalPrice)
                .HasComputedColumnSql("Price * Count", true);

            modelBuilder.Entity<Client>()
                .Property(x => x.FullName)
                .HasComputedColumnSql("[LastName] + ' ' + [Name] +  ' ' + [Patronimic]");                        
        }
    }
}
