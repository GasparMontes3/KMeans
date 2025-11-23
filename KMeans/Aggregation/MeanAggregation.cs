namespace KMeans.Aggregation;

public class MeanAggregation : IAggregation
{
    public double Aggregate(List<double> featureValues)
    {
        return featureValues.Sum() / featureValues.Count;
    }
}