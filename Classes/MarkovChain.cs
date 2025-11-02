using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace uClasses
{
    /// <summary>
    /// Represents a Markov chain that tracks state transitions and their frequencies.
    /// Useful for predicting next states based on probability distributions from historical data.
    /// </summary>
    internal class MarkovChain
    {
        // Stores the transition counts: _markovChain[fromState][toState] = count
        private Dictionary<int, Dictionary<int, int>> _markovChain;
        
        /// <summary>
        /// Initializes a new instance of the MarkovChain class.
        /// </summary>
        public MarkovChain()
        {
            _markovChain = new Dictionary<int, Dictionary<int, int>>();
        }

        /// <summary>
        /// Adds a state transition to the Markov chain, incrementing the transition count.
        /// </summary>
        /// <param name="from">The starting state.</param>
        /// <param name="to">The destination state.</param>
        public void addTransition(int from, int to)
        {
            // Initialize the from state if it doesn't exist
            if (!_markovChain.ContainsKey(from))
            {
                _markovChain[from] = new Dictionary<int, int>();
            }
            // Initialize the to state count if it doesn't exist
            if (!_markovChain[from].ContainsKey(to))
            {
                _markovChain[from][to] = 0;
            }
            // Increment the transition count
            _markovChain[from][to]++;
        }

        /// <summary>
        /// Gets the number of times a transition from one state to another has occurred.
        /// </summary>
        /// <param name="from">The starting state.</param>
        /// <param name="to">The destination state.</param>
        /// <returns>The count of this transition, or 0 if it hasn't been recorded.</returns>
        public decimal getTransition(int from, int to)
        {
            if (_markovChain.ContainsKey(from) && _markovChain[from].ContainsKey(to))
            {
                return _markovChain[from][to];
            }
            return 0;
        }

        /// <summary>
        /// Gets the most common transition state from a given state.
        /// If multiple states have the same maximum count, randomly selects one.
        /// </summary>
        /// <param name="from">The starting state.</param>
        /// <returns>The most frequently occurring destination state, or -1 if no transitions exist.</returns>
        public int getMostCommonTransition(int from)
        {
            if (_markovChain.ContainsKey(from))
            {
                // Find the maximum transition count
                int maxValue = _markovChain[from].Values.Max();
                // Get all states with the maximum count
                var maxEntries = _markovChain[from].Where(kvp => kvp.Value == maxValue).ToArray();
                // Randomly select one if there are multiple
                Random rnd = new Random();
                return maxEntries[rnd.Next(maxEntries.Length)].Key;
            }
            return -1; // Return -1 if the state doesn't exist
        }

        /// <summary>
        /// Clears all recorded transitions from the Markov chain.
        /// </summary>
        public void clear()
        {
            _markovChain.Clear();
        }

        /// <summary>
        /// Saves the Markov chain data to a JSON file.
        /// </summary>
        /// <param name="filePath">The path where the JSON file will be saved.</param>
        public void saveMarkovChain(string filePath)
        {
            // Serialize the Markov chain dictionary to JSON
            var json = JsonSerializer.Serialize(_markovChain);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Loads Markov chain data from a JSON file.
        /// </summary>
        /// <param name="filePath">The path to the JSON file containing Markov chain data.</param>
        /// <exception cref="FileNotFoundException">Thrown if the specified file does not exist.</exception>
        public void loadMarkovChain(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            // Read and deserialize the JSON file
            var json = File.ReadAllText(filePath);
            _markovChain = JsonSerializer.Deserialize<Dictionary<int, Dictionary<int, int>>>(json) ?? new Dictionary<int, Dictionary<int, int>>();
        }
    }
}
