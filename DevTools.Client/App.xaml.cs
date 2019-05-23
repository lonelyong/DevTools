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

		public App()
		{
			InitializeComponent();
			DefaultControlTemplate = (ControlTemplate)Resources["DefaultWindowTemplate"];
			DefaultControlTemplateStyle = (Style)Resources["DefaultWindowTemplateStyle"];

		}

		public static App GetCurrent()
		{
			return Current as App;
		}

		private void TitleBtnGroupStackPanel_Click(object sender, RoutedEventArgs e)
		{
			var btn = e.Source as Button;
			var wnd = Window.GetWindow(btn);
			if (btn.Name == "minimizeButton")
			{
				wnd.WindowState = WindowState.Minimized;
			}
			else if (btn.Name == "maximizeButton")
			{
				if(wnd.WindowState == WindowState.Maximized)
				{
					wnd.WindowState = WindowState.Normal;
				}
				else if(wnd.WindowState == WindowState.Normal)
				{
					wnd.WindowState = WindowState.Maximized;
				}
			}
			else if (btn.Name == "closeButton")
			{
				wnd.Close();
			}
		}
	}
}
