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
        public ICollection<Product> Products { get; set; }
        [NotMapped]
        public Double TotalPrice
        {
            get { return Products.Sum(x => x.TotalPrice); }
            private set { }
        }
    }
}
