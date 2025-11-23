namespace KMeans.Centroid;

public static class CentroidFactory
{
    public static ICentroid Initialize(InitializationMethod initializationMethod)
    {
        switch (initializationMethod)
        {
            case InitializationMethod.Forgy:
                return new Forgy();
            case InitializationMethod.RandomPartition:
                return new RandomPartition();
            default:
                throw new NotImplementedException();
        }
    }
}