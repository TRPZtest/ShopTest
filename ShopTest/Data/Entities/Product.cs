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
        public Decimal Price { get; set; }
        public int Count { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Decimal TotalPrice 
        {
            get { return Price * Count; }
            private set {  }
        }
        public Category Category { get; set; }
    }
}
