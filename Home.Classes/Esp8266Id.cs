using System;

namespace com.b_velop.Home.Classes
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
        public static string MaxMicroFk() => "2063272:max_micro";//{ get; set; }
        public static string MinMicroFk() => "2063272:min_micro";//{ get; set; }
        public static string SamplesFk() => "2063272:samples";//{ get; set; }
        //public static Guid SdsP1Fk() => Guid.Parse("366AA12C-8C22-4293-82F2-44C3E6CDBB47");
        //public static Guid SdsP2Fk() => Guid.Parse("60AAF555-F83D-482B-B23A-507561FCC0D0");
        //public static Guid HumidityFk() => Guid.Parse("7528590B-3528-4722-96DA-7BF3A1EC2951");
        //public static Guid TemperatureFk() => Guid.Parse("B08220A1-5E01-45CE-A68E-A19B17BB2D18");
        //public static Guid PressureFk() => Guid.Parse("143F6D37-FF07-44EE-8268-F07D530DB352");
        //public static Guid TemperatureBmpFk() => Guid.Parse("47B28EDB-C604-4220-8869-F6FAFB21BE91");
    }
}
