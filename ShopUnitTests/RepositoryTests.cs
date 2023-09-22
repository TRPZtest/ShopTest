using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;
using ShopTest.Controllers;
using ShopTest.Data;
using ShopTest.Data.Entities;
using System;
using Xunit;

namespace ShopUnitTests
{ 
    public class RepositoryTests
    {
        [Fact]
        public async Task TwoClientsWithSameBirtDate()
        {
            var shopContextMock = new Mock<ShopDbContext>();
            shopContextMock.Setup<DbSet<Client>>(x => x.Clients)
                .ReturnsDbSet(TestDataHelper.GetMockClients());

            var shopRepository = new ShopRepository(shopContextMock.Object);

            var clients = await shopRepository.GetCLientsByDirthDate(DateTime.Parse("1990, 03, 15").AddHours(2));

            Assert.AreEqual(2, clients.Count);
        }

        
    }
}