﻿using Newtonsoft.Json;

namespace com.b_velop.stack.Classes
{
    public partial class ChiliValues
    {
        [JsonProperty("measurement")]
        public string Measurement { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
}
