using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public partial class ShopDbContext
    {
        private void AddSampleData(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category { Id = -1, Name = "Electronics" },
                new Category { Id = -2, Name = "Clothing" },
                new Category { Id = -3, Name = "Books" },
            };

            var clients = new List<Client>
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
                // Add more clients with negative Id values as needed
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = -1,
                    Name = "Smartphone",
                    Price = 599.99,
                    Count = 100,
                    Category = categories[0] // Electronics
                },
                new Product
                {
                    Id = -2,
                    Name = "T-Shirt",
                    Price = 19.99,
                    Count = 500,
                    Category = categories[1] // Clothing
                },
                new Product
                {
                    Id = -3,
                    Name = "Laptop",
                    Price = 999.99,
                    Count = 50,
                    Category = categories[0] // Electronics
                },
                new Product
                {
                    Id = -4,
                    Name = "Science Fiction Book",
                    Price = 29.99,
                    Count = 200,
                    Category = categories[2] // Books
                }
                // Add more products with negative Id values as needed
            };

            var purchases = new List<Purchase>
            {
                new Purchase
                {
                    Id = -1,
                    Date = new DateTime(2023, 3, 15),
                    Products = new List<Product>
                    {
                        products[0], // Smartphone
                        products[1] // T-Shirt
                    }
                },
                new Purchase
                {
                    Id = -2,
                    Date = new DateTime(2023, 4, 20),
                    Products = new List<Product>
                    {
                        products[2], // Laptop
                        products[3] // Science Fiction Book
                    }
                },
                new Purchase
                {
                    Id = -3,
                    Date = new DateTime(2023, 5, 10),
                    Products = new List<Product>
                    {
                        products[0], // Smartphone
                        products[1], // T-Shirt
                        products[2]  // Laptop
                    }
                },
                new Purchase
                {
                    Id = -4,
                    Date = new DateTime(2023, 6, 5),
                    Products = new List<Product>
                    {
                        products[3], // Science Fiction Book
                        products[1] // T-Shirt
                    }
                }               
            };

            modelBuilder.Entity<Client>()
                .HasData(clients);
            modelBuilder.Entity<Purchase>()
                .HasData(purchases);
            modelBuilder.Entity<Category>()
                .HasData(categories);
            modelBuilder.Entity<Product>()
                .HasData(Products);
        }
    }
}
