using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.UnitOfWork;
using Unity;

namespace InventoryBusinessLogic.Initializers
{
    public class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            if (Container == null)
                Container = new UnityContainer();

            Container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            Container.RegisterType<IInventoryUoW, InventoryUoW>();
            Container.RegisterType<IProductInventoryUoW, ProductInventoryUoW>();
        }
    }
}
