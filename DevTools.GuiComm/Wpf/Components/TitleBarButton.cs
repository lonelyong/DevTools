using DevTools.GuiComm.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DevTools.GuiComm.Wpf.Components
{
    public class TitleBarButton : Button
    {
        public static readonly DependencyProperty ButtonKindProperty;

        public static readonly DependencyProperty BackgroundCoreProperty;

        public TitleBarButtonKind ButtonKind {
            get
            {
                return (TitleBarButtonKind)GetValue(ButtonKindProperty);
            }
            set
            {
                SetValue(ButtonKindProperty, value);
            }
        }

        public Brush BackgroundCore
        {
            get
            {
                return (Brush)GetValue(BackgroundCoreProperty);
            }
            set
            {
                SetValue(BackgroundCoreProperty, value);
            }
        }

        private TextBlock _content;

        private bool _isMouseDown = false;

        static TitleBarButton()
        {
            ButtonKindProperty = DependencyProperty.Register(nameof(ButtonKind), typeof(TitleBarButtonKind), typeof(TitleBarButton), new PropertyMetadata() {
                DefaultValue = TitleBarButtonKind.Custom
            });
            BackgroundCoreProperty = DependencyProperty.Register(nameof(BackgroundCore), typeof(Brush), typeof(TitleBarButton));
        }

        public TitleBarButton()
        {
            DataContext = this;
            Template = ResourceManager.WindowResources[WindowResources.ResourceKey_TitleBarButtonTemplate] as ControlTemplate;
            BorderThickness = new Thickness(0);
            Focusable = false;
            VerticalAlignment = VerticalAlignment.Center;
            AllowDrop = false;
            Padding = new Thickness(0);
            ApplyTemplate();
            _content = Template.FindName(WindowResources.ComponentName_TitleBarButtonContent, this) as TextBlock;
            _content.MouseEnter += TitleBarButton_MouseEnter;
            _content.MouseLeftButtonDown += TitleBarButton_MouseLeftButtonDown;
            _content.MouseLeftButtonUp += TitleBarButton_MouseLeftButtonUp;
            _content.MouseLeave += TitleBarButton_MouseLeave;
            Background = Theme.Default.BorderBrush;
            BackgroundCore = Background;
        }

        private void TitleBarButton_MouseEnter(object sender, MouseEventArgs e)
        {
            UpdateButton();
            e.Handled = true;
        }

        private void TitleBarButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            UpdateButton();
            e.Handled = true;
        }

        private void TitleBarButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
            var wnd = Window.GetWindow(this) as TitleableWindow;
            UpdateButton();
            switch (ButtonKind)
            {
                case TitleBarButtonKind.Minimize:
                    wnd.WindowState = WindowState.Minimized;
                    break;
                case TitleBarButtonKind.Maximize:
                    if (wnd.WindowState == WindowState.Maximized)
                    {
                        wnd.WindowState = WindowState.Normal;
                    }
                    else if (wnd.WindowState == WindowState.Normal)
                    {
                        wnd.WindowState = WindowState.Maximized;
                    }
                    break;
                case TitleBarButtonKind.Close:
                    wnd.Close();
                    break;
                case TitleBarButtonKind.Help:
                    break;
                case TitleBarButtonKind.Custom:
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        private void TitleBarButton_MouseLeave(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            UpdateButton();
            e.Handled = true;
        }

        private void UpdateButton()
        {
            var brush = ButtonKind == TitleBarButtonKind.Close ? Brushes.DarkRed : BackgroundCore;
            if (_isMouseDown)
            {
                Background = brush.GetDeeperBrush(30);
                Foreground = Background.GetOppositeBrush();
            }
            else if (IsMouseOver)
            {
                var x = base.Padding;
                Background = brush.GetDeeperBrush(20);
                Foreground = Background.GetOppositeBrush();
            }
            else
            {
                Background = BackgroundCore;
                Foreground = Background.GetOppositeBrush();
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if(e.Property == BackgroundCoreProperty)
            {
                UpdateButton();
            }
        }
    }

    public enum TitleBarButtonKind
    {
        Minimize,
        Maximize,
        Close,
        Help,
        Custom
    }
}
