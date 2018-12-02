using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CatalogMicroservice.Handlers
{
    public abstract class HandlerBase
    {
        protected IUnityContainer Container { get; }

        protected HandlerBase(IUnityContainer container)
        {
            Container = container;
        }

        public abstract void Run();
    }

    public abstract class HandlerBase<TResponse>
    {
        protected IUnityContainer Container { get; }
        protected HandlerBase(IUnityContainer container)
        {
            Container = container;
        }

        public abstract TResponse Run();
    }
}
