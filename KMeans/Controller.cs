using KMeans.Aggregation;
using KMeans.Centroid;
using KMeans.Exceptions;

namespace KMeans;

public class Controller
{
    public Result _result;
    
    public void LoadDataset(string path)
    {
        List<double[]> data = DatasetLoader.LoadDataset(path);
        _result = Result.BuildFromData(data);
    }

    public Result Cluster(int numOfClusters, InitializationMethod initializationMethod,
        AggregationMethod aggregationMethod)
    {
        try
        {
            TryCluster(numOfClusters, initializationMethod, aggregationMethod);
        }
        catch (ClusterException exception)
        {
            _result.ErrorMessage = exception.GetErrorMessage();
        }
        return _result;
    }

    private void TryCluster(int numOfClusters, InitializationMethod initializationMethod,
        AggregationMethod aggregationMethod)
    {
        CheckIfMissingDataset();
        _result = ClusterInitiator.InitiateClusters(_result, numOfClusters);
        
        if (initializationMethod == InitializationMethod.Forgy)
        {
            for (int idCentroid = 0; idCentroid < numOfClusters; idCentroid++)
                _result.Centroids[idCentroid] = (double[])_result.Data[idCentroid].Clone();
        }
        else if (initializationMethod == InitializationMethod.RandomPartition)
        {
            // first, we assign clusters arbitrarily to each observation 
            for (int instanceId = 0; instanceId < _result.GetNumberOfInstances(); instanceId++)
                _result.Clusters[instanceId] = instanceId % numOfClusters;
            
            // Then, we compute the centroids given the arbitrarily assigned cluster
            _result.Centroids = CentroidComputer.ComputeCentroidFromCurrentCluster(aggregationMethod, numOfClusters, _result);
        }
        else
            throw new NotImplementedException();

        // run K-means
        bool converged = false;
        while (!converged)
        {
            _result.Iteration++;
            // Relabelling the instances
            for (int instanceId = 0; instanceId < _result.GetNumberOfInstances(); instanceId++)
            {
                double[] instance = _result.Data[instanceId];
                int newClusterId = -1;
                double distanceToClosestCentroid = Double.PositiveInfinity;
                for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
                {
                    // L2-norm
                    double distanceToCentroid = 0.0;
                    for (int featureId = 0; featureId < _result.GetNumberOfFeatures(); featureId++)
                        distanceToCentroid += Math.Pow(_result.Centroids[clusterId][featureId] - instance[featureId], 2);
                    
                    // updated current cluster
                    if (distanceToCentroid < distanceToClosestCentroid)
                    {
                        distanceToClosestCentroid = distanceToCentroid;
                        newClusterId = clusterId;
                    }
                }
                
                _result.Clusters[instanceId] = newClusterId;
            }

            
            // Recompute centroids as the average positions of the instances that are part of the cluster
            double[][] newCentroids = CentroidComputer.ComputeCentroidFromCurrentCluster(aggregationMethod, numOfClusters, _result);
            
            if (newCentroids == null)
            {
                throw new EmptyClusterException();
            }

            // Updating centroids and checking convergence
            converged = true;
            for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
                for (int featureId = 0; featureId < _result.GetNumberOfFeatures(); featureId++)
                    if (Math.Abs(newCentroids[clusterId][featureId] - _result.Centroids[clusterId][featureId]) > 0.000001)
                        converged = false;
            _result.Centroids = newCentroids;
        }
    }
    private void CheckIfMissingDataset()
    {
        if (_result == null)
        {
            _result = Result.Build();
            throw new MissingDatasetException();
        }
    }
}