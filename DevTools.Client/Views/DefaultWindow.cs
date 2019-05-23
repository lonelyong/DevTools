using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevTools.Client.Views
{
	public class DefaultWindow : Window
	{
		public DefaultWindow()
		{
			var app = App.GetCurrent();
			Template = app.DefaultControlTemplate;
			Style = app.DefaultControlTemplateStyle;
		}
	}
}
