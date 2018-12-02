using System.Collections.Generic;
using CatalogBusinessLogic.Models;

namespace CatalogBusinessLogic.UnitOfWork
{
    public interface ICatalogUoW
    {
        IList<CategoryModel> Catalog(int id);

        IList<ProductModel> Category(int id);

        IList<ProductModel> Product(int id);

        int AddProduct(ProductModel newProduct);
    }
}
