ShortcutHelper

Description: Native COM interop types and a managed `Shortcut` wrapper for creating and manipulating Windows shortcuts (.lnk files).

File: `ShortcutHelper.cs`

Details:
- Contains P/Invoke and COM interface declarations for `IShellLink`, `IPersistFile`, and related structures.
- `Shortcut` class wraps these APIs to provide a simple managed API to create, load, resolve, and save `.lnk` files.

Usage example:
```csharp
var sc = new Shortcut(@"C:\\Program Files\\MyApp\\MyApp.exe");
sc.Description = "Launch MyApp";
sc.Arguments = "--minimized";
sc.Save(@"C:\\Users\\Public\\Desktop\\MyApp.lnk");
```

Notes:
- Uses COM interop; loading/saving may throw COM exceptions — wrap calls with appropriate error handling.
- Shortcuts saved with `IPersistFile.Save` and loaded with `IPersistFile.Load`.
