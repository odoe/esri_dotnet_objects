using System;

namespace com.esri.ags.geometry
{
    public class Polygon : IGeometry
    {
        public Polygon() { }

        public MapPoint[][] rings { get; set; }
    }
}
