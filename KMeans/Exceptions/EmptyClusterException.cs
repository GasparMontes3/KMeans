namespace KMeans.Exceptions;

public class EmptyClusterException : ClusterException
{
    public override string GetErrorMessage()
    {
        return "Empty cluster";
    }
}