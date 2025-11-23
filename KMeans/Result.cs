namespace KMeans;

public class Result
{
    public string? ErrorMessage;
    public int Iteration = 0;
    public double[][] Centroids;
    public readonly List<double[]> Data;
    public int[] Clusters;
    
    public static Result BuildFromData(List<double[]> data)
    {
        return new Result(data);
    }
    
    private Result(List<double[]> data)
    {
        Data = data;
    }
    
    public static Result BuildFromError(string errorMessage)
    {
        return new Result(errorMessage);
    }

    private Result(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
    
    public bool HasError()
    {
        return ErrorMessage != null;
    }
}