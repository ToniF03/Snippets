using Microsoft.Win32;
using System;
using System.Windows.Threading;

class RegistryWatcher
{
    private readonly DispatcherTimer timer = new DispatcherTimer();
    private string keyPath = "";
    private string valueName = "";
    private string value = "";
    public event EventHandler ValueChanged;
    public string Value
    {
        get { return value; }
        set { this.value = value; ValueChanged.Invoke(this, EventArgs.Empty); }
    }
    public bool IsEnabled
    {
        get { return timer.IsEnabled; }
        set { timer.IsEnabled = value; }
    }
    public TimeSpan Interval
    {
        get { return timer.Interval; }
        set { timer.Interval = value; }
    }

    /// <summary>
    /// A watcher for a special value of a registry key.
    /// </summary>
    /// <param name="key">The path to the key.</param>
    /// <param name="valueName">The name of the observed value.</param>
    public RegistryWatcher(string key, string valueName)
    {
        timer.Tick += Timer_Tick;
        timer.Interval = TimeSpan.FromMilliseconds(200);
        if (key != "" && valueName != "" && key != null && valueName != null)
        {
            keyPath = key;
            this.valueName = valueName;
        }
        else
            throw new ArgumentNullException();
        RegistryKey regKey = Registry.LocalMachine.OpenSubKey(keyPath);
        if (regKey != null)
            throw new ArgumentException();
        value = Registry.GetValue(keyPath, this.valueName, (object)null).ToString();
        timer.Start();
    }

    /// <summary>
    /// Starts the registry watcher.
    /// </summary>
    public void Start()
    {
        timer.Start();
    }

    /// <summary>
    /// Stops the registry watcher.
    /// </summary>
    public void Stop()
    {
        timer.Stop();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        string newValue = Registry.GetValue(keyPath, valueName, (object)null).ToString();
        if (Value != newValue)
        Value = newValue;
    }
}
