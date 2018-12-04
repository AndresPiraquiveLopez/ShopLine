using CartBusinessLogic.Factories;
using CartBusinessLogic.UnitOfWork;
using CartBussinessLogic.Factories;
using CartBussinessLogic.UnitOfWork;
using Unity;

namespace CartBusinessLogic.Initializers
{
    public class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static void RegisterComponents()
        {
            if (Container == null)
                Container = new UnityContainer();

            Container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            Container.RegisterType<ICartUoW, CartUoW>();
        }
    }
}
