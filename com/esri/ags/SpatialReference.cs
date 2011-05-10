namespace com.esri.ags
{
    public class SpatialReference
    {
        public SpatialReference() { }
        public SpatialReference(int wkid)
        {
            this.wkid = wkid;
        }
        public SpatialReference(int wkid, string wkt)
        {
            this.wkid = wkid;
            this.wkt = wkt;
        }

        public int wkid { get; set; }
        public string wkt { get; set; }
    }
}
