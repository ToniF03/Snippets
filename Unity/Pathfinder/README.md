Pathfinder
==========

Grid-based pathfinding utilities and helper classes used in small Unity demos.

Files:
- `Pathfinder.cs` - pathfinding algorithm implementation
- `PathfinderGridManager.cs` - grid manager and helper types

These files belong together and are used by the example Pathfinder scenes.

Details:
- `Pathfinder.cs` implements an A* search adapted for gravity/jump mechanics and uses a `Node` and `OpenSet` implementation.
- `PathfinderGridManager.cs` initializes and maintains a `PathfinderGridCell[,]` grid and converts between world positions and grid cells.

Usage example (in Unity):
```csharp
// Attach Pathfinder & PathfinderGridManager to the same GameObject
var pf = gameObject.GetComponent<Pathfinder>();
Vector2Int[] path = pf.findPath(startWorldPosition, endWorldPosition, useGravity: true, jumpForce: 2f);
```

Notes:
- The pathfinder depends on grid settings (`gridStart`, `gridSize`, `cellSize`) and Unity physics layers to mark obstacles.
