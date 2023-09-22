﻿using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public interface IShopRepository
    {
        public Task<List<Client>> GetCLientsByDirthDate(DateTime date);
        public Task<List<Client>> GetLastClients(int daysAgo);
        public Task<List<Client>> GetClientIdWithEagerLoading(long clientId);
        public Task<List<Product>> GetProductsByClientId(long clientId);
        public Task<Dictionary<string, int>> GetCategoriesFrequencyByClientId(long clientId);
    }
}
