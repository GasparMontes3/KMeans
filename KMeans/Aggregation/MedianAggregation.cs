namespace KMeans.Aggregation;

public class MedianAggregation : IAggregation
{
    public double Aggregate(List<double> featureValues)
    {
        featureValues.Sort();
        int midPos = featureValues.Count / 2;
        if (featureValues.Count % 2 == 1)
            return featureValues[midPos];
        return (featureValues[midPos - 1] + featureValues[midPos]) / 2.0;
    }
}