using System;

namespace com.b_velop.stack.Classes
{

    public class Esp8266Id
    {
        public Esp8266Id()
        {
            SdsP1 = -9999;
            SdsP2 = -9999;
            Humidity = -9999;
            Temperature = -9999;
            Pressure = -9999;
            TemperatureBmp = -9999;
        }

        public DateTimeOffset Time { get; set; }
        public double SdsP1 { get; set; }
        public double SdsP2 { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double TemperatureBmp { get; set; }
        public double MaxMicro {get;set;}
        public double MinMicro {get;set;}
        public double Samples {get;set;}
        public double Signal {get;set;}
        
        public static string SdsP1Fk() => "2063272:SDS_P1";
        public static string SdsP2Fk() => "2063272:SDS_P2"; 
        public static string HumidityFk() => "2063272:humidity";
        public static string TemperatureFk() => "2063272:temperature";
        public static string PressureFk() => "2063272:BMP_pressure";
        public static string TemperatureBmpFk() => "2063272:BMP_temperature";
        public static string SignalFk() => "2063272:signal";
        public static string MaxMicroFk() => "2063272:max_micro";
        public static string MinMicroFk() => "2063272:min_micro";
        public static string SamplesFk() => "2063272:samples";
    }
}
