using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace com.b_velop.Home.Classes
{
    public partial class Airdata
    {
        [JsonProperty("sensordatavalues")]
        public List<Sensordatavalue> Sensordatavalues { get; set; }

        [JsonProperty("software_version")]
        public string SoftwareVersion { get; set; }

        [JsonProperty("esp8266id")]
        public string Esp8266Id { get; set; }
    }

    public partial class Sensordatavalue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("value_type")]
        public string ValueType { get; set; }
    }

    public partial class Airdata
    {
        public static Airdata FromJson(string json) => JsonConvert.DeserializeObject<Airdata>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Airdata self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
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
