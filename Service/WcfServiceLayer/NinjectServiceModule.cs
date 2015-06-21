using BusinessLogicLayer;
using DataAccessLayer;
using Ninject.Modules;
using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLayer
{
    class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            //this.Bind<ISystemClock>().To<SystemClock>();
            //this.Bind<ILog>().ToMethod(ctx => LogManager.GetLogger(ctx.Request.Target.Member.DeclaringType));
            this.Bind<IDALItemManager>().To<DALItemManager>();
            this.Bind<IItemBO>().To<ItemBO>();
            this.Bind<IBLLItemManager>().To<BLLItemManager>();
            this.Bind<IService1>().To<Service1>();
        }
    }
}
