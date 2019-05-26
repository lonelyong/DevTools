using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DevTools.GuiComm.Wpf;
using DevTools.GuiComm.Wpf.Components;

namespace DevTools.Client.Views
{
    /// <summary>
    /// 继承的窗体不能修改窗体的DataContext
    /// </summary>
	public class DefaultWindow : TitleableWindow
	{
        public DefaultWindow()
		{

		}
    }
}
