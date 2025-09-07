# GC Hands-On Example (Profiler-Friendly, Fixed Version)

## Overview
This project demonstrates **.NET Garbage Collector (GC) behavior**, including:  

- Gen 0, Gen 1, and Gen 2 collections  
- Large Object Heap (LOH) allocations  
- GC pressure from frequent small and large objects  
- Techniques to reduce GC pressure using **object pooling (`ArrayPool<T>`)**  

The fixed version reuses memory for small and large objects, minimizing unnecessary allocations and improving performance.

---

## Features

- **Small object allocations**: Shows frequent Gen 0 collections and how pooling reduces them.  
- **Large object allocations**: Shows LOH usage and Gen 2 collections, mitigated by pooling.  
- **Combined allocation loop**: Mix of small and occasional large objects, simulating real-world GC pressure.  
- **Forced GC**: Demonstrates memory cleanup after all objects are returned.  
- **Profiler-friendly delays**: Makes memory activity visible in **dotMemory** or similar tools.

---

## Before Fix
Look at the Bytes Size
<img width="1374" height="591" alt="image" src="https://github.com/user-attachments/assets/516f0a32-22ed-4afc-82f6-6fdc338f61f5" />

## After Fix using ArrayPool
Look at the Bytes Size
<img width="1386" height="605" alt="image" src="https://github.com/user-attachments/assets/09365bb9-66e0-46be-a5be-9840a48c7f56" />

