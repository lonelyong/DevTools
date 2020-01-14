using DevTools.Client.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevTools.GuiComm.Wpf;
using System.Windows.Media;
using DevTools.Client.Views;

namespace DevTools.Client
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	[Service(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
	public partial class App : Application
	{
		public ControlTemplate DefaultControlTemplate { get; }

		public Style DefaultControlTemplateStyle { get; }

        public Theme Theme { get; set; }

		public App()
		{
			InitializeComponent();
            if(Resources == null)
            {
                Resources = new ResourceDictionary();
            }
            Resources.MergeCurrentAssemblyResources();
            Theme = new Theme() {
                BorderBrush = Brushes.Green,
                Background = Brushes.WhiteSmoke,
                Foreground = Brushes.Black
            };
		}

		public static App GetCurrent()
		{
			return Current as App;
		}
    }
}
