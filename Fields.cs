using Newtonsoft.Json;

namespace com.b_velop.stack.Classes
{
    public partial class Fields
    {
        [JsonProperty("dallas.ground")]
        public double DallasGround { get; set; }

        [JsonProperty("dht22.temp")]
        public double Dht22Temp { get; set; }

        [JsonProperty("dht22.hum")]
        public double Dht22Hum { get; set; }

        [JsonProperty("heater")]
        public bool Heater { get; set; }

        [JsonProperty("light")]
        public bool Light { get; set; }
    }
}
