using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DevTools.GuiComm.Wpf
{
    public static class ResourceUtils
    {
        public static ResourceDictionary GetResourceDictionary(Uri uri)
        {
            var obj = Application.LoadComponent(uri);
            return obj as ResourceDictionary;
        }
    }
}
