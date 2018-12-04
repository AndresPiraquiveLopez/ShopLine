using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.DataAcces.Entities
{
    [Table("CartItems")]
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public string CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual global::Cart.DataAcces.Entities.Cart Cart { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
