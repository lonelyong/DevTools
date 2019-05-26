using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DevTools.GuiComm.Wpf
{
    public static class BrushUtils
    {
        public static Brush GetLighterBrush(this Brush brush, int level)
        {
            if(level < 1 || level > 100)
            {
                throw new ArgumentException($"{nameof(level)}的范围是1-100");
            }
            if(brush is SolidColorBrush solidColorBrush)
            {
                var color = solidColorBrush.Color;
                return new SolidColorBrush(color.GetLighterColor(level));
            }
            return brush;
        }

        /// <summary>
        /// 获取比指定画笔颜色更深的画笔
        /// </summary>
        /// <param name="brush">颜色画笔</param>
        /// <param name="level">深度等级，1-100</param>
        /// <returns></returns>
        public static Brush GetDeeperBrush(this Brush brush, int level)
        {
            if (level < 1 || level > 100)
            {
                throw new ArgumentException($"{nameof(level)}的范围是1-100");
            }
            if (brush is SolidColorBrush solidColorBrush)
            {
                var color = solidColorBrush.Color;
                return new SolidColorBrush(color.GetDeeperColor(level));
            }
            return brush;
        }

        /// <summary>
        /// 获取指定画笔颜色的相反画笔
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Brush GetOppositeBrush(this Brush brush)
        {
            if (brush is SolidColorBrush solidColorBrush)
            {
                var color = solidColorBrush.Color;
                return new SolidColorBrush(color.GetOppositeColor());
            }
            return brush;
        }
    }
}
