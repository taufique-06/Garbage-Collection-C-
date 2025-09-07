namespace Example.DifferentTypeOfObjects;

public class LargeObjects
{
    public void LargeObjectMethod()
    {
        Console.WriteLine("\n2. Allocating large objects (LOH → Gen2)...");
        List<byte[]> largeObjects = new List<byte[]>();
        for (int i = 0; i < 50; i++)
        {
            var big = new byte[100_000]; // ~100 KB → LOH
            largeObjects.Add(big);       // keep references alive
            Thread.Sleep(50);  
        }
        PrintCollectionCounts.PrintCollectionCountsLogs("After large objects");
    }
}