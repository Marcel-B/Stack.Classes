using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.b_velop.stack.Classes
{
    public partial class Welcome
    {
        public static List<ChiliValues> FromJson(string json) 
        => JsonConvert.DeserializeObject<List<ChiliValues>>(json, Converter.Settings);
    }
}
