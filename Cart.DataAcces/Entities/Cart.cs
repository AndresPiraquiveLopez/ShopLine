using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.DataAcces.Entities
{
    [Table("Carts")]
    public class Cart
    {
        [Key]
        public string CartId { get; set; }

        public string UserId { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}
