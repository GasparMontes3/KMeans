namespace KMeans.Centroid;

public class RandomPartition : ICentroid
{
    public double[][] GetCentroid()
    {
        /*
        // first, we assign clusters arbitrarily to each observation 
        for (int instanceId = 0; instanceId < _result.GetNumberOfInstances(); instanceId++)
            _result.Clusters[instanceId] = instanceId % numOfClusters;
            
        // Then, we compute the centroids given the arbitrarily assigned cluster
        double[][]? newCentroid = ComputeCentroidFromCurrentCluster(aggregationMethod, numOfClusters,
            numOfFeatures, _result.GetNumberOfInstances());

        _result.Centroids = newCentroid;
        */
        return new double[1][];
    }
}