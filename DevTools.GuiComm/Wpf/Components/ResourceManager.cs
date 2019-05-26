using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevTools.GuiComm.Wpf.Components
{
    class ResourceManager
    {
        public static readonly ResourceDictionary WindowResources;

        static ResourceManager()
        {
            WindowResources = ResourceUtils.GetResourceDictionary(new Uri("/DevTools.GuiComm;component/Wpf/Components/WindowResources.xaml", UriKind.Relative));
        }
    }
}
