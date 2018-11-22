using System;
using System.Threading.Tasks;
using CartBussinessLogic.Repositories;

namespace CartBussinessLogic.Factories
{
    public interface IRepositoryProvider: IDisposable
    {
        IRepository<T> CreateRepository<T>() where T : class;    

        void SaveChanges();

        Task CommitAsync();
    }
}
