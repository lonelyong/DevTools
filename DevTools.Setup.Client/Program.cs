using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DevTools.Setup.Client
{
    static class Program
    {
        public static ApplicationInfo ApplicationInfo { get; }

        private static readonly IWindsorContainer _windsorContainer = new WindsorContainer();

        [STAThread]
        public static void Main(string[] args)
        {
            ConfigureServices();
            var app = _windsorContainer.Resolve<App>();
            var mainWindow = _windsorContainer.Resolve<Views.MainWindow>();
            app.Run(mainWindow);
        }

        static void ConfigureServices()
        {
            _windsorContainer.Register(Component.For<App>().LifestyleSingleton());
            _windsorContainer.Register(Component.For<Views.MainWindow>().LifestyleSingleton());
        }
    }
}
