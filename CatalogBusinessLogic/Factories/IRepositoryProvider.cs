using System;
using System.Threading.Tasks;
using CatalogBusinessLogic.Repositories;

namespace CatalogBusinessLogic.Factories
{
    public interface IRepositoryProvider: IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;    

        void SaveChanges();

        Task CommitAsync();
    }
}
