using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopTest.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public int Count { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Double TotalPrice { get; private set; }       
        public Category Category { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
    }
}
