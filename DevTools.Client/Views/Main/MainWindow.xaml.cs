using DevTools.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevTools.GuiComm.Wpf;
namespace DevTools.Client.Views.Main
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	[Service(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
	partial class MainWindow : DefaultWindow
	{

		public MainWindow()
		{
			InitializeComponent();
            Icon = Properties.Resources.icon.ToBitmapImage();
            //TitleBar.Visibility = Visibility.Collapsed;
            TitleBar.MinimizeButtonVisibility = Visibility.Collapsed;
        }

		private void Window_StateChanged(object sender, EventArgs e)
		{
           
		}

        private void DefaultWindow_Initialized(object sender, EventArgs e)
        {
            
        }

        private void DefaultWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
