using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DevTools.GuiComm.Wpf
{
    public static class ColorUtils
    {
        public static Color GetLighterColor(this Color color, int level)
        {
            if (level < 1 || level > 100)
            {
                throw new ArgumentException($"{nameof(level)}的范围是1-100");
            }
            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.B;
            var p = 1 + level / 100d;
            var r1 = r * p;
            var g1 = g * p;
            var b1 = b * p;
            r = r1 > byte.MaxValue ? byte.MaxValue : (byte)r1;
            g = g1 > byte.MaxValue ? byte.MaxValue : (byte)g1;
            b = b1 > byte.MaxValue ? byte.MaxValue : (byte)b1;
            return Color.FromArgb(a, r, g, b);
        }

        public static Color GetDeeperColor(this Color color, int level)
        {
            if (level < 1 || level > 100)
            {
                throw new ArgumentException($"{nameof(level)}的范围是1-100");
            }
            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.B;
            var p = 1 - level / 100d;
            var r1 = r * p;
            var g1 = g * p;
            var b1 = b * p;
            r = r1 < byte.MinValue ? byte.MinValue : (byte)r1;
            g = g1 < byte.MinValue ? byte.MinValue : (byte)g1;
            b = b1 < byte.MinValue ? byte.MinValue : (byte)b1;
            return Color.FromArgb(a, r, g, b);
        }

        public static Color GetOppositeColor(this Color color)
        {
            var a = color.A;
            var r = color.R;
            var g = color.G;
            var b = color.R;
            r = (byte)(byte.MaxValue - r);
            g = (byte)(byte.MaxValue - g);
            b = (byte)(byte.MaxValue - b);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
