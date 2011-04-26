using System;

namespace com.esri.ags.geometry
{
    public class Polyline : IGeometry
    {
        public Polyline() { }
        public MapPoint[] paths { get; set; }
    }
}
