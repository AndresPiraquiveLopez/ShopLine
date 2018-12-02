using System.Data.Entity;

namespace Catalog.DataAcces.Entities
{
    public class CatalogDb : DbContext
    {
        public CatalogDb() : base("name=CatalogDb")
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Catalog> Catalog { get; set; }
    }
}
