using System;
using System.Data.Entity;
using System.Threading.Tasks;
using InventoryBusinessLogic.Repositories;

namespace InventoryBusinessLogic.Factories
{
    public interface IRepositoryProvider: IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;    

        void SaveChanges();

        Task CommitAsync();
    }
}
