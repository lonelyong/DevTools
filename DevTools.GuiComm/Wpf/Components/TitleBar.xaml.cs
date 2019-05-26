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
using DevTools.GuiComm.Wpf;

namespace DevTools.GuiComm.Wpf.Components
{
    /// <summary>
    /// TitleBar.xaml 的交互逻辑
    /// </summary>
    public partial class TitleBar : UserControl
    {
        #region fields
        public static readonly DependencyProperty MinimizeButtonVisibilityProperty;

        public static readonly DependencyProperty MaximizeButtonVisibilityProperty;

        public static readonly DependencyProperty CloseButtonVisibilityProperty;

        public static readonly DependencyProperty IconProperty;

        public static readonly DependencyProperty TitleProperty;
        #endregion

        #region properties
        public Visibility MinimizeButtonVisibility
        {
            get
            {
                return (Visibility)GetValue(MinimizeButtonVisibilityProperty);
            }
            set
            {
                SetValue(MinimizeButtonVisibilityProperty, value);
            }
        }

        public Visibility MaximizeButtonVisibility
        {
            get
            {
                return (Visibility)GetValue(MaximizeButtonVisibilityProperty);
            }
            set
            {
                SetValue(MaximizeButtonVisibilityProperty, value);
            }
        }

        public Visibility CloseButtonVisibility
        {
            get
            {
                return (Visibility)GetValue(CloseButtonVisibilityProperty);
            }
            set
            {
                SetValue(CloseButtonVisibilityProperty, value);
            }
        }

        public ImageSource Icon {
            get
            {
                return (ImageSource)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        #endregion

        static TitleBar()
        {
            MinimizeButtonVisibilityProperty = DependencyProperty.Register(nameof(MinimizeButtonVisibility), typeof(Visibility), typeof(TitleBar), new PropertyMetadata(Visibility.Visible));
            MaximizeButtonVisibilityProperty = DependencyProperty.Register(nameof(MaximizeButtonVisibility), typeof(Visibility), typeof(TitleBar), new PropertyMetadata(Visibility.Visible));
            CloseButtonVisibilityProperty = DependencyProperty.Register(nameof(CloseButtonVisibility), typeof(Visibility), typeof(TitleBar), new PropertyMetadata(Visibility.Visible));
            IconProperty = DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(TitleBar));
            TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TitleBar));
        }

        public TitleBar()
        {
            DataContext = this;
            InitializeComponent();
            Background = Theme.Default.BorderBrush;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var wnd = Window.GetWindow(e.Source as DependencyObject);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (!(e.MouseDevice.Target is Control))
                {
                    wnd.DragMove();
                    e.Handled = true;
                }
            }
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == BackgroundProperty)
            {
                MaximizeButton.BackgroundCore = e.NewValue as Brush;
                MinimizeButton.BackgroundCore = e.NewValue as Brush;
                CloseButton.BackgroundCore = e.NewValue as Brush;
                _TitleLabel.Foreground = (e.NewValue as Brush).GetOppositeBrush();
            }
        }
    }
}
