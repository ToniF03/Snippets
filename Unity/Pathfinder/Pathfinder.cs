using Assets.Scripts.Classes.MinHeap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Implements A* pathfinding logic for a grid-based environment, supporting gravity and jump mechanics.
/// </summary>
[RequireComponent(typeof(PathfinderGridManager)), RequireComponent(typeof(Collider2D))]
public class Pathfinder : MonoBehaviour
{
    private PathfinderGridManager _gridManager; // Reference to the grid manager component
    // Directions for neighbor search: cardinal, diagonal, and special cases.
    private static readonly Vector2Int[] directions = new Vector2Int[] 
    { 
        Vector2Int.right, 
        Vector2Int.left, 
        Vector2Int.up, 
        Vector2Int.down, 
        Vector2Int.one, 
        -Vector2Int.one, 
        new Vector2Int(-1, 1), 
        new Vector2Int(1, -1) 
    };
    private readonly List<Node> _neighborBuffer = new List<Node>(8); // Buffer for neighbor nodes
    private static readonly Vector2Int Down = Vector2Int.down; // Downward direction
    private const float DiagonalCost = 1.41421356237f; // Cost for diagonal movement
    bool[,] closed; // Tracks closed (visited) cells

    [SerializeField] private float fallPenalty = 0.5f; // Penalty for falling
    [SerializeField] private float jumpPenalty = 1; // Penalty for jumping

    /// <summary>
    /// Initializes the grid manager and closed array.
    /// </summary>
    void Start()
    {
        _gridManager = GetComponent<PathfinderGridManager>();
        closed = new bool[_gridManager.gridSize.x, _gridManager.gridSize.y];
    }

    /// <summary>
    /// Gets the PathfinderGridManager component attached to this GameObject.
    /// </summary>
    public PathfinderGridManager PathfinderGridManager => _gridManager;

    /// <summary>
    /// Finds a path from the start position to the end position, ignoring gravity.
    /// </summary>
    /// <param name="start">The starting position in world coordinates.</param>
    /// <param name="end">The ending position in world coordinates.</param>
    /// <returns>An array of grid cell positions representing the path, or null if no path is found.</returns>
    public Vector2Int[] findPath(Vector2 start, Vector2 end) => findPath(start, end, false, 1);

    /// <summary>
    /// Finds a path from the start position to the end position, optionally considering gravity and jump force.
    /// </summary>
    /// <param name="start">The starting position in world coordinates.</param>
    /// <param name="end">The ending position in world coordinates.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>An array of grid cell positions representing the path, or null if no path is found.</returns>
    public Vector2Int[] findPath(Vector2 start, Vector2 end, bool useGravity, float jumpForce)
    {
        if (_gridManager == null) return null;
        Vector2Int _startCell = _gridManager.GetGridCellFromWorldPosition(start);
        Vector2Int _endCell = _gridManager.GetGridCellFromWorldPosition(end);
        if (closed == null) closed = new bool[_gridManager.gridSize.x, _gridManager.gridSize.y];
        Array.Clear(closed, 0, closed.Length); // Reset closed array for new search
        OpenSet openSet = new OpenSet();

        // Validate start and end cells
        if (!_gridManager.isInBounds(_startCell) || !_gridManager.isInBounds(_endCell) || 
            _gridManager.Cell(_startCell).isWeighted || _gridManager.Cell(_endCell).isWeighted || 
            _startCell == _endCell)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"Failed finding a path from {_startCell} to {_endCell} due to either start or end point being out of bounds.");
#endif
            return null;
        }

        Node currentNode = new Node(_gridManager.Cell(_startCell));
        // Initialize costs and jump force for the starting node
        (currentNode.G, currentNode.H, currentNode.F, currentNode.remainingJumpforce) = calculateGHF(currentNode, _endCell, true, jumpForce);
        closed[_startCell.x, _startCell.y] = true;

        // Set jump force if starting on a weighted tile
        currentNode.remainingJumpforce = isOnWeightedTile(currentNode) ? jumpForce : 0;

        // Get initial neighbors and add to open set
        getNeighborNodes(currentNode, ref openSet, ref closed, _endCell, useGravity, jumpForce);
        foreach (Node n in _neighborBuffer)
        {
            openSet.Add(n);
        }

        // Main A* loop
        while (openSet.Count != 0)
        {
            currentNode = openSet.Pop();
            closed[currentNode.Cell.Position.x, currentNode.Cell.Position.y] = true;

            // Expand neighbors for current node
            getNeighborNodes(currentNode, ref openSet, ref closed, _endCell, useGravity, jumpForce);
            foreach (Node n in _neighborBuffer)
            {
                openSet.Add(n);
            }

            // If end cell reached, reconstruct path
            if (currentNode.Cell.Position == _endCell)
            {
                List<Vector2Int> path = new();
                for (var n = currentNode; n != null; n = n.parent)
                    path.Add(n.Cell.Position);
                path.Reverse();
                return path.ToArray();
            }
        }
        // No path found
        return null;
    }

    /// <summary>
    /// Gets the valid neighbor nodes for a given node, considering movement rules and gravity.
    /// </summary>
    /// <param name="node">The node to find neighbors for.</param>
    /// <param name="openSet">Reference to the open set.</param>
    /// <param name="closed">Reference to the closed array.</param>
    /// <param name="endCell">The target cell's grid coordinates.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>An array of valid neighboring nodes.</returns>
    List<Node> getNeighborNodes(Node node, ref OpenSet openSet, ref bool[,] closed, Vector2Int endCell, bool useGravity, float jumpForce)
    {
        _neighborBuffer.Clear();
        for (int i = 0; i < directions.Length; i++)
        {
            Vector2Int direction = directions[i];
            // If gravity is used and no jump force remains, skip upward movement
            if (useGravity && direction.y == 1 && node.remainingJumpforce == 0) continue;
            if (!_gridManager.isInBounds(node.Cell.Position + direction)) continue;
            PathfinderGridCell cell = _gridManager.Cell(node.Cell.Position + direction);
            if (cell.isWeighted) continue;

            // If node is already in open set, try to update it
            if (openSet.TryGet(cell.Position, out Node openNode))
            {
                if (UpdateNode(openNode, node, endCell, useGravity, jumpForce))
                    openSet.UpdateKey(openNode);
            }
            // If node is closed, check for special upward movement case
            else if (closed[cell.Position.x, cell.Position.y])
            {
                Vector2Int prevDirection = node.Cell.Position - cell.Position;
                if (prevDirection.y == -1 && direction.y == 1)
                {
                    Node newNode = new Node(cell);
                    newNode.parent = node;
                    (newNode.G, newNode.H, newNode.F, newNode.remainingJumpforce) = calculateGHF(newNode, endCell, useGravity, jumpForce);
                    if (newNode.remainingJumpforce >= 0)
                        _neighborBuffer.Add(newNode);
                }
            }
            // Otherwise, create new neighbor node
            else
            {
                Node newNode = new Node(cell);
                newNode.parent = node;
                (newNode.G, newNode.H, newNode.F, newNode.remainingJumpforce) = calculateGHF(newNode, endCell, useGravity, jumpForce);
                if (newNode.remainingJumpforce >= 0)
                    _neighborBuffer.Add(newNode);
            }
        }

        return _neighborBuffer;
    }

    /// <summary>
    /// Updates a node's path cost and parent if a better path is found.
    /// </summary>
    /// <param name="node">The node to update.</param>
    /// <param name="potentialParentNode">The potential parent node for the new path.</param>
    /// <param name="endCell">The target cell's grid coordinates.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>True if the node was updated, otherwise false.</returns>
    bool UpdateNode(Node node, Node potentialParentNode, Vector2Int endCell, bool useGravity, float jumpForce)
    {
        float G, H, F, remainingJumpforce;
        (G, H, F, remainingJumpforce) = calculateGHF(node, potentialParentNode, endCell, useGravity, jumpForce);
        // Update node if new path is better and jump force is valid
        if (F < node.F && (!useGravity || remainingJumpforce >= node.remainingJumpforce))
        {
            node.parent = potentialParentNode;
            node.G = G;
            node.H = H;
            node.F = F;
            node.remainingJumpforce = remainingJumpforce;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Calculates the G, H, and F values for a node, using its parent for G cost.
    /// </summary>
    /// <param name="node">The node to calculate for.</param>
    /// <param name="endCell">The target cell's grid coordinates.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>A tuple of (G, H, F, remainingJumpforce).</returns>
    (float, float, float, float) calculateGHF(Node node, Vector2Int endCell, bool useGravity, float jumpForce) 
        => calculateGHF(node, node.parent, endCell, useGravity, jumpForce);

    /// <summary>
    /// Calculates the G, H, and F values for a node, using a specified parent node for G cost.
    /// </summary>
    /// <param name="node">The node to calculate for.</param>
    /// <param name="node2">The parent node to calculate G cost from.</param>
    /// <param name="endCell">The target cell's grid coordinates.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>A tuple of (G, H, F, remainingJumpforce).</returns>
    (float, float, float, float) calculateGHF(Node node, Node node2, Vector2Int endCell, bool useGravity, float jumpForce)
    {
        float G = 0, H = 0, F = 0;
        float remainingJumpforce = 0;
        PathfinderGridCell cell = node.Cell;

        (G, remainingJumpforce) = calculateG(node, node2, useGravity, jumpForce);

        H = calculateH(cell, endCell);

        F = G + H;
        return (G, H, F, remainingJumpforce);
    }

    /// <summary>
    /// Calculates the G cost and remaining jump force for a node.
    /// </summary>
    /// <param name="node">The current node.</param>
    /// <param name="parent">The parent node.</param>
    /// <param name="useGravity">Whether gravity should be considered.</param>
    /// <param name="jumpForce">The available jump force for vertical movement.</param>
    /// <returns>A tuple of (G, remainingJumpforce).</returns>
    (float, float) calculateG(Node node, Node parent, bool useGravity, float jumpForce)
    {
        float G = 0;
        float remainingJumpforce = 0;

        if (parent != null)
        {
            PathfinderGridCell cell = node.Cell;
            Vector2Int direction = cell.Position - parent.Cell.Position;
            Vector2Int prevDirection = parent.parent != null ? parent.Cell.Position - parent.Cell.Position : Vector2Int.zero;
            remainingJumpforce = parent.remainingJumpforce;
            G = parent.G + Vector2Int.Distance(cell.Position, parent.Cell.Position);

            if (useGravity)
            {
                // Handle upward movement (jump)
                if (direction.y == 1 && !isOnWeightedTile(cell))
                {
                    G += jumpPenalty;
                    remainingJumpforce -= _gridManager.cellSize;
                }
                // Handle downward movement (fall)
                else if (direction.y == -1 && !isOnWeightedTile(cell))
                {
                    G -= fallPenalty;
                    remainingJumpforce = 0;
                }
                // Handle horizontal movement with insufficient jump force
                else if (remainingJumpforce < jumpForce && direction.y == 0 && direction.x != 0)
                    remainingJumpforce = -_gridManager.cellSize;
                else if (direction.y == 0 && direction.x != 0 && !isOnWeightedTile(cell))
                    remainingJumpforce = -_gridManager.cellSize;
                // Handle illegal downward turn
                else if (direction.y == -1 && parent.parent != null && direction.x != prevDirection.x)
                    remainingJumpforce = -_gridManager.cellSize;
                // Reset jump force if on weighted tile
                else if (isOnWeightedTile(cell))
                    remainingJumpforce = jumpForce;
                // Handle illegal upward turn
                if (IsIllegalUpwardTurn(direction, prevDirection, parent, jumpForce, remainingJumpforce))
                    remainingJumpforce = -_gridManager.cellSize;
            }
        }
        return (G, remainingJumpforce);
    }

    /// <summary>
    /// Calculates the heuristic (H) cost for a cell to the end cell.
    /// Uses diagonal distance.
    /// </summary>
    /// <param name="cell">The current cell.</param>
    /// <param name="endCell">The target cell.</param>
    /// <returns>Heuristic cost.</returns>
    float calculateH(PathfinderGridCell cell, Vector2Int endCell)
    {
        int dx = Mathf.Abs(cell.Position.x - endCell.x);
        int dy = Mathf.Abs(cell.Position.y - endCell.y);
        return Mathf.Min(dx, dy) * DiagonalCost + Mathf.Max(dx, dy);
    }

    /// <summary>
    /// Checks if the node is standing on a weighted tile.
    /// </summary>
    /// <param name="node">The node to check.</param>
    /// <returns>True if the node is on a weighted tile, otherwise false.</returns>
    bool isOnWeightedTile(Node node) => isOnWeightedTile(node.Cell);

    /// <summary>
    /// Checks if the cell is directly above a weighted tile.
    /// </summary>
    /// <param name="cell">The cell to check.</param>
    /// <returns>True if the cell is above a weighted tile, otherwise false.</returns>
    bool isOnWeightedTile(PathfinderGridCell cell)
    {
        if (cell.Position.y == 0) return false;
        return _gridManager.Cell(cell.Position + Down).isWeighted;
    }

    /// <summary>
    /// Determines if an upward turn is illegal based on jump force and movement direction.
    /// </summary>
    /// <param name="direction">Current movement direction.</param>
    /// <param name="prevDirection">Previous movement direction.</param>
    /// <param name="node">Current node.</param>
    /// <param name="jumpForce">Maximum jump force.</param>
    /// <param name="remainingJumpForce">Current remaining jump force.</param>
    /// <returns>True if the upward turn is illegal, otherwise false.</returns>
    bool IsIllegalUpwardTurn(Vector2Int direction, Vector2Int prevDirection, Node node, float jumpForce, float remainingJumpForce)
    {
        // Conditions:
        // - Out of jump force
        // - Moving upward
        // - Has a parent
        // - Direction changed compared to parent
        // - Previous tile not weighted
        return remainingJumpForce < jumpForce
            && direction.y == 1
            && node.parent != null
            && prevDirection != direction
            && !isOnWeightedTile(node.parent);
    }
}

/// <summary>
/// Represents the open set for A* pathfinding, combining a min-heap and dictionary for fast access.
/// </summary>
class OpenSet
{
    private MinHeap<Node> heap = new MinHeap<Node>(); // Min-heap for node priority
    private Dictionary<Vector2Int, Node> dict = new(); // Dictionary for fast node lookup by position

    /// <summary>
    /// Gets the number of nodes in the open set.
    /// </summary>
    public int Count => heap.Count;

    /// <summary>
    /// Adds a node to the open set.
    /// </summary>
    /// <param name="n">Node to add.</param>
    public void Add(Node n)
    {
        dict[n.Cell.Position] = n;
        heap.Add(n);
    }

    /// <summary>
    /// Tries to get a node from the open set by position.
    /// </summary>
    /// <param name="pos">Grid position.</param>
    /// <param name="node">Output node.</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool TryGet(Vector2Int pos, out Node node) => dict.TryGetValue(pos, out node);

    /// <summary>
    /// Pops the node with the lowest F cost from the open set.
    /// </summary>
    /// <returns>Node with lowest F cost.</returns>
    public Node Pop()
    {
        var n = heap.Pop();
        dict.Remove(n.Cell.Position);
        return n;
    }

    /// <summary>
    /// Updates the key (priority) of a node in the heap.
    /// </summary>
    /// <param name="n">Node to update.</param>
    public void UpdateKey(Node n) => heap.UpdateKey(n);
}
 