using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.b_velop.Home.Classes
{
    public static class SerializeValue
    {
        public static string ToJson(this List<ChiliValues> self) 
            => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}


