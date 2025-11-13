CSVFile
=======

Simple CSV reader/writer helper.

- `Read(path)` returns a `List<string[]>` of rows.
- `Write(path, rows)` writes rows to a CSV file.

Configuration:
- `Delimiter` (default `,`)
- `IndexColumn` (optional)

Usage example:
```csharp
var csv = new CSVFile { Delimiter = ',' };
var rows = csv.Read("my.csv");
csv.Write("out.csv", rows);
```

Notes:
- This is a simple parser and writer; it does not handle quoted fields containing the delimiter. Extend if needed.
