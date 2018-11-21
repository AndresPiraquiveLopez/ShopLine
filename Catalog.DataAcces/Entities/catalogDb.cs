using System.Data.Entity;

namespace Catalog.DataAcces.Entities
{
    public class CatalogDb : DbContext
    {
        public CatalogDb() : base("name=InventoryDb")
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    }
}
