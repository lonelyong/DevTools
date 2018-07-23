using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShortUrl.Api.Models 
{
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class TReponse<T>
    {
        public const string DEFAULT_RETURN_CODE_SUCCESS = "SUCCESS";

        public const string DEFAULT_RETURN_CODE_FAIL = "FAIL";

        public const string DEFAULT_RETURN_MSG_OK = "OK";

        [XmlElement("return_code")]
        public string Return_Code { get; set; }

        [XmlElement("return_msg")]
        public string Return_Msg { get; set; }

        [XmlElement("result")]
        public T Result { get; set; }

        public static TReponse<T> Ok()
        {
            return Ok(default(T));
        }

        public static TReponse<T> Ok(T result)
        {
            return Ok(result, DEFAULT_RETURN_MSG_OK);
        }

        public static TReponse<T> Ok(T result, string msg)
        {
            return new TReponse<T>()
            {
                Return_Code = DEFAULT_RETURN_CODE_SUCCESS,

                Return_Msg = msg,

                Result = result
            };
        }

        public static TReponse<T> Error(string msg)
        {
            return new TReponse<T>() {
                Return_Code = DEFAULT_RETURN_CODE_FAIL,
                Return_Msg = msg
            };
        }
    }
}
