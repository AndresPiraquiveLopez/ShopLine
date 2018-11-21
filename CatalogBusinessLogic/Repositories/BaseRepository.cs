using System.Data.Entity;
using System.Linq;

namespace CatalogBusinessLogic.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public IDbSet<T> Set { get; set; }

        public BaseRepository()
            : this(null)
        {
        }

        public BaseRepository(DbContext context)
        {
            if (context != null)
            {
                Context = context;
                Set = Context.Set<T>();
            }
        }

        /// <summary>
        /// Adds an <see cref="item"/> of type <typeparamref name="T"/> to the DbContext
        /// </summary>        
        /// <param name="item">The item of type <typeparamref name="T"/> to add</typeparam>
        /// <returns>The item of type <typeparamref name="T"/></returns>
        public T Add(T item)
        {
            return Set.Add(item);
        }

        public IQueryable<T> GetAll(params string[] propertiesToLoad)
        {
            IQueryable<T> set = Set;
            if (propertiesToLoad != null)
            {
                foreach (var property in propertiesToLoad)
                {
                    set = set.Include(property);
                }
            }
            return set;
        }

        public T Remove(T item)
        {
            return Set.Remove(item);
        }

        public IQueryable<T> GetAllLocal()
        {
            IQueryable<T> setLocal = Set.Local.AsQueryable();

            return setLocal;
        }
    }
}
