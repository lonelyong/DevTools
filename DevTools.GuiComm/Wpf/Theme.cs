using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Windows;

namespace DevTools.GuiComm.Wpf
{
    [Serializable]
    public class Theme : DependencyObject
    {
        public static readonly DependencyProperty BackgroundProperty;

        public static readonly DependencyProperty ForegroundProperty;

        public static readonly DependencyProperty BorderBrushProperty;

        public static readonly DependencyProperty IsOnUpdatingProperty;

        public static Theme Default { get; } = new Theme();

        [XmlElement]
        public Brush Background {
            get
            {
                return (Brush)GetValue(BackgroundProperty);
            }
            set
            {
                SetValue(BackgroundProperty, value);
            }
        }

        [XmlElement]
        public Brush Foreground
        {
            get
            {
                return (Brush)GetValue(ForegroundProperty);
            }
            set
            {
                SetValue(ForegroundProperty, value);
            }
        }

        [XmlElement]
        public Brush BorderBrush
        {
            get
            {
                return (Brush)GetValue(BorderBrushProperty);
            }
            set
            {
                SetValue(BorderBrushProperty, value);
            }
        }

        [XmlIgnore]
        public bool IsOnUpdating
        {
            get
            {
                return (bool)GetValue(IsOnUpdatingProperty);
            }
        }

        static Theme()
        {
            BackgroundProperty = DependencyProperty.Register(nameof(Background), typeof(Brush), typeof(Theme), new PropertyMetadata(Brushes.Azure));
            ForegroundProperty = DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(Theme), new PropertyMetadata(Brushes.Blue));
            BorderBrushProperty = DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(Theme), new PropertyMetadata(Brushes.Green));
            IsOnUpdatingProperty = DependencyProperty.Register(nameof(IsOnUpdating), typeof(bool), typeof(Theme), new PropertyMetadata(false));
        }

        public Theme()
        {

        }

        public void BeginUpdate()
        {
            SetValue(IsOnUpdatingProperty, true);
        }

        public void EndUpdate()
        {
            SetValue(IsOnUpdatingProperty, false);
        }
    }
}
