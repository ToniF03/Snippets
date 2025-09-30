using System;
using System.Collections.Generic;

namespace Assets.Scripts.Classes.MinHeap
{
    /// <summary>
    /// A generic MinHeap implementation for managing elements with priority.
    /// </summary>
    /// <typeparam name="T">The type of elements in the heap, must implement IComparable&lt;T&gt;.</typeparam>
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> _items = new List<T>();
        private Dictionary<T, int> _positions = new Dictionary<T, int>();

        public int Count => _items.Count;

        public void Add(T item)
        {
            _items.Add(item);
            int index = _items.Count - 1;
            _positions[item] = index;
            BubbleUp(index);
        }

        public T Pop()
        {
            if (_items.Count == 0) throw new InvalidOperationException("Heap is empty");

            T root = _items[0];
            T last = _items[^1];
            _items[0] = last;
            _positions[last] = 0;

            _items.RemoveAt(_items.Count - 1);
            _positions.Remove(root);

            if (_items.Count > 0) BubbleDown(0);
            return root;
        }

        public bool Contains(T item) => _positions.ContainsKey(item);

        public void UpdateKey(T item)
        {
            if (!_positions.TryGetValue(item, out int index))
                throw new InvalidOperationException("Item not found in heap");

            // After changing F cost of the node externally,
            // call this to fix its position.
            BubbleUp(index);
            BubbleDown(index);
        }

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
