using System.Collections.Generic;
using CatalogBusinessLogic.Factories;
using InventoryBusinessLogic.UnitOfWork;

namespace CatalogBusinessLogic.UnitOfWork
{
    public class CatalogUoW : BaseUoW, ICatalogUoW
    {
        //public IRepository<Product> ProductRepository => GetRepository<Product>();

        public CatalogUoW(IRepositoryProvider repositoryProvider) : base(repositoryProvider)
        {
        }


        public void TransfertQty(int qty, int id)
        {
            throw new System.NotImplementedException();
        }

    //    public int AddToStockQty(ProductInventory productInventory)
    //    {
    //        //var product = Mapper.Map<Product>(productInventory);
    //        var product = new Product
    //        {
    //            Id = productInventory.Id,
    //            Code = productInventory.Code,
    //            CategoryId = productInventory.CategoryId,
    //            Name = productInventory.Name,
    //            Cost = productInventory.Cost,
    //            SellPrice = productInventory.SellPrice,
    //            Qty = productInventory.Qty
    //        };

    //        ProductRepository.Add(product);

    //        Commit();

    //        return product.Id;
    //    }

    //    public void Delete(int id)
    //    {
    //        var product = ProductRepository.GetAll().FirstOrDefault(p => p.Id == id);

    //        ProductRepository.Remove(product);
    //        Commit();
    //    }

    //    public void AdjStock(int qty, int id)
    //    {           
    //        var product = ProductRepository.GetAll().FirstOrDefault(i => i.Id == id);

    //        if (product != null) product.Qty = qty;
    //        Commit();

    //    }

    //    public IEnumerable<ProductInventory> GetAll()
    //    {
    //        var product = ProductRepository.GetAll().ToList();

    //        return null;
    //    }

    //    public ProductInventory Reserve(int id)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public ProductInventory UnReserve(int id)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Receive(IEnumerable<ProductInventory> items)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public void Order(IEnumerable<ProductInventory> items)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public int CheckMinQty(int id)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public int AddToStockQty()
    //    {
    //        var product = new Product
    //        {
    //            Id = 3,
    //            CategoryId = 1,
    //            Code = "AAA",
    //            Name = "Subaru",
    //            SellPrice = 15,
    //            Cost = 15
    //        };
    //        ProductRepository.Add(product);
    //        Commit();
            
    //        return product.Id;
    //    }
    }
}
