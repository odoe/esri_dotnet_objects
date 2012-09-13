using System;
using com.esri.ags.geometry;

namespace com.esri.ags
{
    public class Feature
    {
        public Feature(){ }
        public Feature(IGeometry geometry, Object attributes)
        {
            this.geometry = geometry;
            this.attributes = attributes;
        }

        public Feature(IGeometry geometry, Object attributes, SpatialReference sr)
        {
            this.geometry = geometry;
            this.attributes = attributes;
            this.spatialReference = sr;
        }

        public IGeometry geometry { get; set; }
        public Object attributes { get; set; }
        public SpatialReference spatialReference { get; set; }
    }
}
