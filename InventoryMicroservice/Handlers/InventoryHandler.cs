using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryBusinessLogic.UnitOfWork;
using Unity;

namespace InventoryMicroservice.Handlers
{
    public class InventoryHandler : HandlerBase
    {
        private readonly IInventoryUoW _uoW;

        public InventoryHandler(IUnityContainer container) : base(container)
        {
            _uoW = container.Resolve<IInventoryUoW>();
        }

        public override void Run()
        {
            _uoW.GetAll();
        }
    }
}
