using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryBusinessLogic.Models;

namespace InventoryBusinessLogic.UnitOfWork
{
    public interface IProductInventoryUoW
    {
        IEnumerable<ProductInventoryModel> GetAll();

        void AddProduct(ProductModel productModel);

        ProductInventoryModel Reserve(int id);

        ProductInventoryModel UnReserve(int id);

        void Receive(IEnumerable<ProductInventoryModel> items);

        void Order(IEnumerable<ProductInventoryModel> items);

        int CheckMinQty(int id);
        List<ProductModel> GetProduct(string productId);
    }
}
