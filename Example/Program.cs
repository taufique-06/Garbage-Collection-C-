using Example.DifferentTypeOfObjects;

Console.WriteLine("=== GC Hands-On Example ===\n");

// Print initial collection counts
PrintCollectionCounts.PrintCollectionCountsLogs("Initial");

var smallObj = new SmallObjects();
smallObj.SmallObjectMethod();

var largeObj = new LargeObjects();
largeObj.LargeObjectMethod();

var both = new BothLargeAndSmallObjects();
both.BothLargeAndSmallObjectMethod();

Console.WriteLine("\n4. Forcing full GC...");
GC.Collect();
GC.WaitForPendingFinalizers();
PrintCollectionCounts.PrintCollectionCountsLogs("After forced GC");

Console.WriteLine("\n=== End of Example ===");
Console.WriteLine("Press Enter to exit...");
Console.ReadLine();