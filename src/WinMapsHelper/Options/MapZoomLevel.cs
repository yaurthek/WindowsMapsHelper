using System;

namespace WindowsMapsHelper
{
    public sealed class MapZoomLevel
    {
        private static readonly MapZoomLevel MinZoomLevel = new MapZoomLevel(1);
        private static readonly MapZoomLevel MaxZoomLevel = new MapZoomLevel(20);

        public double ZoomLevel { get; private set; }

        public static MapZoomLevel MinZoom { get { return MinZoomLevel; } }
        public static MapZoomLevel MaxZoom { get { return MaxZoomLevel; } }
        public static MapZoomLevel DefaultZoom { get { return null; } }

        public MapZoomLevel(double zoomLevel)
        {
            if (zoomLevel < 1 || zoomLevel > 20)
                throw new ArgumentOutOfRangeException("Zoom level is out of range (1-20)");

            ZoomLevel = zoomLevel;
        }
    }
}
