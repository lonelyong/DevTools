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

namespace DevTools.Client.UIL
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : TitleableWindow
	{
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if(e.LeftButton == MouseButtonState.Pressed)
			{
				if(!(e.MouseDevice.Target is Control))
				{
					this.DragMove();
				}
			}
		}

		private void Window_StateChanged(object sender, EventArgs e)
		{
			if(this.WindowState == WindowState.Maximized)
			{

			}
		}
	}
}
