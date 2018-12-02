namespace Catalog.DataAcces.Entities
{
    public interface ICatalog
    {
        string CatalogName { get; set; }
        int Id { get; set; }

        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}