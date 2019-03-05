using System;
namespace com.b_velop.Home.Classes
{
    public class ChiliDto
    {
        public DateTimeOffset Created { get; set; }
        public double Ground { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public bool Heater { get; set; }
        public bool Light { get; set; }
    }
}
