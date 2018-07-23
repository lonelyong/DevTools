using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ShortUrl.Api.Common.Utils
{
    public static class JsonHelper
    {
        public static JsonSerializerSettings LowerCaseSerializerSettings { get; } = new JsonSerializerSettings()
        {
            ContractResolver = new LowerCaseContractResolver()
        };

        public static string Serialize(object obj) 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, LowerCaseSerializerSettings);
        }
    }

    public class LowerCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }

        public static LowerCaseContractResolver Default { get; } = new LowerCaseContractResolver();
    }
}
