namespace Example.DifferentTypeOfObjects;

public class BothLargeAndSmallObjects
{
    public void BothLargeAndSmallObjectMethod()
    {
        List<byte[]> largeObjects = new List<byte[]>();
        Console.WriteLine("\n3. Combined small + large object allocation...");
        for (int i = 0; i < 100_000; i++)
        {
            var small = new byte[500];  // small object
            if (i % 10000 == 0)
            {
                var big = new byte[120_000]; // occasional large object
                largeObjects.Add(big);
            }
            if (i % 5000 == 0) Thread.Sleep(10); 
        }
        PrintCollectionCounts.PrintCollectionCountsLogs("After combined loop");
    }
}