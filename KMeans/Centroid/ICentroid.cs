namespace KMeans.Centroid;

public interface ICentroid
{
    public Result GetCentroid(Result result, int numOfClusters, AggregationMethod aggregationMethod);
}