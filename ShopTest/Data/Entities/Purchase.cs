using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopTest.Data.Entities
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        public Decimal TotalPrice
        {
            get { return Products.Sum(x => x.TotalPrice); }
            private set { }
        }
    }
}
