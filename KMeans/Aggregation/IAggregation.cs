namespace KMeans.Aggregation;

public interface IAggregation
{
    public double Aggregate(List<double> featureValues);
}