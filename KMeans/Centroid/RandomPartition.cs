namespace KMeans.Centroid;

public class RandomPartition : ICentroid
{
    public Result GetCentroid(Result result, int numOfClusters, AggregationMethod aggregationMethod)
    {
        // first, we assign clusters arbitrarily to each observation 
        for (int instanceId = 0; instanceId < result.GetNumberOfInstances(); instanceId++)
            result.Clusters[instanceId] = instanceId % numOfClusters;
            
        // Then, we compute the centroids given the arbitrarily assigned cluster
        result.Centroids = CentroidComputer.ComputeCentroidFromCurrentCluster(aggregationMethod, numOfClusters, result);
        return result;
    }
}