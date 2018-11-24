using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.DataAcces.Entities
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        //[ForeignKey("ProductId")]
        public int ProductId { get; set; }

        //public virtual Product Product { get; set; }

    }
}
