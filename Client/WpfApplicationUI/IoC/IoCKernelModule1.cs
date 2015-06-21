using ClientInterfaces.Factories;
using ClientInterfaces.Models;
using ClientInterfaces.ServicesProxy;
using Models.Factories;
using Ninject.Modules;
using Ninject.Extensions.Factory;
using ServiceProxy;
using ServiceProxy.ItemServiceRef;

namespace WpfApplicationUI.IoC
{
    class IoCKernelModule1 : NinjectModule
    {
        public override void Load()
        {
            #region WCF Services Proxy

            this.Bind<IItemService>().To<ServiceProxy.ItemServiceRef.ItemServiceClient>();
            this.Bind<IItemServiceProxy>().To<ItemServiceProxy>();
            this.Bind<IServiceProxyFactory>().ToFactory();

            #endregion

            #region Models

            this.Bind<IItem>().To<Models.Models.Item>();
            this.Bind<IItemFactory>().To<ItemFactory>();
            this.Bind<IObjectFactory>().ToFactory();
            this.Bind<IItemsCollection>().To<Models.Models.ItemsCollection>();

            #endregion
        }
    }
}
