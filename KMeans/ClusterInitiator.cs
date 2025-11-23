using KMeans.Exceptions;

namespace KMeans;

public class ClusterInitiator
{
    public Result InitiateClusters(Result result, int numOfClusters)
    {
        if (result == null)
        {
            result = Result.Build();
            throw new MissingDatasetException();
        }
        int numOfInstances = result.Data.Count;
        if (result.Data.Count == 0)
        {
            throw new EmptyDatasetException();
        }
        int numOfFeatures = result.Data[0].Length;
        result.Centroids = new double[numOfClusters][];
        result.Clusters = new int[numOfInstances];

        if (numOfInstances < numOfClusters)
        {
            throw new NotEnoughInstancesException();
        }
        return result;
    }
}