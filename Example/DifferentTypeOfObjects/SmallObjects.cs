namespace Example.DifferentTypeOfObjects;

public class SmallObjects
{
    public void SmallObjectMethod()
    {
        Console.WriteLine("\n1. Allocating many small objects (Gen0)...");
        for (int i = 0; i < 1_000_000; i++)
        {
            var temp = new byte[100];
            if (i % 1000 == 0) Thread.Sleep(1); 
        }
        PrintCollectionCounts.PrintCollectionCountsLogs("After small objects");
    }
}