using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.b_velop.stack.Classes
{
    internal static class ConverterValue
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
