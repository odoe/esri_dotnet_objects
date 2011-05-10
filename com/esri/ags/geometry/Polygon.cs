namespace com.esri.ags.geometry
{
    public class Polygon : IGeometry
    {
        public Polygon() { }
        public Polygon(MapPoint[][] rings)
        {
            this.rings = rings;
        }

        public MapPoint[][] rings { get; set; }
    }
}