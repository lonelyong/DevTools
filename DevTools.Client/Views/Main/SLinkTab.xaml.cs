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
        public SLinkTab()
        {
            InitializeComponent();
        }

        private void ZipTabHeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            unzipTabContentGrid.Visibility = Visibility.Hidden;
            zipTabContentGrid.Visibility = Visibility.Visible;
        }

        private void UnzipTabHeaderGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            unzipTabContentGrid.Visibility = Visibility.Visible;
            zipTabContentGrid.Visibility = Visibility.Hidden;
        }
    }
}
