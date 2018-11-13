using System.Collections.Generic;
using System.Linq;
using InventoryBusinessLogic.Models;

namespace InventoryBusinessLogic.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Adds an <see cref="item"/> of type <typeparamref name="T"/> to the DbContext
        /// </summary>        
        /// <param name="item">The item of type <typeparamref name="T"/> to add</param>
        /// <returns>The item of type <typeparamref name="T"/></returns>
        T Add(T item);

        /// <summary>
        /// Removes an <see cref="item"/> of type <typeparamref name="T"/> to the DbContext
        /// </summary>
        /// <param name="item">The item of type <typeparamref name="T"/> to remove</param>
        /// <returns>The item of type <typeparamref name="T"/></returns>
        T Remove(T item);
        IEnumerable<ProductInventory> GetAll(params string[] propertiesToLoad);
        IQueryable<T> GetAllLocal();
    }
}
