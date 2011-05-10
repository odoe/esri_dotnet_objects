using System;
using System.Collections;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace net.odoe.geo.helpers
{
    public class FeatureHelper
    {
        private IProjectedCoordinateSystem2 m_PCSout;
        private com.esri.ags.SpatialReference m_sr;

        public FeatureHelper()
        {
            Type factoryType = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment");
            System.Object obj = Activator.CreateInstance(factoryType);
            ISpatialReferenceFactory2 srf = obj as ISpatialReferenceFactory2;
            m_PCSout = new ESRI.ArcGIS.Geometry.ProjectedCoordinateSystemClass();
            m_PCSout = (IProjectedCoordinateSystem2)srf.CreateProjectedCoordinateSystem((int)esriSRProjCS3Type.esriSRProjCS_WGS1984WebMercatorMajorAuxSphere);
            // 102100 is equivalent to esriSRProjCS_WGS1984WebMercatorMajorAuxSphere
            m_sr = new com.esri.ags.SpatialReference(102100);
        }
        public com.esri.ags.Feature featureToPolygon(IFeature feat)
        {
            // first, reproject the geometry to web projection for use in Flex/Silverlight/Javascript apps
            IGeometry m_geom = feat.Shape;
            m_geom.Project(m_PCSout as ISpatialReference);
            com.esri.ags.geometry.Polygon pg = extractPolygon(m_geom);
            Hashtable attributes = extractAttributes(feat);

            return new com.esri.ags.Feature(pg, (object)attributes);
        }

        public com.esri.ags.Feature featureToPolyline(IFeature feat)
        {
            IGeometry m_geom = feat.Shape;
            m_geom.Project(m_PCSout as ISpatialReference);
            com.esri.ags.geometry.Polyline pl = extractPolyline(m_geom);
            Hashtable attributes = extractAttributes(feat);
            return new com.esri.ags.Feature(pl, (object)attributes);
        }

        public com.esri.ags.Feature featureToMapPoint(IFeature feat)
        {
            IGeometry m_geom = feat.Shape;
            m_geom.Project(m_PCSout as ISpatialReference);
            com.esri.ags.geometry.MapPoint mp = extractMapPoint(m_geom);
            Hashtable attributes = extractAttributes(feat);
            return new com.esri.ags.Feature(mp, (object)attributes);
        }

        private com.esri.ags.geometry.Polyline extractPolyline(IGeometry geom)
        {
            Polyline line = (Polyline)geom;
            int count = line.PointCount;
            com.esri.ags.geometry.MapPoint[] path = new com.esri.ags.geometry.MapPoint[count];
            for (int i = 0; i < count; i++)
            {
                IPoint pt = line.get_Point(i);
                path[i] = new com.esri.ags.geometry.MapPoint(pt.X, pt.Y, m_sr);
            }
            com.esri.ags.geometry.Polyline pl = new com.esri.ags.geometry.Polyline();
            pl.paths = new com.esri.ags.geometry.MapPoint[1][];
            pl.paths[0] = path;
            return pl;
        }

        private com.esri.ags.geometry.MapPoint extractMapPoint(IGeometry geom)
        {
            IPoint pt = (IPoint)geom;
            return new com.esri.ags.geometry.MapPoint(pt.X, pt.Y, m_sr);
        }

        private com.esri.ags.geometry.Polygon extractPolygon(IGeometry geom)
        {
            Polygon poly = (Polygon)geom;
            int count = poly.PointCount;
            com.esri.ags.geometry.MapPoint[] mp = new com.esri.ags.geometry.MapPoint[count];
            for (int i = 0; i < count; i++)
            {
                IPoint pt = poly.get_Point(i);
                mp[i] = new com.esri.ags.geometry.MapPoint(pt.X, pt.Y, m_sr);
            }
            com.esri.ags.geometry.Polygon pg = new com.esri.ags.geometry.Polygon();
            pg.rings = new com.esri.ags.geometry.MapPoint[1][];
            pg.rings[0] = mp;
            return pg;
        }

        private Hashtable extractAttributes(IFeature feat)
        {
            Hashtable attributes = new Hashtable();
            int fieldCount = feat.Fields.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                IField field = feat.Fields.get_Field(i);
                attributes.Add(field.Name, feat.get_Value(i));
            }
            return attributes;
        }
    }
}
