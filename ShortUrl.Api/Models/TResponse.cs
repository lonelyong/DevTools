using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json.Schema;
namespace ShortUrl.Api.Models 
{
	/// <summary>
	/// api接口返回实体
	/// </summary>
	/// <typeparam name="T"></typeparam>
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class TResponse<T>
    {
        public const string DEFAULT_RETURN_CODE_SUCCESS = "SUCCESS";

        public const string DEFAULT_RETURN_CODE_FAIL = "FAIL";

        public const string DEFAULT_RETURN_MSG_OK = "OK"; 

		/// <summary>
		/// 返回状态码
		/// </summary>
        [XmlElement("return_code")]
        public string Return_Code { get; set; }

		/// <summary>
		/// 返回消息
		/// </summary>
        [XmlElement("return_msg")]
        public string Return_Msg { get; set; }

		/// <summary>
		/// 返回结果
		/// </summary>
        [XmlElement("result")]
        public T Result { get; set; }

		/// <summary>
		/// 返回成功，Result为T的默认值
		/// </summary>
		/// <returns></returns>
        public static TResponse<T> Ok()
        {
            return Ok(default(T));
        }
		/// <summary>
		/// 返回成功
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
        public static TResponse<T> Ok(T result)
        {
            return Ok(result, DEFAULT_RETURN_MSG_OK);
        }
		/// <summary>
		/// 返回成功
		/// </summary>
		/// <param name="result"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
        public static TResponse<T> Ok(T result, string msg)
        {
            return new TResponse<T>()
            {
                Return_Code = DEFAULT_RETURN_CODE_SUCCESS,

                Return_Msg = msg,

                Result = result
            };
        }
		/// <summary>
		/// 返回失败，result为null
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
        public static TResponse<T> Error(string msg)
        {
            return new TResponse<T>() {
                Return_Code = DEFAULT_RETURN_CODE_FAIL,
                Return_Msg = msg
            };
        }

		/// <summary>
		/// 返回失败，result为null
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public static TResponse<T> Error(Exception exception)
		{
			return new TResponse<T>()
			{
				Return_Code = DEFAULT_RETURN_CODE_FAIL,
				Return_Msg = exception.ToString()
			};
		}
	}
}
