// This is just a sample of how you can use the net.odoe.geo.helpers.FeatureHelper class
// to turn your Features into ESRI Flex Compatible objects
public FeatureSet GetSampleMapPoint(string[] fieldValues)
{
	// initialize the license
	IAoInitialize AoInitializer = null; // do what you do to initialize your license
	IFeatureClass featureClass = null; // do whatever you do to build a fFeatureClass
	List<com.esri.ags.Feature> sampleFeatures = new List<com.esri.ags.Feature>();

	IQueryFilter qf = new QueryFilterClass();
	qf.SubFields = "*";
	string valueStrings = string.Join("','", fieldValues);
	qf.WhereClause = "FIELDNAME IN ('" + valueStrings + "')";
	net.odoe.geo.helpers.FeatureHelper featHelper = new net.odoe.geo.helpers.FeatureHelper();
	using (ComReleaser comReleaser = new ComReleaser())
	{
		IFeatureCursor fc = null;
		try
		{
			fc = featureClass.Search(qf, true);
			comReleaser.ManageLifetime(fc);
		}
		catch (Exception e)
		{
			throw new Exception(String.Format("GetSampleMapPoint Query Error, query string = {0} || {1} || {2}", valueStrings, e.Message, e.StackTrace), e);
		}

		IFeature feat = null;
		while ((feat = fc.NextFeature()) != null)
		{
			try
			{
				sampleFeatures.Add(featHelper.featureToMapPoint(feat));
			}
			catch (Exception e)
			{
				throw new Exception(String.Format("GetSampleMapPoint  from Shape Error: {0} || {1}", e.Message, e.StackTrace), e);
			}
		}
	}
	return new FeatureSet(sampleFeatures.ToArray());
}