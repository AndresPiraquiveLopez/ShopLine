using InventoryBusinessLogic.Factories;
using InventoryBusinessLogic.UnitOfWork;
using Unity;

namespace InventoryMicroservice
{
    public class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            Container = new UnityContainer();

            Container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            Container.RegisterType<IInventoryUoW, InventoryUoW>();
        }
    }
}
