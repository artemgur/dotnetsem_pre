using DatabaseCSharp;

#nullable disable

namespace DatabaseModel
{
    public partial class Mobile
    {
        public int? ProductId { get; set; }
        public short? Ram { get; set; }
        public int? Memory { get; set; }
        public int? ScreenDiagonal { get; set; }
        public short? OsVersion { get; set; }
        public int? ScreenX { get; set; }
        public int? ScreenY { get; set; }
        public int? SizeX { get; set; }
        public int? SizeY { get; set; }
        public int? SizeZ { get; set; }
        public int? BatteryCapacity { get; set; }
        public string Processor { get; set; }
        public short? ProcessorCores { get; set; }
        public int? ProcessorClockRate { get; set; }
        public short? Camera { get; set; }
        public short? FrontCamera { get; set; }
        public bool? OpticalStabilization { get; set; }
        
        public OSMobile OSMobile { get; set; }
    }
}
