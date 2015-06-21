using Ninject.Modules;

namespace WpfApplicationUI.IoC
{
    class IoCKernelModule2 : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ViewModels.MainWindowViewModel>().ToSelf();
            this.Bind<Views.MainWindow>().ToSelf();
        }
    }
}
