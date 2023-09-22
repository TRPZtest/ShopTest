using ShopTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopModuleTests
{
    public class TestDataHelper
    {
        public static List<Client> GetMockClients()
        {
            var electronicsCategory = new Category { Id = 1, Name = "Electronics" };
            var clothingCategory = new Category { Id = 2, Name = "Clothing" };
            var booksCategory = new Category { Id = 3, Name = "Books" };
            var furnitureCategory = new Category { Id = 4, Name = "Furniture" };
            var sportsEquipmentCategory = new Category { Id = 5, Name = "Sports Equipment" };

            // Create products
            var smartphone = new Product
            {
                Id = 1,
                Name = "Smartphone",
                Price = 900,
                Count = 10,
                Category = electronicsCategory
            };

            var smartwatch = new Product
            {
                Id = 2,
                Name = "SmartWatch",
                Price = 500,
                Count = 20,
                Category = electronicsCategory
            };

            var tShirt = new Product
            {
                Id = 3,
                Name = "T-Shirt",
                Price = 20,
                Count = 50,
                Category = clothingCategory
            };

            var jeans = new Product
            {
                Id = 4,
                Name = "Jeans",
                Price = 40,
                Count = 30,
                Category = clothingCategory
            };

            var scienceFictionBook = new Product
            {
                Id = 5,
                Name = "Science Fiction Book",
                Price = 30,
                Count = 25,
                Category = booksCategory
            };

            var sofa = new Product
            {
                Id = 6,
                Name = "Sofa",
                Price = 500,
                Count = 15,
                Category = furnitureCategory
            };

            var basketball = new Product
            {
                Id = 7,
                Name = "Basketball",
                Price = 25,
                Count = 40,
                Category = sportsEquipmentCategory
            };

            // Create purchases for each client
            var clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Patronimic = "A.",
                    BirthDate = new DateTime(1990, 03, 15),
                    RegistrationDate = DateTime.Now,
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            Id = 1,
                            Date = DateTime.Now.AddDays(-1),
                            Products = new List<Product> { smartphone, tShirt }
                        },
                        new Purchase
                        {
                            Id = 2,
                            Date = DateTime.Now.AddDays(-10),
                            Products = new List<Product> { smartwatch }
                        }
                    }
                },
                new Client
                {
                    Id = 2,
                    Name = "Alice",
                    LastName = "Smith",
                    Patronimic = "B.",
                    BirthDate = new DateTime(1985, 07, 10),
                    RegistrationDate = DateTime.Now,
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            Id = 3,
                            Date = DateTime.Now.AddDays(-5),
                            Products = new List<Product> { tShirt, jeans }
                        }
                    }
                },
                new Client
                {
                    Id = 3,
                    Name = "Bob",
                    LastName = "Johnson",
                    Patronimic = "C.",
                    BirthDate = new DateTime(1992, 11, 28),
                    RegistrationDate = DateTime.Now,
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            Id = 4,
                            Date = DateTime.Now.AddDays(0),
                            Products = new List<Product> { scienceFictionBook }
                        }
                    }
                },
                new Client
                {
                    Id = 4,
                    Name = "Emma",
                    LastName = "Davis",
                    Patronimic = "D.",
                    BirthDate = new DateTime(1990, 03, 15),
                    RegistrationDate = DateTime.Now,
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            Id = 5,
                            Date = DateTime.Now.AddDays(-3),
                            Products = new List<Product> { sofa }
                        }
                    }
                },
                new Client
                {
                    Id = 5,
                    Name = "Michael",
                    LastName = "Wilson",
                    Patronimic = "E.",
                    BirthDate = new DateTime(1988, 09, 05),
                    RegistrationDate = DateTime.Now,
                    Purchases = new List<Purchase>
                    {
                        new Purchase
                        {
                            Id = 6,
                            Date = DateTime.Now.AddDays(-2),
                            Products = new List<Product> { basketball }
                        }
                    }
                }
            };

            return clients;
        }

        public static List<Purchase> GetMockPurchases()
        {
            var clients = GetMockClients();

            return clients.SelectMany(x => x.Purchases).ToList();
        }

    }
}
