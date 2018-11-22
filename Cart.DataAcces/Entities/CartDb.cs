using System.Data.Entity;

namespace Cart.DataAcces.Entities
{
    public class InventoryDb : DbContext
    {
        public InventoryDb() : base("name=CartDb")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }

    }
}
