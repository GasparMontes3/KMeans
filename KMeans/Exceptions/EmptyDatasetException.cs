namespace KMeans.Exceptions;

public class EmptyDatasetException : ClusterException
{
    public override string GetErrorMessage()
    {
        return "Empty dataset";
    }
}