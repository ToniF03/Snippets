
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Interop;

    /// <summary>
    /// Contains native Windows COM interfaces and classes for working with shell links (.lnk files).
    /// Provides P/Invoke declarations and enumerations for shortcut manipulation.
    /// </summary>
    static internal class NativeClasses
    {
        /// <summary>
        /// Flags for IShellLink::Resolve method that control link resolution behavior.
        /// </summary>
        [Flags]
        internal enum SLR_MODE : uint
        {
            SLR_INVOKE_MSI = 0x80,
            SLR_NOLINKINFO = 0x40,
            SLR_NO_UI = 0x1,
            SLR_NOUPDATE = 0x8,
            SLR_NOSEARCH = 0x10,
            SLR_NOTRACK = 0x20,
            SLR_UPDATE = 0x4,
            SLR_NO_UI_WITH_MSG_PUMP = 0x101
        }

        /// <summary>
        /// Storage access mode flags for IPersistFile operations.
        /// </summary>
        [Flags]
        internal enum STGM_ACCESS : uint
        {
            STGM_READ = 0x00000000,
            STGM_WRITE = 0x00000001,
            STGM_READWRITE = 0x00000002,
            STGM_SHARE_DENY_NONE = 0x00000040,
            STGM_SHARE_DENY_READ = 0x00000030,
            STGM_SHARE_DENY_WRITE = 0x00000020,
            STGM_SHARE_EXCLUSIVE = 0x00000010,
            STGM_PRIORITY = 0x00040000,
            STGM_CREATE = 0x00001000,
            STGM_CONVERT = 0x00020000,
            STGM_FAILIFTHERE = 0x00000000,
            STGM_DIRECT = 0x00000000,
            STGM_TRANSACTED = 0x00010000,
            STGM_NOSCRATCH = 0x00100000,
            STGM_NOSNAPSHOT = 0x00200000,
            STGM_SIMPLE = 0x08000000,
            STGM_DIRECT_SWMR = 0x00400000,
            STGM_DELETEONRELEASE = 0x04000000
        }

        /// <summary>
        /// Represents a Windows FILETIME structure.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0)]
        internal struct _FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }

        /// <summary>
        /// Contains information about a file found by the FindFirstFile, FindFirstFileEx, or FindNextFile functions.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 0, CharSet = CharSet.Unicode)]
        internal struct _WIN32_FIND_DATAW
        {
            public uint dwFileAttributes;
            public _FILETIME ftCreationTime;
            public _FILETIME ftLastAccessTime;
            public _FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        // Flags for IShellLink::GetPath method
        internal const uint SLGP_SHORTPATH = 0x01;      // Return short (8.3 format) path
        internal const uint SLGP_UNCPRIORITY = 0x02;    // Prioritize UNC path over drive letter
        internal const uint SLGP_RAWPATH = 0x04;        // Return raw path without resolving

        /// <summary>
        /// COM interface for Windows Shell Link objects (.lnk files).
        /// Provides methods to create, modify, and query shortcut properties.
        /// </summary>
        [ComImport()]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IShellLinkW
        {
            [PreserveSig()]
            int GetPath([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, ref _WIN32_FIND_DATAW pfd, uint fFlags);

            [PreserveSig()]
            int GetIDList(out IntPtr ppidl);

            [PreserveSig()]
            int SetIDList(IntPtr pidl);

            [PreserveSig()]
            int GetDescription([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxName);

            [PreserveSig()]
            int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);

            [PreserveSig()]
            int GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);

            [PreserveSig()]
            int SetWorkingDirectory(
               [MarshalAs(UnmanagedType.LPWStr)] string pszDir);

            [PreserveSig()]
            int GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);

            [PreserveSig()]
            int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);

            [PreserveSig()]
            int GetHotkey(out ushort pwHotkey);

            [PreserveSig()]
            int SetHotkey(ushort pwHotkey);

            [PreserveSig()]
            int GetShowCmd(out uint piShowCmd);

            [PreserveSig()]
            int SetShowCmd(uint piShowCmd);

            [PreserveSig()]
            int GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);

            [PreserveSig()]
            int SetIconLocation(
               [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);

            [PreserveSig()]
            int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);

            [PreserveSig()]
            int Resolve(IntPtr hWnd, uint fFlags);

            [PreserveSig()]
            int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        /// <summary>
        /// COM interface for persisting objects to storage (files).
        /// Used to save and load shell links.
        /// </summary>
        [ComImport()]
        [Guid("0000010B-0000-0000-C000-000000000046")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IPersistFile
        {
            [PreserveSig()]
            int GetClassID(out Guid pClassID);

            [PreserveSig()]
            int IsDirty();

            [PreserveSig()]
            int Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, uint dwMode);

            [PreserveSig()]
            int Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

            [PreserveSig()]
            int SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

            [PreserveSig()]
            int GetCurFile([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath);
        }

        /// <summary>
        /// COM class for creating shell link objects.
        /// </summary>
        [Guid("00021401-0000-0000-C000-000000000046")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComImport()]
        private class CShellLink { }

        /// <summary>
        /// Factory method to create a new IShellLinkW instance.
        /// </summary>
        /// <returns>A new shell link interface.</returns>
        internal static NativeClasses.IShellLinkW CreateShellLink()
        {
            return (NativeClasses.IShellLinkW)new NativeClasses.CShellLink();
        }
    }

/// <summary>
/// Provides a managed wrapper for creating and manipulating Windows shell links (.lnk files).
/// Encapsulates the COM interfaces for easier use from C# code.
/// </summary>
public class Shortcut
{
    // Maximum length for shortcut descriptions
    private const int MAX_DESCRIPTION_LENGTH = 512;
    
    // Maximum path length for file paths
    private const int MAX_PATH = 512;

    // The underlying COM shell link interface
    private NativeClasses.IShellLinkW _link;

    /// <summary>
    /// Initializes a new instance of the Shortcut class.
    /// </summary>
    public Shortcut()
    {
        this._link = NativeClasses.CreateShellLink();
    }

    /// <summary>
    /// Initializes a new instance of the Shortcut class with a target path.
    /// </summary>
    /// <param name="path">The target path for the shortcut.</param>
    public Shortcut(string path)
        : this()
    {
        Marshal.ThrowExceptionForHR(this._link.SetPath(path));
    }

    /// <summary>
    /// Gets or sets the target path of the shortcut.
    /// </summary>
    public string Path
    {
        get
        {
            NativeClasses._WIN32_FIND_DATAW fdata = new NativeClasses._WIN32_FIND_DATAW();
            StringBuilder path = new StringBuilder(MAX_PATH, MAX_PATH);
            Marshal.ThrowExceptionForHR(this._link.GetPath(path, path.MaxCapacity, ref fdata, NativeClasses.SLGP_UNCPRIORITY));
            return path.ToString();
        }
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetPath(value));
        }
    }

    /// <summary>
    /// Gets or sets the description text for the shortcut.
    /// </summary>
    public string Description
    {
        get
        {
            StringBuilder desc = new StringBuilder(MAX_DESCRIPTION_LENGTH, MAX_DESCRIPTION_LENGTH);
            Marshal.ThrowExceptionForHR(this._link.GetDescription(desc, desc.MaxCapacity));
            return desc.ToString();
        }
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetDescription(value));
        }
    }

    /// <summary>
    /// Sets the relative path for the shortcut (write-only property).
    /// </summary>
    public string RelativePath
    {
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetRelativePath(value, 0));
        }
    }

    /// <summary>
    /// Gets or sets the working directory for the shortcut target.
    /// </summary>
    public string WorkingDirectory
    {
        get
        {
            StringBuilder dir = new StringBuilder(MAX_PATH, MAX_PATH);
            Marshal.ThrowExceptionForHR(this._link.GetWorkingDirectory(dir, dir.MaxCapacity));
            return dir.ToString();
        }
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetWorkingDirectory(value));
        }
    }

    /// <summary>
    /// Gets or sets the command-line arguments passed to the shortcut target.
    /// </summary>
    public string Arguments
    {
        get
        {
            StringBuilder args = new StringBuilder(MAX_PATH, MAX_PATH);
            Marshal.ThrowExceptionForHR(this._link.GetArguments(args, args.MaxCapacity));
            return args.ToString();
        }
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetArguments(value));
        }
    }

    /// <summary>
    /// Gets or sets the keyboard shortcut (hot key) for the shortcut.
    /// </summary>
    public ushort HotKey
    {
        get
        {
            ushort key = 0;
            Marshal.ThrowExceptionForHR(this._link.GetHotkey(out key));
            return key;
        }
        set
        {
            Marshal.ThrowExceptionForHR(this._link.SetHotkey(value));
        }
    }

    /// <summary>
    /// Resolves the shortcut, attempting to find the target even if it has moved.
    /// </summary>
    /// <param name="hwnd">Handle to parent window for UI.</param>
    /// <param name="flags">Resolution behavior flags.</param>
    public void Resolve(IntPtr hwnd, uint flags)
    {
        Marshal.ThrowExceptionForHR(this._link.Resolve(hwnd, flags));
    }

    /// <summary>
    /// Resolves the shortcut using a WinForms window as the parent.
    /// </summary>
    /// <param name="window">The parent window.</param>
    public void Resolve(IWin32Window window)
    {
        this.Resolve(window.Handle, 0);
    }

    /// <summary>
    /// Resolves the shortcut silently without showing any UI.
    /// </summary>
    public void Resolve()
    {
        this.Resolve(IntPtr.Zero, (uint)NativeClasses.SLR_MODE.SLR_NO_UI);
    }

    /// <summary>
    /// Gets the shell link as an IPersistFile interface for file operations.
    /// </summary>
    private NativeClasses.IPersistFile AsPersist
    {
        get { return ((NativeClasses.IPersistFile)this._link); }
    }

    /// <summary>
    /// Saves the shortcut to a file.
    /// </summary>
    /// <param name="fileName">The path where the .lnk file will be saved.</param>
    public void Save(string fileName)
    {
        int hres = this.AsPersist.Save(fileName, true);
        Marshal.ThrowExceptionForHR(hres);
    }

    /// <summary>
    /// Loads an existing shortcut from a file.
    /// </summary>
    /// <param name="fileName">The path to the .lnk file to load.</param>
    public void Load(string fileName)
    {
        int hres = this.AsPersist.Load(fileName, (uint)NativeClasses.STGM_ACCESS.STGM_READ);
        Marshal.ThrowExceptionForHR(hres);
    }
}
