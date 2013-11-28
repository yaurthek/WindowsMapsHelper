using System;
using System.Globalization;

namespace WindowsMapsHelper
{
    public sealed class MapPosition : IMapPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public MapPosition(double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public override string ToString()
        {
            return FormatCoordinates("pos.", "_");
        }

        internal string ToPointString()
        {
            return FormatCoordinates(String.Empty, "~");
        }

        private string FormatCoordinates(string prefix, string delimeter)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}{1:0.000000}{2}{3:0.000000}", prefix, Latitude, delimeter, Longitude);
        }

    }
}
