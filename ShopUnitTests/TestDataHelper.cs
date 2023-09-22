using ShopTest.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopUnitTests
{
    public class TestDataHelper
    {
        public static List<Client> GetMockClients()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "John",
                    LastName = "Doe",
                    Patronimic = "A.",
                    BirthDate = new DateTime(1990, 03, 15),
                    RegistrationDate = DateTime.Now
                },
                new Client
                {
                    Id = 2,
                    Name = "Alice",
                    LastName = "Smith",
                    Patronimic = "B.",
                    BirthDate = new DateTime(1985, 07, 10),
                    RegistrationDate = DateTime.Now
                },
                new Client
                {
                    Id = 3,
                    Name = "Bob",
                    LastName = "Johnson",
                    Patronimic = "C.",
                    BirthDate = new DateTime(1992, 11, 28),
                    RegistrationDate = DateTime.Now
                },
                new Client
                {
                    Id = 4,
                    Name = "Emma",
                    LastName = "Davis",
                    Patronimic = "D.",
                    BirthDate = new DateTime(1990, 03, 15), // Same birthdate as Client 1
                    RegistrationDate = DateTime.Now
                },
                new Client
                {
                    Id = 5,
                    Name = "Michael",
                    LastName = "Wilson",
                    Patronimic = "E.",
                    BirthDate = new DateTime(1988, 09, 05),
                    RegistrationDate = DateTime.Now
                }
            };

            return clients;
        }
       
    }
}
