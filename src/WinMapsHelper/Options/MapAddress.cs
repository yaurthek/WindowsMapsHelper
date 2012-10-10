using System;

namespace WindowsMapsHelper
{
    public sealed class MapAddress : IMapPoint
    {
        public string Address { get; set; }

        public MapAddress(string address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return String.Format("adr.{0}", Address);
        }
    }
}
