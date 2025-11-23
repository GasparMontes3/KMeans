namespace KMeans;

public class Controller
{
    public Result _result;
    
    //Primera Resp: Load Data
    public void LoadDataset(string path)
    {
        string[] lines = File.ReadAllLines(path);
        List<double[]> data = new List<double[]>();
        foreach (var l in lines)
        {
            string[] line = l.Split(',');
            double[] instance = new double[line.Length];
            for (int j = 0; j < line.Length; j++)
                instance[j] = Convert.ToDouble(line[j]);
            data.Add(instance);
        }
        _result = Result.BuildFromData(data);
    }

    public Result Cluster(int numOfClusters, InitializationMethod initializationMethod,
        AggregationMethod aggregationMethod)
    {
        // assign initial clusters
        if (_result == null)
        {
            _result = Result.BuildFromError("Dataset not loaded");
            return _result;
        }
        int numOfInstances = _result.Data.Count;
        if (_result.Data.Count == 0)
        {
            _result.ErrorMessage = "Empty dataset";
            return _result;
        }
        int numOfFeatures = _result.Data[0].Length;
        _result.Centroids = new double[numOfClusters][];
        _result.Clusters = new int[numOfInstances];

        if (numOfInstances < numOfClusters)
        {
            _result.ErrorMessage = "Number of instances is less than the number of clusters";
            return _result;
        }

        // initializing the centroids
        if (initializationMethod == InitializationMethod.Forgy)
        {
            for (int idCentroid = 0; idCentroid < numOfClusters; idCentroid++)
                _result.Centroids[idCentroid] = (double[])_result.Data[idCentroid].Clone();
        }
        else if (initializationMethod == InitializationMethod.RandomPartition)
        {
            // first, we assign clusters arbitrarily to each observation 
            for (int instanceId = 0; instanceId < numOfInstances; instanceId++)
                _result.Clusters[instanceId] = instanceId % numOfClusters;
            
            // Then, we compute the centroids given the arbitrarily assigned cluster
            double[][]? newCentroid = ComputeCentroidFromCurrentCluster(aggregationMethod, numOfClusters,
                numOfFeatures, numOfInstances);

            _result.Centroids = newCentroid;
        }
        else
            throw new NotImplementedException();

        // run K-means
        bool converged = false;
        while (!converged)
        {
            _result.Iteration++;
            // Relabelling the instances
            for (int instanceId = 0; instanceId < numOfInstances; instanceId++)
            {
                double[] instance = _result.Data[instanceId];
                int newClusterId = -1;
                double distanceToClosestCentroid = Double.PositiveInfinity;
                for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
                {
                    // L2-norm
                    double distanceToCentroid = 0.0;
                    for (int featureId = 0; featureId < numOfFeatures; featureId++)
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
            double[][]? newCentroids = ComputeCentroidFromCurrentCluster(aggregationMethod,
                numOfClusters, numOfFeatures, numOfInstances);
            if (newCentroids == null)
            {
                _result.ErrorMessage = "Empty cluster";
                return _result;
            }

            // Updating centroids and checking convergence
            converged = true;
            for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
                for (int featureId = 0; featureId < numOfFeatures; featureId++)
                    if (Math.Abs(newCentroids[clusterId][featureId] - _result.Centroids[clusterId][featureId]) > 0.000001)
                        converged = false;
            _result.Centroids = newCentroids;
            
        }
        return _result;
    }

    public double[][]? ComputeCentroidFromCurrentCluster(AggregationMethod aggregationMethod,
        int numOfClusters, int numOfFeatures, int numOfInstances)
    {
        double[][] centroids = new double[numOfClusters][];

        for (int clusterId = 0; clusterId < numOfClusters; clusterId++)
        {
            centroids[clusterId] = new double[numOfFeatures];
            for (int featureId = 0; featureId < numOfFeatures; featureId++)
            {
                // collecting the value of all the features
                List<double> featureValues = new List<double>();
                for (int instanceId = 0; instanceId < numOfInstances; instanceId++)
                    if (_result.Clusters[instanceId] == clusterId)
                        featureValues.Add(_result.Data[instanceId][featureId]);
                
                // if a cluster is empty it means that k-means failed, and we should let the user know
                if (!featureValues.Any())
                    return null;
                        
                // computing the new value for the centroid
                double newCentroidFeature;
                if (aggregationMethod == AggregationMethod.Mean)
                {
                    newCentroidFeature = featureValues.Sum() / featureValues.Count;
                }
                else if (aggregationMethod == AggregationMethod.Median)
                {
                    featureValues.Sort();
                    int midPos = featureValues.Count / 2;
                    if (featureValues.Count % 2 == 1)
                        newCentroidFeature = featureValues[midPos];
                    else
                        newCentroidFeature = (featureValues[midPos - 1] + featureValues[midPos]) / 2.0;
                }
                else
                    throw new NotImplementedException();
                    
                centroids[clusterId][featureId] = newCentroidFeature;
            }
        }

        return centroids;
    }
}