using System;
using System.Threading.Tasks;
using CartBusinessLogic.Repositories;

namespace CartBusinessLogic.Factories
{
    public interface IRepositoryProvider: IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;    

        void SaveChanges();

        Task CommitAsync();
    }
}
