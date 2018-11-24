using System;
using System.Threading.Tasks;
using CartBusinessLogic.Factories;
using CartBusinessLogic.Repositories;

namespace CartBusinessLogic.UnitOfWork
{
    public class BaseUoW : IDisposable
    {
        public IRepositoryProvider RepositoryProvider { get; set; }

        protected BaseUoW(IRepositoryProvider repositoryProvider)
        {
            RepositoryProvider = repositoryProvider;
        }

        /// <summary>
        /// Gets and/or create an instance <typeparamref name="T"/> of a Repository
        /// </summary>
        /// <typeparam name="T">Type <typeparamref name="T"/> of a repository</typeparam>
        /// <returns>An instance <typeparamref name="T"/> or a repository</returns>
        protected IRepository<T> GetRepository<T>() where T : class
        {
            return RepositoryProvider.CreateRepository<T>();
        }

        /// <summary>
        /// Disposes of the <see cref="RepositoryProvider"/> and sets 
        /// </summary>
        public void Dispose()
        {
            if (RepositoryProvider != null)
            {
                RepositoryProvider.Dispose();
                RepositoryProvider = null;
            }
        }

        /// <summary>
        /// Commits changes to the database made to the Repository 
        /// </summary>
        public void Commit()
        {
            RepositoryProvider.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await RepositoryProvider.CommitAsync().ConfigureAwait(false);
        }
    }
}
