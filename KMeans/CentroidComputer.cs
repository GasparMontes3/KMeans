using KMeans.Aggregation;

namespace KMeans;

public static class CentroidComputer
{
    public static double[][]? ComputeCentroidFromCurrentCluster(AggregationMethod aggregationMethod,
        int numOfClusters, Result result)
    {
        double[][] centroids = new double[numOfClusters][];

        for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
        {
            centroids[clusterId] = new double[result.GetNumberOfFeatures()];
            for (int featureId = 0; featureId < result.GetNumberOfFeatures(); featureId++)
            {
                // collecting the value of all the features
                List<double> featureValues = new List<double>();
                for (int instanceId = 0; instanceId < result.GetNumberOfInstances(); instanceId++)
                    if (result.Clusters[instanceId] == clusterId)
                        featureValues.Add(result.Data[instanceId][featureId]);
                
                // if a cluster is empty it means that k-means failed, and we should let the user know
                if (!featureValues.Any())
                    return null;
                        
                // computing the new value for the centroid
                IAggregation aggregation = AggregationFactory.Create(aggregationMethod);
                double newCentroidFeature = aggregation.Aggregate(featureValues);
                    
                centroids[clusterId][featureId] = newCentroidFeature;
            }
        }

        return centroids;
    }
}