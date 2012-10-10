namespace WindowsMapsHelper
{
    public sealed class MapBoundingBox
    {
        public MapPosition LowerLeftCorner { get; set; }
        public MapPosition UpperRightCorner { get; set; }

        public MapBoundingBox()
        {
        }

        public MapBoundingBox(MapPosition lowerLeftCorner, MapPosition upperRightCorner)
        {
            UpperRightCorner = upperRightCorner;
            LowerLeftCorner = lowerLeftCorner;
        }
    }
}
