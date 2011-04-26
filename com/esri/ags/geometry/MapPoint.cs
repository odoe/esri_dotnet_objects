using System;

namespace com.esri.ags.geometry
{
    public class MapPoint : IGeometry
    {
        public MapPoint() { }

        public MapPoint(Double x, Double y)
        {
            this.x = x;
            this.y = y;
        }

        public MapPoint(Double x, Double y, SpatialReference spatialReference)
        {
            this.spatialReference = spatialReference;
            this.x = x;
            this.y = y;
        }

        public Double x { get; set; }
        public Double y { get; set; }
        public SpatialReference spatialReference { get; set; }
    }
}
