using System;
using UnityEngine;

/// <summary>
/// Manages the grid for the pathfinding system, including grid initialization, updating, and drawing.
/// </summary>
public class PathfinderGridManager : MonoBehaviour
{
    [SerializeField] private bool drawGizmos;
    [SerializeField] private bool drawGrid;
    [SerializeField] private bool drawGridCells;
    private PathfinderGridCell[,] _grid;

    public float cellSize = 1;
    public Vector2 gridStart;
    public Vector2Int gridSize;

    void Start()
    {
        UpdateGrid();
    }

    void Update()
    {
        if (_grid == null)
            UpdateGrid();

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            UpdateGrid();
        }
    }

    /// <summary>
    /// Retrieves the cell at the given grid position.
    /// </summary>
    /// <param name="position">The grid position of the cell.</param>
    /// <returns>The cell at the specified position, or null if out of bounds.</returns>
    public PathfinderGridCell Cell(Vector2Int position)
    {
        if (_grid == null) UpdateGrid();
        if (!isInBounds(position)) return null;
        return _grid[position.x, position.y];
    }

    /// <summary>
    /// Checks if the given position is within the grid bounds.
    /// </summary>
    /// <param name="position">The grid position to check.</param>
    /// <returns>True if the position is within bounds, false otherwise.</returns>
    public bool isInBounds(Vector2Int position)
    {
        if (position.x < 0 || position.y < 0) return false;
        if (position.x >= gridSize.x || position.y >= gridSize.y) return false;
        return true;
    }

    /// <summary>
    /// Updates the grid by initializing or reinitializing the grid cells.
    /// </summary>
    public void UpdateGrid()
    {
        _grid = new PathfinderGridCell[gridSize.x, gridSize.y];
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                _grid[x, y] = new PathfinderGridCell(new Vector2Int(x, y), false);
            }
        }

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                ContactFilter2D a = new ContactFilter2D();
                a.layerMask = LayerMask.GetMask("LevelDesign");
                a.useLayerMask = true;
                int count = Physics2D.OverlapBox(new Vector2(gridStart.x + 0.15f  + x * cellSize, gridStart.y + 0.15f + y * cellSize), new Vector2(cellSize - 0.15f, cellSize - 0.15f), 0, a, new Collider2D[1]);
                if (count > 0)
                {
                    _grid[x, y] = new PathfinderGridCell(_grid[x, y].Position, true);
                }
                else
                {
                    _grid[x, y] = new PathfinderGridCell(_grid[x, y].Position, false);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (drawGizmos)
        { 
            if (drawGridCells && _grid != null)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    for (int y = 0; y < gridSize.y; y++)
                    {
                        if (_grid[x, y].isWeighted)
                        {
                            Gizmos.color = new Color(1, 0, 0, 0.1f);
                        }
                        else
                        {
                            Gizmos.color = new Color(0, 1, 0, 0.1f);
                        }
                        Gizmos.DrawCube(new Vector3(gridStart.x + x * cellSize + cellSize / 2, gridStart.y + y * cellSize + cellSize / 2, 0), new Vector3(cellSize, cellSize, 0));
                    }
                }
            }

            if (drawGrid)
            {
                Gizmos.color = new Color(1, 1, 1, 0.1f);
                Gizmos.DrawLine(new Vector3(gridStart.x, gridStart.y, 0), new Vector3(gridStart.x + gridSize.x * cellSize, gridStart.y, 0));
                Gizmos.DrawLine(new Vector3(gridStart.x, gridStart.y, 0), new Vector3(gridStart.x, gridStart.y + gridSize.y * cellSize, 0));
                Gizmos.DrawLine(new Vector3(gridStart.x + gridSize.x * cellSize, gridStart.y, 0), new Vector3(gridStart.x + gridSize.x * cellSize, gridStart.y + gridSize.y * cellSize, 0));
                Gizmos.DrawLine(new Vector3(gridStart.x, gridStart.y + gridSize.y * cellSize, 0), new Vector3(gridStart.x + gridSize.x * cellSize, gridStart.y + gridSize.y * cellSize, 0));
                for (float x = gridStart.x; x < gridStart.x + gridSize.x * cellSize; x += cellSize)
                {
                    Gizmos.DrawLine(new Vector3(x, gridStart.y, 0), new Vector3(x, gridStart.y + gridSize.y * cellSize, 0));
                }
                for (float y = gridStart.y; y < gridStart.y + gridSize.y * cellSize; y += cellSize)
                {
                    Gizmos.DrawLine(new Vector3(gridStart.x, y, 0), new Vector3(gridStart.x + gridSize.x * cellSize, y, 0));
                }
            }
        }
    }

    /// <summary>
    /// Converts a world position to a grid cell position.
    /// </summary>
    /// <param name="worldPosition">The world position to convert.</param>
    /// <returns>The corresponding grid cell position.</returns>
    public Vector2Int GetGridCellFromWorldPosition(Vector2 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((worldPosition.x - gridStart.x) / cellSize), Mathf.FloorToInt((worldPosition.y - gridStart.y) / cellSize));
    }

    /// <summary>
    /// Converts a grid cell position to a world position.
    /// </summary>
    /// <param name="cell">The grid cell position to convert.</param>
    /// <returns>The corresponding world position.</returns>
    public Vector2 GetWorldPositionFromGridCell(Vector2Int cell)
    {
        return new Vector2(gridStart.x + cell.x * cellSize + cellSize / 2, gridStart.y + cell.y * cellSize + cellSize / 2);
    }
}


/// <summary>
/// Represents a cell in the pathfinder grid.
/// </summary>
public class PathfinderGridCell
{
    public bool isWeighted { get; private set; }
    public Vector2Int Position { get; private set; }

    /// <summary>
    /// Represents a cell in the pathfinder grid.
    /// </summary>
    /// <param name="position">The position of the cell in the grid.</param>
    public PathfinderGridCell(Vector2Int position)
    {
        Position = position;
        isWeighted = false;
    }

    /// <summary>
    /// Represents a cell in the pathfinder grid with a specified walkability.
    /// </summary>
    /// <param name="position">The position of the cell in the grid.</param>
    /// <param name="isWeighted">Indicates if the cell is weighted.</param>
    public PathfinderGridCell(Vector2Int position, bool isWeighted)
    {
        this.Position = position;
        this.isWeighted = isWeighted;
    }
}

/// <summary>
/// Represents a cell in the pathfinding algorithm with additional properties for pathfinding calculations.
/// </summary>
public class Node : IComparable<Node>
{
    public float G = 0;
    public float H = 0;
    public float F = 0;
    public float remainingJumpforce = 0;

    /// <summary>
    /// Represents a node in the pathfinding algorithm.
    /// </summary>
    public Node parent;

    /// <summary>
    /// Returns the nodes cell.
    /// </summary>
    public PathfinderGridCell Cell { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Node class with the specified cell.
    /// </summary>
    /// <param name="cell">The PathfinderGridCell associated with this node.</param>
    public Node(PathfinderGridCell cell)
    {
        Cell = cell;
    }

    /// <summary>
    /// Creates a clone of the current node.
    /// </summary>
    /// <returns>A cloned instance of the current node.</returns>
    public Node Clone()
    {
        Node clonedNode = new Node(this.Cell);
        clonedNode.G = this.G;
        clonedNode.H = this.H;
        clonedNode.F = this.F;
        clonedNode.remainingJumpforce = this.remainingJumpforce;
        clonedNode.parent = this.parent;
        return clonedNode;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current node.
    /// </summary>
    /// <param name="obj">The object to compare with the current node.</param>
    /// <returns>True if the specified object is equal to the current node; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (obj is Node other)
        {
            bool sameG = G == other.G;
            bool sameH = H == other.H;
            bool sameF = F == other.F;
            bool sameCell = Cell.Equals(other.Cell);
            bool sameRJF = remainingJumpforce == other.remainingJumpforce;
            bool sameParent = parent == other.parent;

            return sameG && sameH && sameF && sameCell && sameRJF && sameParent;
        }
        return false;
    }

    // Override GetHashCode to be consistent with Equals
    public override int GetHashCode()
    {
        return Cell.GetHashCode(); // Use Cell's hash code for uniqueness
    }

    // Compares two Node instances based on their F value for priority queue sorting in pathfinding.
    public int CompareTo(Node other)
    {
        return F.CompareTo(other.F);
    }
}
