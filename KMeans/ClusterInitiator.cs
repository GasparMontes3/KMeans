using KMeans.Exceptions;

namespace KMeans;

public static class ClusterInitiator
{
    public static Result InitiateClusters(Result result, int numOfClusters)
    {
        if (result.Data.Count == 0)
        {
            throw new EmptyDatasetException();
        }
        result.Centroids = new double[numOfClusters][];
        result.Clusters = new int[result.GetNumberOfInstances()];

        if (result.GetNumberOfInstances() < numOfClusters)
        {
            throw new NotEnoughInstancesException();
        }
        return result;
    }
}