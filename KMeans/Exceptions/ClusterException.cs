namespace KMeans.Exceptions;

public abstract class ClusterException : ApplicationException
{
    public abstract string GetErrorMessage();
}