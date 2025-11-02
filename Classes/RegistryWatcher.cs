using Microsoft.Win32;
using System;
using System.Windows.Threading;

    /// <summary>
    /// Monitors changes to a specific Windows Registry value and raises events when the value changes.
    /// Uses a polling mechanism with a configurable interval to detect changes.
    /// </summary>
    class RegistryWatcher
    {
        // Timer for periodic registry value checks
        DispatcherTimer Timer = new DispatcherTimer();
        
        // Full path to the registry key being monitored
        string Key = "";
        
        // Name of the specific value within the key being monitored
        string ValueKey = "";
        
        // Current cached value from the registry
        string _val = "";
        
        /// <summary>
        /// Event raised when the monitored registry value changes.
        /// </summary>
        public event EventHandler ValueChanged;
        
        /// <summary>
        /// Gets or sets the current value of the monitored registry entry.
        /// Setting this property triggers the ValueChanged event.
        /// </summary>
        public string Value
        {
            get { return _val; }
            set { _val = value; ValueChanged.Invoke(this, EventArgs.Empty); }
        }
        
        /// <summary>
        /// Gets or sets whether the registry watcher is currently enabled.
        /// </summary>
        public bool IsEnabled
        {
            get { return Timer.IsEnabled; }
            set { Timer.IsEnabled = value; }
        }
        
        /// <summary>
        /// Gets or sets the polling interval for checking registry changes.
        /// Default is 200 milliseconds.
        /// </summary>
        public TimeSpan Interval
        {
            get { return Timer.Interval; }
            set { Timer.Interval = value; }
        }

        /// <summary>
        /// Initializes a new instance of the RegistryWatcher class to monitor a specific registry value.
        /// </summary>
        /// <param name="key">The full path to the registry key (e.g., "HKEY_LOCAL_MACHINE\\Software\\MyApp").</param>
        /// <param name="valueName">The name of the value within the key to monitor.</param>
        /// <exception cref="ArgumentNullException">Thrown if key or valueName is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if the registry key cannot be opened.</exception>
        public RegistryWatcher(string key, string valueName)
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(200);
            
            // Validate input parameters
            if (key != "" && valueName != "" && key != null && valueName != null)
            {
                Key = key;
                ValueKey = valueName;
            }
            else
                throw new ArgumentNullException();
            
            // Verify the registry key exists
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(Key);
            if (regKey != null)
                throw new ArgumentException();
            
            // Read initial value and start monitoring
            _val = Registry.GetValue(Key, ValueKey, (object)null).ToString();
            Timer.Start();
        }

        /// <summary>
        /// Starts the registry watcher.
        /// </summary>
        public void Start()
        {
            Timer.Start();
        }

        /// <summary>
        /// Stops the registry watcher.
        /// </summary>
        public void Stop()
        {
            Timer.Stop();
        }

        /// <summary>
        /// Timer callback that polls the registry for changes.
        /// Compares current value with cached value and raises ValueChanged event if different.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            string newValue = Registry.GetValue(Key, ValueKey, (object)null).ToString();
            if (Value != newValue)
                Value = newValue;  // This will trigger the ValueChanged event
        }
    }
