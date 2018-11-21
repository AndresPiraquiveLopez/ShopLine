using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Catalog.DataAcces.Entities;
using CatalogBusinessLogic.Repositories;

namespace CatalogBusinessLogic.Factories
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public DbContext Context { get; set; }
        public Dictionary<Type, object> Repositories { get; set; }

        public RepositoryProvider()
        {
            Repositories = new Dictionary<Type, object>();
        }

        public DbContext CreateContext<T>() where T : DbContext, new()
        {
            return Context ?? (Context = new T());
        }

        protected virtual IRepository<T> MakeRepository<T>() where T : class
        {
            //create repository
            var context = CreateContext<CatalogDb>();
            var repository = new BaseRepository<T>(context);
            //insert repository in dictionary
            Repositories[typeof(T)] = repository;

            return repository;
        }


        public IRepository<T> CreateRepository<T>() where T : class
        {
            //look for T dictionary cache under typeof(T)
            object repository;
            Repositories.TryGetValue(typeof(T), out repository);
            if (repository != null)
            {
                return (IRepository<T>)repository;
            }

            //if not found then create and add to dictionary cache
            return MakeRepository<T>();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }
    }
}