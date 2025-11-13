WPF Code Snippets
=================

Collection of small WPF helpers and window-related snippets.

Files:
- `FixedMaximizing.cs` — Window sizing helper to correctly set the maximized window size on multi-monitor setups.

Usage (FixedMaximizing):
- In a `Window` constructor or `SourceInitialized` handler, add the hook shown in the snippet to intercept `WM_GETMINMAXINFO` messages and adjust `MINMAXINFO`.

Example:
```csharp
SourceInitialized += (s,e) => {
  IntPtr handle = (new WindowInteropHelper(this)).Handle;
  HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
};
```

Notes:
- This is a small interoperability snippet — copy into your `MainWindow` code-behind and adapt as needed.