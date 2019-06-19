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

        public static void MergeCurrentAssemblyResources(this ResourceDictionary resourceDictionary)
        {
            var res = GetResourceDictionary(new Uri("/DevTools.GuiComm;component/Wpf/PublicResources.xaml", UriKind.Relative));
            if(resourceDictionary == null)
            {
                throw new ArgumentNullException(nameof(resourceDictionary));
            }
            else
            {
                resourceDictionary.MergedDictionaries.Add(res);
            }
        }
    }
}
