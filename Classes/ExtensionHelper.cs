using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Provides helper methods for registering and unregistering file extensions in Windows registry.
    /// Allows applications to associate file types with their executables.
    /// </summary>
    public static class ExtensionHelper
    {
        /// <summary>
        /// Registers a file extension for your application in the Windows registry.
        /// Creates entries in HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths and HKCR.
        /// </summary>
        /// <param name="extension">The file extension to register (e.g., ".txt" or "txt").</param>
        /// <param name="icon">Path to the icon file (currently unused in implementation).</param>
        /// <param name="AppProgId">The program identifier/name for the file type (e.g., "MyApp.Document").</param>
        /// <param name="progid">Full path to the application executable.</param>
        /// <returns>True if registration succeeded, false if an error occurred.</returns>
        public static bool RegisterExtension(string extension, string icon, string AppProgId, string progid)
        {
            try
            {
                // Register the application path in the App Paths registry
                RegistryKey AppPath = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths");
                AppPath = AppPath.CreateSubKey(Path.GetFileName(progid));
                AppPath.SetValue("", progid);  // Set default value to full executable path
                AppPath.SetValue("Path", Path.GetDirectoryName(progid));  // Set working directory

                // Register the file extension association
                RegistryKey ExtensionPath = Registry.ClassesRoot.CreateSubKey(extension.StartsWith(".") ? extension : "." + extension);
                ExtensionPath.SetValue("", AppProgId);  // Associate extension with ProgID
                ExtensionPath = ExtensionPath.CreateSubKey("shell\\open\\command");
                ExtensionPath.SetValue("", "\"" + progid + "\" %1");  // Set command to open files with this extension
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        /// <summary>
        /// Unregisters a previously registered file extension from the Windows registry.
        /// Removes entries from App Paths and Class Root registry keys.
        /// </summary>
        /// <param name="extension">The file extension to unregister (e.g., ".txt" or "txt").</param>
        /// <param name="icon">Path to the icon (unused, included for signature compatibility).</param>
        /// <param name="AppProgId">The program identifier (unused, included for signature compatibility).</param>
        /// <param name="progid">Full path to the application executable.</param>
        /// <returns>True if unregistration succeeded, false if an error occurred.</returns>
        public static bool UnregisterExtension(string extension, string icon, string AppProgId, string progid)
        {
            try
            {
                // Remove application from App Paths registry
                RegistryKey AppPath = Registry.LocalMachine;
                AppPath.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + Path.GetFileName(progid));

                // Remove file extension association from Classes Root
                RegistryKey ExtensionPath = Registry.ClassesRoot;
                ExtensionPath.DeleteSubKey(extension.StartsWith(".") ? extension : "." + extension);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
