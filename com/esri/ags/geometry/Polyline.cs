namespace com.esri.ags.geometry
{
    public class Polyline : IGeometry
    {
        public Polyline() { }
        public Polyline(MapPoint[][] paths)
        {
            this.paths = paths;
        }
        public MapPoint[][] paths { get; set; }
    }
}