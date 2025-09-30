using System;
using System.Collections.Generic;

namespace uClasses.MinHeap
{
    /// <summary>
    /// A generic MinHeap implementation for managing elements with priority.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap, must implement IComparable&lt;T&gt;.</typeparam>
    public class MinHeap<T> where T : IComparable<T>
    {
        // Internal list to store heap elements.
        private List<T> _items = new List<T>();

        // Dictionary to track the position of each element in the heap for fast lookup and updates.
        private Dictionary<T, int> _positions = new Dictionary<T, int>();

        // Gets the number of elements in the heap.
        public int Count => _items.Count;

        /// <summary>
        /// Adds a new item to the heap and maintains the heap property.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            _items.Add(item);
            int index = _items.Count - 1;
            _positions[item] = index;
            BubbleUp(index); // Restore heap property upwards.
        }

        /// <summary>
        /// Removes and returns the smallest item (root) from the heap.
        /// </summary>
        /// <returns>The smallest item in the heap.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the heap is empty.</exception>
        public T Pop()
        {
            if (_items.Count == 0) throw new InvalidOperationException("Heap is empty");

            T root = _items[0];
            T last = _items[_items.Count - 1];
            _items[0] = last;
            _positions[last] = 0;

            _items.RemoveAt(_items.Count - 1);
            _positions.Remove(root);

            if (_items.Count > 0) BubbleDown(0); // Restore heap property downwards.
            return root;
        }

        /// <summary>
        /// Checks if the heap contains the specified item.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <returns>True if the item exists in the heap; otherwise, false.</returns>
        public bool Contains(T item) => _positions.ContainsKey(item);

        /// <summary>
        /// Updates the position of an item in the heap after its priority has changed.
        /// </summary>
        /// <param name="item">The item whose priority has changed.</param>
        /// <exception cref="InvalidOperationException">Thrown if the item is not found in the heap.</exception>
        public void UpdateKey(T item)
        {
            if (!_positions.TryGetValue(item, out int index))
                throw new InvalidOperationException("Item not found in heap");

            // After changing F cost of the node externally,
            // call this to fix its position.
            BubbleUp(index);
            BubbleDown(index);
        }

        /// <summary>
        /// Moves the item at the specified index up the heap until the heap property is restored.
        /// </summary>
        /// <param name="index">The index of the item to move up.</param>
        private void BubbleUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (_items[index].CompareTo(_items[parent]) >= 0) break;

                Swap(index, parent);
                index = parent;
            }
        }

        /// <summary>
        /// Moves the item at the specified index down the heap until the heap property is restored.
        /// </summary>
        /// <param name="index">The index of the item to move down.</param>
        private void BubbleDown(int index)
        {
            int lastIndex = _items.Count - 1;
            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left <= lastIndex && _items[left].CompareTo(_items[smallest]) < 0)
                    smallest = left;
                if (right <= lastIndex && _items[right].CompareTo(_items[smallest]) < 0)
                    smallest = right;

                if (smallest == index) break;

                Swap(index, smallest);
                index = smallest;
            }
        }

        /// <summary>
        /// Swaps two items in the heap and updates their positions in the dictionary.
        /// </summary>
        /// <param name="a">The index of the first item.</param>
        /// <param name="b">The index of the second item.</param>
        private void Swap(int a, int b)
        {
            T tmp = _items[a];
            _items[a] = _items[b];
            _items[b] = tmp;

            _positions[_items[a]] = a;
            _positions[_items[b]] = b;
        }
    }
}
