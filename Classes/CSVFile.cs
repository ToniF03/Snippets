using System;
using System.IO;
using System.Linq;

namespace uCSV
{
    /// <summary>
    /// Simple CSV helper that can read, manipulate and write CSV-like files.
    /// - Stores headers (if present) and data rows in memory
    /// - Supports a configurable delimiter (default ';')
    /// - Optionally appends an index column when reading
    /// Note: This is a lightweight utility intended for small-to-medium CSV files.
    /// </summary>
    public class CSVFile
    {
        // Field that defines the column delimiter (e.g. ';' or ',')
        private char _delimiter;

        // Header row values (if the CSV contains headers)
        private string[] _headers = Array.Empty<string>();

        // Data rows: each row is an array of column values
        private string[][] _data = Array.Empty<string[]>();

        // When true, an index column (named "Index") will be prepended to headers and each row
        private bool _appendIndex;

        /// <summary>
        /// Public read-only access to headers.
        /// </summary>
        public string[] Headers { get { return _headers; } }

        /// <summary>
        /// Public read-only access to data rows.
        /// </summary>
        public string[][] Data { get { return _data; } }

        /// <summary>
        /// Default constructor. Uses ';' as delimiter and does not append an index.
        /// </summary>
        public CSVFile()
        {
            _delimiter = ';';
            _appendIndex = false;
        }

        /// <summary>
        /// Construct and immediately read a CSV file into memory.
        /// </summary>
        /// <param name="filePath">Path to the CSV file to read.</param>
        /// <param name="delimiter">Column delimiter character (default ';').</param>
        /// <param name="hasHeader">Whether the first row is a header row.</param>
        /// <param name="appendIndex">Whether to prepend an index column.</param>
        public CSVFile(string filePath, char delimiter = ';', bool hasHeader = true, bool appendIndex = false)
        {
            _delimiter = delimiter;
            _appendIndex = appendIndex;
            this.Read(filePath, delimiter, hasHeader, appendIndex);
        }

        /// <summary>
        /// Read a CSV file from disk and populate headers and data arrays.
        /// This implementation reads the entire file into memory and splits on newlines.
        /// </summary>
        public void Read(string filePath, char delimiter = ';', bool hasHeader = true, bool appendIndex = false)
        {
            _delimiter = delimiter;
            _appendIndex = appendIndex;

            // Read the whole file and split into lines. Trim to remove trailing newlines.
            var lines = File.ReadAllText(filePath).Trim().Split('\n');

            // If the file is empty after trimming, nothing to do.
            if (lines.Length == 0) return;

            // If the CSV has a header row, parse and set headers.
            // If appendIndex is requested, prepend an "Index" header plus the delimiter.
            if (hasHeader)
                _headers = ((_appendIndex ? "Index" + _delimiter : "") + lines[0]).Split(_delimiter);

            // Prepare the data array with correct length (exclude header row if present)
            _data = new string[lines.Length - (hasHeader ? 1 : 0)][];

            // Parse each remaining line into columns. If appendIndex is enabled, prefix the row index.
            for (int i = 1; i < lines.Length; i++)
            {
                _data[i - 1] = ((_appendIndex ? i + _delimiter.ToString() : "") + lines[i]).Split(_delimiter);
            }
        }

        /// <summary>
        /// Add a new row to the CSV data. The provided row must match the existing column count.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the row length does not match existing rows.</exception>
        public void Add(string[] line)
        {
            // Validate that the new line matches the existing number of columns
            if (_data.Length > 0 && line.Length != this._data[0].Length) throw new ArgumentException();

            // Append the new row to the in-memory array
            this._data = this._data.Append(line).ToArray();
        }

        /// <summary>
        /// Remove a row at the specified zero-based index.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">If index is outside the available rows.</exception>
        public void Remove(int index)
        {
            if (index < 0 || index >= _data.Length) throw new ArgumentOutOfRangeException();
            _data = _data.Where((_, i) => i != index).ToArray();
        }

        /// <summary>
        /// Replace the row at the specified index with the provided line.
        /// </summary>
        public void Update(int index, string[] line)
        {
            if (index < 0 || index >= _data.Length) throw new ArgumentOutOfRangeException();
            if (line.Length != _data[0].Length) throw new ArgumentException();
            _data[index] = line;
        }
        
        /// <summary>
        /// Remove all data rows (headers are preserved).
        /// </summary>
        public void Clear()
        {
            _data = Array.Empty<string[]>();
        }
        
        /// <summary>
        /// Set or replace the header row stored in memory.
        /// </summary>
        public void SetHeaders(string[] headers)
        {
            _headers = headers;
        }        

        /// <summary>
        /// Save the in-memory CSV to a file. If hasHeader is true, headers are written first.
        /// </summary>
        public void Save(string filePath, bool hasHeader = true)
        {
            if (hasHeader)
                File.WriteAllText(filePath, string.Join(_delimiter, _headers) + "\n" + string.Join('\n', _data.Select(row => string.Join(_delimiter, row))));
            else
                File.WriteAllText(filePath, string.Join('\n', _data.Select(row => string.Join(_delimiter, row))));

            // Informational console output to indicate the file was created/overwritten
            Console.WriteLine(filePath + " created.");
        }

        /// <summary>
        /// Attempt to save and return any exception instead of throwing it.
        /// Useful for callers who prefer to handle failures without exceptions.
        /// </summary>
        public Exception? TrySave(string filePath)
        {
            try
            {
                Save(filePath);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
