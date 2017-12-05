using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShortUrl.Logic.Apis
{
    [Serializable]
    [XmlRoot("xml")]
    public class ZipUrlResult : ResultBase
    {
        [XmlElement(ElementName = "result")]
        public string Result { get; set; }
    }
}
