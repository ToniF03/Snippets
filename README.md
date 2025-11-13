Snippets
========

Overview
--------
A collection of useful C# code snippets and small utilities I keep for reference and reuse. The repository contains standalone classes (general utilities, data structures, Windows helpers) and a few Unity-related scripts.

Purpose
-------
- Centralize small, reusable C# components.
- Provide quick examples and reference implementations for common problems (file encryption, registry handling, tokenization, CSV helpers, etc.).
- Serve as a source for the `tonif03.github.io` site snippets.

Contents (high level)
---------------------
- `Classes/`
  - `CSVFile.cs` — lightweight CSV reader/writer utility
  - `ExtensionHelper.cs` — register/unregister file associations (Windows registry)
  - `FileEncryption.cs` — AES-based symmetric encryption helper
  - `MarkovChain.cs` — simple Markov chain text generator
  - `Math.cs` — assorted math and conversion helpers (uCalc)
  - `MinHeap.cs` — min-heap / priority queue implementation
  - `RegistryWatcher.cs` — watches registry values and raises change events
  - `ShortcutHelper.cs` — helper for creating/manipulating Windows .lnk shortcuts
  - `Tokenizer.cs` — tokenization utilities for text processing

- `Unity/` — Unity-specific utilities and gameplay scripts
  - `Pathfinder/` — grid-based A* pathfinding example
  - `PlayerController/2D/TopDown/Player_controller.cs` — sample player controller

- `Wpf/` — WPF-specific snippets and utilities (e.g., TagLibrary for MP3 tag handling)

Quick Usage Examples
--------------------
CSVFile (basic):
```csharp
var csv = new uCSV.CSVFile();
csv.Read("data.csv");
// Inspect headers and rows
var headers = csv.Headers;
var rows = csv.Data;

// Modify
csv.Add(new string[] {"a","b","c"});
csv.Save("data-out.csv");
```

FileEncryption (basic):
```csharp
// See FileEncryption.cs for API; typically provides Encrypt/Decrypt helpers
var cipher = FileEncryption.EncryptString("secret");
var plain = FileEncryption.DecryptBytes(cipher);
```

Notes & Recommendations
-----------------------
- These are small, focused snippets and intentionally keep external dependencies to a minimum.
- Many methods assume well-formed input and may throw exceptions for invalid data — review and adapt to your needs before using in production.
- CSV parsing here is intentionally simple. For robust CSV handling (quoted fields, different line endings, large files) prefer a dedicated parser (e.g., `CsvHelper`).

Contributing
------------
- Open an issue or submit a pull request with focused changes.
- Add examples or unit tests where appropriate.

License
-------
No explicit license file is included here. Add a `LICENSE` file (for example MIT) if you want to permit reuse under explicit terms.

Contact
-------
- Author: `ToniF03` (GitHub)
- Related site: `tonif03.github.io`
