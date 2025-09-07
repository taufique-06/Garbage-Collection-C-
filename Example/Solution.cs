using System.Buffers;
using Example.DifferentTypeOfObjects;

namespace Example;

public class Solution
{
    public void Execute()
    {
        Console.WriteLine("=== Fixed GC Profiler-Friendly Example ===\n");

        PrintCollectionCounts.PrintCollectionCountsLogs("Initial");

        Console.WriteLine("\n1. Allocating many small objects (Gen0) using ArrayPool...");
        for (int i = 0; i < 50_000; i++)
        {
            var temp = ArrayPool<byte>.Shared.Rent(100);
            temp[0] = 1;

            ArrayPool<byte>.Shared.Return(temp);
            if (i % 1000 == 0) Thread.Sleep(1);
        }

        PrintCollectionCounts.PrintCollectionCountsLogs("After small objects");

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("\n2. Allocating large objects using ArrayPool...");
        for (int i = 0; i < 20; i++)
        {
            var big = ArrayPool<byte>.Shared.Rent(100_000);
            big[0] = 1;

            ArrayPool<byte>.Shared.Return(big);
            Thread.Sleep(50);
        }

        PrintCollectionCounts.PrintCollectionCountsLogs("After large objects");

        Console.WriteLine("\n3. Combined small + occasional large objects using pooling...");
        for (int i = 0; i < 20_000; i++)
        {
            // Small object
            var small = ArrayPool<byte>.Shared.Rent(500);
            small[0] = 1;
            ArrayPool<byte>.Shared.Return(small);

            if (i % 1000 == 0)
            {
                var big = ArrayPool<byte>.Shared.Rent(120_000);
                big[0] = 1;
                ArrayPool<byte>.Shared.Return(big);
            }

            if (i % 5000 == 0) Thread.Sleep(10);
        }

        PrintCollectionCounts.PrintCollectionCountsLogs("After combined allocations");

        Console.WriteLine("\n4. Forcing full GC...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        PrintCollectionCounts.PrintCollectionCountsLogs("After forced GC");

        Console.WriteLine("\n=== End of Fixed Example ===");
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();
    }
}