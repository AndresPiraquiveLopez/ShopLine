using System;
using System.Data.Entity;
using System.Threading.Tasks;
using InventoryBusinessLogic.Repositories;

namespace InventoryBusinessLogic.Factories
{
    public interface IRepositoryProvider: IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;

        DbContext CreateContext<T>() where T : DbContext, new();

        void SaveChanges();

        Task CommitAsync();
    }
}
