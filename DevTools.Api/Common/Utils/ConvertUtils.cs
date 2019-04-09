using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.Api.Common.Utils
{
    public static class ConvertUtils
    {
        const string _base = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static int exponent = _base.Length;//幂数

        public static long FromNum64(this string num64)
        {
            long result = 0;
            for (int i = 0; i < num64.Length; i++)
            {
                int x = num64.Length - i - 1;
                result += _base.IndexOf(num64[i]) * Pow(exponent, x);// Math.Pow(exponent, x);
            }
            return result;
        }
        /// <summary>
        /// 一个数据的N次方
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static long Pow(long baseNo, decimal x)
        {
            long value = 1;////1 will be the result for any number's power 0.任何数的0次方，结果都等于1
            while (x > 0)
            {
                value = value * baseNo;
                x--;
            }
            return value;
        }

        public static string ToNum64(this long num)
        {
            string result = string.Empty;
            do
            {
                long index = num % exponent;
                result = _base[(int)index] + result;
                num = (num - index) / exponent;
            }
            while (num > 0);
            return result;
        }
    }
}
