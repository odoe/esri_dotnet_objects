namespace com.esri.ags.tasks
{
    public class FeatureSet
    {
        public FeatureSet() { }

        public FeatureSet(Feature[] features)
        {
            this.features = features;
        }

        public Feature[] features { get; set; }
    }
}
