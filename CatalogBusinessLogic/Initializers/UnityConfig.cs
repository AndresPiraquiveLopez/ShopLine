using CatalogBusinessLogic.Factories;
using CatalogBusinessLogic.UnitOfWork;
using Unity;

namespace CatalogBusinessLogic.Initializers
{
    public class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            if (Container == null)
                Container = new UnityContainer();

            Container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            Container.RegisterType<ICatalogUoW, CatalogUoW>();
        }
    }
}
