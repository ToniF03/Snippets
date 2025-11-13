ExtensionHelper

Description: Helpers to register/unregister file extensions in the Windows registry.

File: `ExtensionHelper.cs`

Details:
- Provides `RegisterExtension` and `UnregisterExtension` helpers that create or remove registry keys under:
	- `HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths` (application path)
	- `HKCR` (file extension association)

Usage example:
```csharp
// Link .myext files to MyApp.exe with ProgID "MyApp.Document"
ExtensionHelper.RegisterExtension(".myext", null, "MyApp.Document", @"C:\\Program Files\\MyApp\\MyApp.exe");
```

Notes & Warnings:
- Modifying `HKLM` requires administrative privileges; call from an elevated process.
- Registry operations can affect system behavior – test carefully and provide an undo path using `UnregisterExtension`.
