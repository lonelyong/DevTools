using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace DevTools.Client.Views.Components
{
    class CustomTabControl : TabControl
    {
        public static readonly DependencyProperty HeaderBackgroundProperty;

        public Brush HeaderBackground
        {
            get
            {
                return GetValue(HeaderBackgroundProperty) as Brush;
            }
            set
            {
                SetValue(HeaderBackgroundProperty, value);
            }
        }

        static CustomTabControl()
        {
            HeaderBackgroundProperty = DependencyProperty.Register(nameof(HeaderBackground), typeof(Brush), typeof(CustomTabControl));
        }
    }
}
