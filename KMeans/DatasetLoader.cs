namespace KMeans;

public static class DatasetLoader
{
    public static List<double[]> LoadDataset(string path)
    {
        string[] lines = File.ReadAllLines(path);
        List<double[]> data = new List<double[]>();
        foreach (var l in lines)
        {
            string[] line = l.Split(',');
            double[] instance = new double[line.Length];
            for (int j = 0; j < line.Length; j++)
                instance[j] = Convert.ToDouble(line[j]);
            data.Add(instance);
        }
        return data;
    }
}