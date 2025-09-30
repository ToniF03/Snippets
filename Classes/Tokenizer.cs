using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace uClasses
{
    /// <summary>
    /// Provides functionality to tokenize input text into distinct words or tokens based on specified configuration
    /// options.
    /// </summary>
    /// <remarks>The <see cref="Tokenizer"/> class allows for customizable tokenization of text by specifying
    /// filters, a splitting character, and whether to normalize the text to lowercase. It tracks a limited number of
    /// unique words, as defined by the <paramref name="num_words"/> parameter, and ignores words beyond this
    /// limit.</remarks>
    internal class Tokenizer
    {
        public Dictionary<string, int> tokens;
        private string _filters;
        private bool _lowercase;
        private bool _keepPunctuation;
        private int _num_words;
        private char _split;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tokenizer"/> class with specified configuration options.
        /// </summary>
        /// <param name="num_words">The maximum number of unique words to track. Words beyond this limit will not be tokenized.</param>
        /// <param name="filters">A string containing characters to filter out from the input text. Defaults to common punctuation and
        /// whitespace.</param>
        /// <param name="split">The character used to split the input text into tokens. Defaults to a space character (' ').</param>
        /// <param name="lowercase">A value indicating whether the input text should be converted to lowercase before tokenization. Defaults to
        /// <see langword="false"/>.</param>
        /// <param name="keepPunctuation"> A value indicating whether to keep punctuation in the tokenization process. Defaults to <see langword="false"/>.</param>
        public Tokenizer(int num_words = 20000, string filters = "!\"#$%&()*+,-./:;<=>?@[\\]^_`{|}~\t\n", char split = ' ', bool lowercase = true, bool keepPunctuation = false)
        {
            this._num_words = num_words;
            this._filters = filters;
            this._split = split;
            this._lowercase = lowercase;
            this._keepPunctuation = keepPunctuation;
            this.tokens = new Dictionary<string, int>();
            this.tokens.Add("<start>", 0);
            this.tokens.Add("<end>", 1);
        }

        public int[] tokenize(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException();
            // Normalize the text
            if (_lowercase)
                text = text.ToLower();
            // Remove filters
            foreach (char c in _filters)
            {
                if (_keepPunctuation && ".,!?".Contains(c))
                {
                    text = text.Replace(c.ToString(), " " + c.ToString() + " ");
                    continue; // Skip punctuation if we are keeping it
                }
                text = text.Replace(c.ToString(), string.Empty);
            }
            // Add start and end keywords
            text = "<start> " + text + " <end>";
            // Split the text into words
            string[] words = text.Split(_split, (char)StringSplitOptions.RemoveEmptyEntries);
            int[] sequence = new int[words.Length];
            // Count the occurrences of each word
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (!tokens.ContainsKey(word) && tokens.Count != _num_words)
                {
                    tokens[word] = tokens.Count;
                }
                sequence[i] = tokens[word];
            }
            return sequence;
        }

        public string[] detokenize(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                throw new ArgumentException();
            string[] words = new string[sequence.Length];
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] < 0 || sequence[i] >= tokens.Count)
                    throw new ArgumentOutOfRangeException();
                words[i] = tokens.FirstOrDefault(x => x.Value == sequence[i]).Key;
            }
            return words;
        }

        public void clear()
        {
            tokens.Clear();
            this.tokens.Add("<start>", 0);
            this.tokens.Add("<end>", 1);
        }

        public void saveTokens(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.");
            var json = JsonSerializer.Serialize(tokens, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void loadTokens(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty.");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            var json = File.ReadAllText(filePath);
            tokens = JsonSerializer.Deserialize<Dictionary<string, int>>(json) ?? new Dictionary<string, int>();
        }
    }
}
