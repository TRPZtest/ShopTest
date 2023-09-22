using ShopTest.Data.Entities;

namespace ShopTest.Models
{
    public class GetCategoriesFrequenciesResponse
    {
        public List<Product> Products { get; set; }
        public Dictionary<String, int> CategoriesFrequencies { get; set; }
    }
}
