namespace Example.DifferentTypeOfObjects;

public static class PrintCollectionCounts
{
    public static void PrintCollectionCountsLogs(string label)
    {
        Console.WriteLine($"{label} Collections -> " +
                          $"Gen0: {GC.CollectionCount(0)}, " +
                          $"Gen1: {GC.CollectionCount(1)}, " +
                          $"Gen2: {GC.CollectionCount(2)}");
    }
}