using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public class ShopDbContext : DbContext
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

            var clients = new List<Client>()
            {
                new Client
                {
                    Id = -1,
                    Name = "John",
                    LastName = "Doe",
                    Patronimic = "Smith",
                    BirthDate = new DateTime(1980, 5, 15),
                    RegistrationDate = new DateTime(2020, 2, 10)
                },
                new Client
                {
                    Id = -2,
                    Name = "Jane",
                    LastName = "Smith",
                    Patronimic = "Johnson",
                    BirthDate = new DateTime(1992, 9, 22),
                    RegistrationDate = new DateTime(2018, 7, 5)
                },
                new Client
                {
                    Id = -3,
                    Name = "Alice",
                    LastName = "Johnson",
                    Patronimic = "Brown",
                    BirthDate = new DateTime(1975, 12, 7),
                    RegistrationDate = new DateTime(2015, 3, 18)
                }
            };
            modelBuilder.Entity<Client>()
                .HasData(clients);
        }
    }
}
