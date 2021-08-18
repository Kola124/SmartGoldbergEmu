using System;
using System.Runtime.InteropServices;

namespace OSUtility
{
    public enum OsId
    {
        Unknown,
        Windows,
        Linux,
        MacOSX,
        Unix,
        //AIX,
        //HP_UX,
        //FreeBSD,
    }

    class OSDetector
    {
        public static OsId OsId { get; }

        [DllImport("libc")]
        static extern int uname(IntPtr buf);

        static OSDetector()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    OsId = OsId.Windows;
                    break;

                case PlatformID.MacOSX:
                    OsId = OsId.MacOSX;
                    break;

                case PlatformID.Unix:
                    {
                        // Mono will not return PlatformID == MacOSX
                        IntPtr buf = IntPtr.Zero;
                        try
                        {
                            buf = Marshal.AllocHGlobal(8192);
                            // This is a hacktastic way of getting sysname from uname ()
                            if (uname(buf) == 0)
                            {
                                string os = Marshal.PtrToStringAnsi(buf);
                                switch (os)
                                {
                                    case "Darwin":
                                        OsId = OsId.MacOSX;
                                        break;

                                    case "Linux":
                                        OsId = OsId.Linux;
                                        break;

                                    //case "AIX":
                                    //case "HP-UX":
                                    //case "FreeBSD":

                                    default:
                                        OsId = OsId.Unix;
                                        break;
                                }
                            }
                        }
                        catch
                        {
                        }
                        finally
                        {
                            if (buf != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(buf);
                            }
                        }
                    }
                    break;
            }
        }

        public static bool IsWindows()
        {
            return OsId == OsId.Windows;
        }

        public static bool IsLinux()
        {
            return OsId == OsId.Linux;
        }

        public static bool IsMacOS()
        {
            return OsId == OsId.MacOSX;
        }

        public static OsId GetOS()
        {
            return OsId;
        }
    }
}
