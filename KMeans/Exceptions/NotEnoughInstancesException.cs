namespace KMeans.Exceptions;

public class NotEnoughInstancesException : ClusterException
{
    public override string GetErrorMessage()
    {
        return "Number of instances is less than the number of clusters";
    }
}