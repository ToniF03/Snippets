using Microsoft.Win32;
using System;
using System.Windows.Threading;

namespace uCalc.Tools
{
    class RegistryWatcher
    {
        DispatcherTimer Timer = new DispatcherTimer();
        string Key = "";
        string ValueKey = "";
        string _val = "";
        public event EventHandler ValueChanged;
        public string Value
        {
            get { return _val; }
            set { _val = value; ValueChanged.Invoke(this, EventArgs.Empty); }
        }
        public bool IsEnabled
        {
            get { return Timer.IsEnabled; }
            set { Timer.IsEnabled = value; }
        }
        public TimeSpan Interval
        {
            get { return Timer.Interval; }
            set { Timer.Interval = value; }
        }

        /// <summary>
        /// A watcher for a special value of a registry key.
        /// </summary>
        /// <param name="key">The path to the key.</param>
        /// <param name="valueName">The name of the observed value.</param>
        public RegistryWatcher(string key, string valueName)
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(200);
            if (key != "" && valueName != "" && key != null && valueName != null)
            {
                Key = key;
                ValueKey = valueName;
            }
            else
                throw new ArgumentNullException();
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(Key);
            if (regKey != null)
                throw new ArgumentException();
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            string newValue = Registry.GetValue(Key, ValueKey, (object)null).ToString();
            if (Value != newValue)
                Value = newValue;
        }
    }
}
