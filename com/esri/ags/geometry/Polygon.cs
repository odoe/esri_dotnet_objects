namespace com.esri.ags.geometry
{
    public class Polygon : IGeometry
    {
        public Polygon() { }
        public Polygon(double[][][,] rings)
        {
            this.rings = rings;
        }
        public double[][][,] rings { get; set; }
    }
}