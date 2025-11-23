namespace KMeans.Tests;

public class ControllerTests
{
    [Theory]
    [InlineData("1D_1.data", "1D_1_3_RandomPartition_Mean.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("1D_1.data", "1D_1_3_RandomPartition_Median.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D_1.data", "1D_1_5_RandomPartition_Mean.result", 5, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("1D_1.data", "1D_1_5_RandomPartition_Median.result", 5, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_1_RandomPartition_Mean.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("1D.data", "1D_1_RandomPartition_Median.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_1_Forgy_Mean.result", 1, InitializationMethod.Forgy, AggregationMethod.Mean)]                        
    [InlineData("1D.data", "1D_1_Forgy_Median.result", 1, InitializationMethod.Forgy, AggregationMethod.Median)]                    
    [InlineData("1D.data", "1D_2_RandomPartition_Mean.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Mean)]    
    [InlineData("1D.data", "1D_2_RandomPartition_Median.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_2_Forgy_Mean.result", 2, InitializationMethod.Forgy, AggregationMethod.Mean)]                        
    [InlineData("1D.data", "1D_2_Forgy_Median.result", 2, InitializationMethod.Forgy, AggregationMethod.Median)]                    
    [InlineData("1D.data", "1D_3_RandomPartition_Mean.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Mean)]    
    [InlineData("1D.data", "1D_3_RandomPartition_Median.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_3_Forgy_Mean.result", 3, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("1D.data", "1D_3_Forgy_Median.result", 3, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_56_RandomPartition_Mean.result", 56, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("1D.data", "1D_57_RandomPartition_Median.result", 57, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("1D.data", "1D_58_Forgy_Mean.result", 58, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("1D.data", "1D_59_Forgy_Median.result", 59, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_1_RandomPartition_Mean.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_1_RandomPartition_Median.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_1_Forgy_Mean.result", 1, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_1_Forgy_Median.result", 1, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_2_RandomPartition_Mean.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_2_RandomPartition_Median.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_2_Forgy_Mean.result", 2, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_2_Forgy_Median.result", 2, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_3_RandomPartition_Mean.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_3_RandomPartition_Median.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("iris.data", "iris_3_Forgy_Mean.result", 3, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("iris.data", "iris_3_Forgy_Median.result", 3, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_1_RandomPartition_Mean.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_1_RandomPartition_Median.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_1_Forgy_Mean.result", 1, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_1_Forgy_Median.result", 1, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_2_RandomPartition_Mean.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_2_RandomPartition_Median.result", 2, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_2_Forgy_Mean.result", 2, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_2_Forgy_Median.result", 2, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_3_RandomPartition_Mean.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_3_RandomPartition_Median.result", 3, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("sepal.data", "sepal_3_Forgy_Mean.result", 3, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData("sepal.data", "sepal_3_Forgy_Median.result", 3, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("empty.data", "empty.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData("empty.data", "empty.result", 1, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData("empty.data", "empty.result", 1, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData("empty.data", "empty.result", 1, InitializationMethod.Forgy, AggregationMethod.Mean)]
    public void Cluster_WhenDataIsLoaded(string dataFileName, string expectedResultFileName, int numberOfClusters,
        InitializationMethod initializationMethod, AggregationMethod aggregationMethod)
    {
        string dataPath = Path.Combine("data", dataFileName);
        string expectedPath = Path.Combine("result", expectedResultFileName);
        Controller controller = new Controller();
        controller.LoadDataset(dataPath);
        Result result = controller.Cluster(numberOfClusters, initializationMethod, aggregationMethod);
        StreamReader reader = new StreamReader(expectedPath);
        string expected = reader.ReadToEnd();
        reader.Close();
        string[] expectedLines = expected.Split('\n');
        string[] resultLines = ResultExporter.Export(result).Split('\n');
        Assert.Equal(expectedLines.Length, resultLines.Length);
        for (int i = 0; i < expectedLines.Length; i++)
            Assert.Equal(expectedLines[i], resultLines[i]);
    }

    [Theory]
    [InlineData(0, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData(1, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData(2, InitializationMethod.Forgy, AggregationMethod.Mean)]
    [InlineData(3, InitializationMethod.Forgy, AggregationMethod.Median)]
    [InlineData(0, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData(1, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    [InlineData(2, InitializationMethod.RandomPartition, AggregationMethod.Mean)]
    [InlineData(3, InitializationMethod.RandomPartition, AggregationMethod.Median)]
    public void Cluster_WhenDataIsNotLoaded(int numberOfClusters, InitializationMethod initializationMethod, AggregationMethod aggregationMethod)
    {
        string expectedPath = Path.Combine("result", "no_data.result");
        Controller controller = new Controller();
        Result result = controller.Cluster(numberOfClusters, initializationMethod, aggregationMethod);
        StreamReader reader = new StreamReader(expectedPath);
        string expected = reader.ReadToEnd();
        reader.Close();
        string[] expectedLines = expected.Split('\n');
        string[] resultLines = ResultExporter.Export(result).Split('\n');
        Assert.Equal(expectedLines.Length, resultLines.Length);
        for (int i = 0; i < expectedLines.Length; i++)
            Assert.Equal(expectedLines[i], resultLines[i]);
    }
}