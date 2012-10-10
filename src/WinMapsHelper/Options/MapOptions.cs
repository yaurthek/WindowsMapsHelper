namespace WindowsMapsHelper
{
    public enum MapViewStyle { Default, Aerial, Road }

    public sealed class MapOptions
    {
        public MapPosition CenterPoint { get; set; }
        public MapZoomLevel ZoomLevel { get; set; }
        public MapBoundingBox BoundingBox { get; set; }

        public MapViewStyle ViewStyle { get; set; }
        public bool ShowTraffic { get; set; }

        public MapOptions()
        {
            ViewStyle = MapViewStyle.Default;
        }
    }
}
