using KMeans;

// NO ES NECESARIO LIMPIAR ES CÓDIGO.
// ES SOLO PARA AYUDARTE A DEBUGGEAR.

Dictionary<string, InitializationMethod> centroidInitializationMethods = new()
{
    ["RandomPartition"] = InitializationMethod.RandomPartition,
    ["Forgy"] = InitializationMethod.Forgy
};
Dictionary<string, AggregationMethod> centroidCalculationMethods = new()
{
    ["Mean"] = AggregationMethod.Mean,
    ["Median"] = AggregationMethod.Median
};

string dataFile = "1D"; // null, "1D", "iris", "sepal", "empty", "1D_1"
string initKey = "RandomPartition";
string calcKey = "Mean";
int numberOfClusters = 56;
Controller controller = new Controller();

if (dataFile != null) {
    string path = Path.Combine("data", $"{dataFile}.data");
    controller.LoadDataset(path);
}

Result result = controller.Cluster(numberOfClusters, centroidInitializationMethods[initKey], centroidCalculationMethods[calcKey]);

string expectedFile;
if (dataFile == null) {
    expectedFile = "no_data";
}
else if (dataFile == "empty")
    expectedFile = "empty";
else
    expectedFile = $"{dataFile}_{numberOfClusters}_{initKey}_{calcKey}";

string expectedPath = Path.Combine("result", $"{expectedFile}.result");

StreamReader reader = new StreamReader(expectedPath);
string expected = reader.ReadToEnd();
reader.Close();
string[] expectedLines = expected.Split('\n');
string[] resultLines = ResultExporter.Export(result).Split('\n');
if (expectedLines.Length != resultLines.Length)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Las lineas no coinciden");
}

Console.ForegroundColor = ConsoleColor.Blue;
for (int i = 0; i < expectedLines.Length; i++)
{
    if (expectedLines[i] != resultLines[i])
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(resultLines[i]);
        Console.WriteLine($"[ERROR] el valor esperado acá era: \"{expectedLines[i]}\"");
        break;
    }

    Console.WriteLine(expectedLines[i]);
}

