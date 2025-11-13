TagLibrary
==========

Collection of small utilities for reading and manipulating MP3 ID3 tags.

Files:
- `MP3Utils.cs` - helper utilities for MP3 processing
- `MP3File.cs` - representation of an MP3 file and tag accessors
- `ID3V1Tag.cs` - ID3v1 tag parser
- `ID3V2Tag.cs` - ID3v2 tag parser and frame helpers
- `BitManipulator.cs` - bit-level helpers used by parsers

These files are related and kept together as they implement the same subsystem.

Details & Usage:
- Use `Mp3File` to open an MP3 file and read tags from both ID3v1 and ID3v2. Example:
```csharp
var mp = new TagLib.ID3.Mp3File("song.mp3");
string title = mp.Title; // reads from ID3v2 if available, falls back to ID3v1
var cover = mp.Cover; // returns a WPF Image if embedded cover art exists
```
- `ID3V1Tag.cs` and `ID3V2Tag.cs` contain parsers and helpers to access individual tag frames; `MP3Utils.cs` and `BitManipulator.cs` provide low-level helpers.

Notes:
- These are lightweight utilities for simple tag access and are not a full-featured tag library.
