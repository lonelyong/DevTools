using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShortUrl.Logic.Apis
{
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public abstract class ResultBase
    {
        public const string DEFAULT_RETURN_CODE_SUCCESS = "SUCCESS";

        public const string DEFAULT_RETURN_CODE_FAIL = "FAIL";

        public const string DEFAULT_RETURN_MSG_OK = "OK";

        [XmlElement("return_code")]
        public string Return_Code { get; set; }

        [XmlElement("return_msg")]
        public string Return_Msg { get; set; } 
    }
}
