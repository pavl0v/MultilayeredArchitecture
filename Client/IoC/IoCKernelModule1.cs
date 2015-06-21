using ClientInterfaces.Factories;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;
using Models.Factories;
using Ninject.Modules;
using ServiceProxy;
using ServiceProxy.ItemServiceRef;

namespace IoC
{
    class IoCKernelModule1 : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IItemService>().To<ServiceProxy.ItemServiceRef.ItemServiceClient>();
            this.Bind<IItemServiceProxy>().To<ItemServiceProxy>();
            this.Bind<IItem>().To<Models.Models.Item>();
            this.Bind<IItemFactory>().To<ItemFactory>();
        }
    }
}
