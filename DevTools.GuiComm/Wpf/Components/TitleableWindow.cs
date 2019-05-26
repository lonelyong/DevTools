using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DevTools.GuiComm.Wpf;

namespace DevTools.GuiComm.Wpf.Components
{
    /// <summary>
    /// 继承的窗体不能修改窗体的DataContext
    /// </summary>
	public class TitleableWindow : Window
	{
        #region fields
        private object _lockObj = new object();

        private TitleBar _titleBar;

        public static readonly DependencyProperty ThemeProperty;
        #endregion

        #region properties
        public TitleBar TitleBar
        {
            get {
                if(_titleBar == null)
                {
                    lock (_lockObj)
                    {
                        if(_titleBar == null)
                        {
                            _titleBar = (TitleBar)Template.FindName(WindowResources.ComponentName_TitleBar, this);
                        }
                    }
                }
                return _titleBar;
            }
        }

        public Theme Theme
        {
            get
            {
                return (Theme)GetValue(ThemeProperty);
            }
            set
            {
                SetValue(ThemeProperty, value);
            }
        }
        #endregion

        static TitleableWindow()
        {
            ThemeProperty = DependencyProperty.Register(nameof(Theme), typeof(Theme), typeof(TitleableWindow), new PropertyMetadata(null));
        }

        public TitleableWindow()
		{
            DataContext = this;
            Style = ResourceManager.WindowResources[WindowResources.ResourceKey_TitleableWindowStyle] as Style;
            ApplyTemplate();
            Background = Theme.Default.Background;
		}

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            PropertyChanged(this, e);
        }

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var wnd = (TitleableWindow)d;
            if (e.Property == ThemeProperty)
            {
                var t = e.NewValue as Theme;

                wnd.Background = t?.Background;
                wnd.Foreground = t?.Foreground;
                wnd.BorderBrush = t?.BorderBrush;
            }
            else if (e.Property == BorderBrushProperty) {
                wnd.TitleBar.Background = e.NewValue as Brush;
            }
        }

    }
}
