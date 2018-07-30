using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Api.Common.Consts
{
    public static class RegexConsts
    {
        public const string SHORTLINK = "^[0-9a-zA-Z]{1,8}$";

        public const string LONGLINK = @"^((https|http|ftp|rtsp|mms)?://)?(([0-9a-z_!~*\'().&=+$%-]+: )?[0-9a-z_!~*\'().&=+$%-]+@)?(([0-9]{1,3}.){3}[0-9]{1,3}|([0-9a-z_!~*\'()-]+.)*([0-9a-z][0-9a-z-]{0,61})?[0-9a-z].[a-z]{2,6})(:[0-9]{1,4})?((/?)|(/[0-9a-z_!~*\'().;?:@&=+$,%#-]+)+/?)$";
    }
}
