namespace KMeans.Centroid;

public class Forgy : ICentroid
{
    public double[][] GetCentroid()
    {
        /*for (int idCentroid = 0; idCentroid < numOfClusters; idCentroid++)
            _result.Centroids[idCentroid] = (double[])_result.Data[idCentroid].Clone();
            */
        return new double[2][];
    }
}