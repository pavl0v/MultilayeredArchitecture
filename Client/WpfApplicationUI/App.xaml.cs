using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Ninject;

namespace WpfApplicationUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //ViewModels.MainWindowViewModel vm = IoC.IoCKernel.Kernel.Get<ViewModels.MainWindowViewModel>();
            Views.MainWindow v = IoC.IoCKernel.Kernel.Get<Views.MainWindow>();
            v.Show();
        }
    }
}
