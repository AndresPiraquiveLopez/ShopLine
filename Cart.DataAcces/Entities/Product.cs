using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.DataAcces.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        //public string Description { get; set; }

        public string ImagePath { get; set; }

        public double? UnitPrice { get; set; }

        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        //public virtual Category Category { get; set; }

    }
}