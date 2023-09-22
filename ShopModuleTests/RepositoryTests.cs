using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using ShopTest.Controllers;
using ShopTest.Data;
using ShopTest.Data.Entities;
using System;
using Xunit;

namespace ShopModuleTests
{ 
    public class RepositoryTests
    {
        [Fact]
        public async Task TwoClientsWithSameBirthDate()
        {
            var shopContextMock = new Mock<ShopDbContext>();
            shopContextMock.Setup<DbSet<Client>>(x => x.Clients)
                .ReturnsDbSet(TestDataHelper.GetMockClients());

            var shopRepository = new ShopRepository(shopContextMock.Object);

            var clients = await shopRepository.GetCLientsByDirthDate(DateTime.Parse("1990, 03, 15").AddHours(2)); //addHours tests comparing dateOnly

            Assert.Equal(2, clients.Count);
        }

        [Fact]
        public async Task ThreeCustomersForTwoLastDays()
        {
            var shopContextMock = new Mock<ShopDbContext>();
            shopContextMock.Setup<DbSet<Client>>(x => x.Clients)
                .ReturnsDbSet(TestDataHelper.GetMockClients());
            shopContextMock.Setup<DbSet<Purchase>>(x => x.Purchases)
                .ReturnsDbSet(TestDataHelper.GetMockPurchases());

            var shopRepository = new ShopRepository(shopContextMock.Object);

            var clients = await shopRepository.GetLastClients(2);

            Assert.Equal(3, clients.Count);
        }

        [Fact]
        public async Task ThreeProductsClient() //clientId = 2
        {
            var shopContextMock = new Mock<ShopDbContext>();
            shopContextMock.Setup<DbSet<Client>>(x => x.Clients)
                .ReturnsDbSet(TestDataHelper.GetMockClients());

            var shopRepository = new ShopRepository(shopContextMock.Object);

            var products = await shopRepository.GetProductsByClientId(1);

            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async Task CheckCategoriesFrequency() //clientId = 2
        {
            var shopContextMock = new Mock<ShopDbContext>();
            shopContextMock.Setup<DbSet<Client>>(x => x.Clients)
                .ReturnsDbSet(TestDataHelper.GetMockClients());

            var shopRepository = new ShopRepository(shopContextMock.Object);

            var products = await shopRepository.GetCategoriesFrequencyByClientId(1);

            Assert.Equal(3, products.Count);
        }
    }
}