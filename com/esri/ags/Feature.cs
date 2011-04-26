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

        public IGeometry geometry { get; set; }
        public Object attributes { get; set; }
    }
}
