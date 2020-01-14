using DevTools.Client.Views.Components;
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

namespace DevTools.Client.Views.Main
{
    /// <summary>
    /// SLink.xaml 的交互逻辑
    /// </summary>
    public partial class SLinkTab : UserControl
    {
        public static readonly DependencyProperty ZipInputProperty;

        public static readonly DependencyProperty ZipResultProperty;

        public static readonly DependencyProperty UnzipInputProperty;

        public static readonly DependencyProperty UnzipResultProperty;

        public string ZipInput
        {
            get
            {
                return GetValue(ZipInputProperty) as string;
            }
            set
            {
                SetValue(ZipInputProperty, value);
            }
        }

        public string ZipResult
        {
            get
            {
                return GetValue(ZipResultProperty) as string;
            }
            set
            {
                SetValue(ZipResultProperty, value);
            }
        }

        public string UnzipInput
        {
            get
            {
                return GetValue(UnzipInputProperty) as string;
            }
            set
            {
                SetValue(UnzipInputProperty, value);
            }
        }

        public string UnzipResult
        {
            get
            {
                return GetValue(UnzipResultProperty) as string;
            }
            set
            {
                SetValue(UnzipResultProperty, value);
            }
        }

        static SLinkTab()
        {
            ZipInputProperty = DependencyProperty.Register(nameof(ZipInput), typeof(string), typeof(SLinkTab));
            ZipResultProperty = DependencyProperty.Register(nameof(ZipResult), typeof(string), typeof(SLinkTab));
            UnzipInputProperty = DependencyProperty.Register(nameof(UnzipInput), typeof(string), typeof(SLinkTab));
            UnzipResultProperty = DependencyProperty.Register(nameof(UnzipResult), typeof(string), typeof(SLinkTab));
        }

        public SLinkTab()
        {
            InitializeComponent();
            DataContext = this;
            ZipResult = "this is the result!";
            ZipInput = "123";
        }

        private void TabHeaderContainerGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
