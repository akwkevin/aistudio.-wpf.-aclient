using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIStudio.Wpf.Service.AppClient.Models
{
    public static class StandardTimeFormatJsonConvertor
    {
        public static JsonSerializerSettings Settings { get; set; } = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss.fff",
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, StandardTimeFormatJsonConvertor.Settings);
        }

        public static string SerializeObject(object value, IEnumerable<string> columns)
        {
            JsonSerializerSettings settings;
            if (columns != null && columns.Count() != 0)
            {
                settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd HH:mm:ss.fff",
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new JsonPropertyContractResolver(columns),
                };
            }
            else
            {
                settings = Settings;
            }
            return JsonConvert.SerializeObject(value, settings);
        }
    }

    /// <summary>
    /// Json分解器
    /// </summary>
    public class JsonPropertyContractResolver : DefaultContractResolver
    {
        IEnumerable<string> lstExclude;
        public JsonPropertyContractResolver(IEnumerable<string> excludedProperties)
        {
            lstExclude = excludedProperties;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).ToList().FindAll(p => lstExclude.Contains(p.PropertyName));//需要输出的属性
        }
    }
}
