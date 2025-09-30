using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace uClasses
{
    internal class MarkovChain
    {
        private Dictionary<int, Dictionary<int, int>> _markovChain;
        public MarkovChain()
        {
            _markovChain = new Dictionary<int, Dictionary<int, int>>();
        }

        public void addTransition(int from, int to)
        {
            if (!_markovChain.ContainsKey(from))
            {
                _markovChain[from] = new Dictionary<int, int>();
            }
            if (!_markovChain[from].ContainsKey(to))
            {
                _markovChain[from][to] = 0;
            }
            _markovChain[from][to]++;
        }

        public decimal getTransition(int from, int to)
        {
            if (_markovChain.ContainsKey(from) && _markovChain[from].ContainsKey(to))
            {
                return _markovChain[from][to];
            }
            return 0;
        }

        public int getMostCommonTransition(int from)
        {
            if (_markovChain.ContainsKey(from))
            {
                int maxValue = _markovChain[from].Values.Max();
                var maxEntries = _markovChain[from].Where(kvp => kvp.Value == maxValue).ToArray();
                Random rnd = new Random();
                return maxEntries[rnd.Next(maxEntries.Length)].Key;
            }
            return -1; // or throw an exception
        }

        public void clear()
        {
            _markovChain.Clear();
        }

        public void saveMarkovChain(string filePath)
        {
            var json = JsonSerializer.Serialize(_markovChain);
            File.WriteAllText(filePath, json);
        }

        public void loadMarkovChain(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            var json = File.ReadAllText(filePath);
            _markovChain = JsonSerializer.Deserialize<Dictionary<int, Dictionary<int, int>>>(json) ?? new Dictionary<int, Dictionary<int, int>>();
        }
    }
}
