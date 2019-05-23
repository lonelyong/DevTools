//#define USE_CASTLEWINDSOR
#define USE_MSDI

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.DependencyInjection;
using DevTools.Client.Views.Main;
namespace DevTools.Client
{
	static class Program
	{
		private static readonly IWindsorContainer _container = new WindsorContainer();

		private static readonly IServiceCollection _services = new ServiceCollection();

		private static IServiceProvider _serviceProvider;

		private static App _currentApp;

		private static MainWindow _mainWindow;

		public static IServiceProvider Services { get { return _serviceProvider; } }

		public static App CurrentApp { get { return _currentApp; } }

		[STAThread]
        static void Main(string[] args)
		{
#if USE_CASTLEWINDSOR
			UseCastleWindsor();
#elif USE_MSDI
			UseMicrosoftDI();
#endif
			_currentApp = _serviceProvider.GetService<App>();
            _mainWindow = _serviceProvider.GetService<MainWindow>();
            _currentApp.Run(_mainWindow);
		}

		static void RegisterServices()
		{
			_services.AddSingleton<App>();
			_services.AddSingleton<MainWindow>();
		}

		static void UseCastleWindsor()
		{
			RegisterServices();
			//_container.Register(Component.For<IWindsorContainer>().LifestyleSingleton().Instance(_container));
			//_container.Register(Component.For<App>().LifestyleSingleton());
			//_container.Register(Component.For<Views.MainWindow>().LifestyleSingleton());
			_serviceProvider = Castle.Windsor.MsDependencyInjection.WindsorRegistrationHelper.CreateServiceProvider(_container, _services);
		}

		static void UseMicrosoftDI()
		{
			RegisterServices();
			_serviceProvider = _services.BuildServiceProvider(new ServiceProviderOptions() {
				
			});
		}
	}
}
