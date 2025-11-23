namespace KMeans.Aggregation;

public static class AggregationFactory
{
    public static IAggregation Create(AggregationMethod aggregationMethod)
    {
        switch (aggregationMethod)
        {
            case AggregationMethod.Mean:
                return new MeanAggregation();
            case AggregationMethod.Median:
                return new MedianAggregation();
            default:
                throw new NotImplementedException();
        }
    }
}