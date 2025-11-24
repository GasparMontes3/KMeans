namespace KMeans.Centroid;

public class Forgy : ICentroid
{
    public Result GetCentroid(Result result, int numOfClusters, AggregationMethod aggregationMethod)
    {
        for (int idCentroid = 0; idCentroid < numOfClusters; idCentroid++)
            result.Centroids[idCentroid] = (double[])result.Data[idCentroid].Clone();
        return result;
    }
}