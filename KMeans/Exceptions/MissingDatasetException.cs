namespace KMeans.Exceptions;

public class MissingDatasetException : ClusterException
{
    public override string GetErrorMessage()
    {
        return "Dataset not loaded";
    }
}