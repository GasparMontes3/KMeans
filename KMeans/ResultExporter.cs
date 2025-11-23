namespace KMeans;

public static class ResultExporter
{
    private static string _message = "";
    private static Dictionary<int, List<double[]>> _clusterDataMap = new();
    public static string Export(Result result)
    {
        _message = "Iteration Counter: " + result.Iteration + "\n";
        if (result.HasError())
        {
            AddErrorToMessage(result);
        }
        else
        {
            AddDataToMap(result);
            AddClustersToMessage(result);
        }
        // WARNING: This is a workaround to pass the tests regardless of the IDE language settings
        return _message.Replace(',', '.');
    }
    
    private static void AddErrorToMessage(Result result)
    {
        _message += $"Error: {result.ErrorMessage}\n";
    }
    
    private static void AddDataToMap(Result result)
    {
        _clusterDataMap = new Dictionary<int, List<double[]>>();
        for (int instanceId = 0; instanceId < result.Data.Count; instanceId++)
        {
            int clusterId = result.Clusters[instanceId];
            if (!_clusterDataMap.ContainsKey(clusterId))
                _clusterDataMap[clusterId] = new List<double[]>();
            _clusterDataMap[clusterId].Add(result.Data[instanceId]);
        }
    }

    private static void AddClustersToMessage(Result result)
    {
        for (int i = 0; i < result.Centroids.Length; i++)
        {
            _message += $"Cluster {i + 1}: \n";
            AddCentroidToMessage(i, result);
            AddInstancesToMessage(i);
        }
    }

    private static void AddCentroidToMessage(int clusterId, Result result)
    {
        _message += "\tCentroid: ";
        for (int j = 0; j < result.Centroids[clusterId].Length; j++)
            _message += $"{result.Centroids[clusterId][j]:F2} ";
        _message += "\n";
    }
    
    private static void AddInstancesToMessage(int clusterId)
    {
        _message += "\tInstances:\n";
        foreach (var instance in _clusterDataMap[clusterId])
        {
            _message += "\t";
            foreach (var feature in instance)
                _message += $"{feature:F2} ";
            _message += "\n";
        }
    }
}