using System.Data.Entity;

namespace Cart.DataAcces.Entities
{
    public class CartDb : DbContext
    {
        public CartDb() : base("name=CartDb")
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}