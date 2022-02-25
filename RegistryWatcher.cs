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

        public RegistryWatcher(string key, string valueName)
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromMilliseconds(200);
            if (key != "" && valueName != "")
            {
                Key = key;
                ValueKey = valueName;
            }
            else
                throw new ArgumentException();
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(Key);
            if (regKey != null)
                throw new ArgumentException();
            _val = Registry.GetValue(Key, ValueKey, (object)null).ToString();
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string newValue = Registry.GetValue(Key, ValueKey, (object)null).ToString();
            if (Value != newValue)
                Value = newValue;
        }
    }
}
