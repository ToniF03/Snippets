MinHeap

Description: Generic MinHeap implementation with add, pop, contains and update operations.

File: `MinHeap.cs`

Details:
- `MinHeap<T>` stores items in a list and maintains a dictionary of positions for O(log n) updates.
- Supports `Add`, `Pop`, `Contains`, and `UpdateKey` (useful when item priority changes).

Usage example:
```csharp
var heap = new uClasses.MinHeap.MinHeap<MyNode>();
heap.Add(node);
var smallest = heap.Pop();
if (heap.Contains(node)) heap.UpdateKey(node);
```

Notes:
- `T` must implement `IComparable<T>` so items can be ordered by priority.
