using System.Data.Entity;

namespace Inventory.DataAcces.Entities
{
    public class InventoryDb : DbContext
    {
        public InventoryDb() : base("name=InventoryDb")
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    }
}
