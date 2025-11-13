RegistryWatcher
===============

Description: Monitors a single Windows Registry value and raises an event when the value changes.

File: `RegistryWatcher.cs`

Details:
- Uses a `DispatcherTimer` to poll the registry value at a configurable `Interval` (default 200 ms).
- Exposes `Value` (current value) and an event `ValueChanged` that fires whenever the watched value changes.
- `IsEnabled` property controls the internal timer; call `Start()` / `Stop()` to control monitoring.

Usage example:
```csharp
var watcher = new RegistryWatcher("HKEY_LOCAL_MACHINE\\SOFTWARE\\MyApp", "SomeValue");
watcher.ValueChanged += (s,e) => Console.WriteLine($"New value: {watcher.Value}");
watcher.Start();
```

Notes:
- This class reads values from the registry and throws if keys/value names are invalid. Polling is used instead of registry change notifications for simplicity.