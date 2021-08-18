using System;
using System.IO;
using OSUtility;

namespace SmartGoldbergEmu
{
    public static class OSFuncs
    {
        public static string GetWindowsEmuApiFolder(bool x64)
        {
            return PrepareRootApiFolder("win", x64);
        }

        public static string GetLinuxEmuApiFolder(bool x64)
        {
            return PrepareRootApiFolder("linux", x64);
        }

        public static string GetMacOSEmuApiFolder(bool x64)
        {
            return Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "macosx") + Path.DirectorySeparatorChar;
        }

        private static string PrepareRootApiFolder(string OsSpecificFolder, bool x64)
        {
            return Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), OsSpecificFolder + (x64 ? "64" : "32")) + Path.DirectorySeparatorChar;
        }

        public static string GetEmuApiFolder(bool x64)
        {
            if (OSDetector.IsWindows())
            {
                return GetWindowsEmuApiFolder(x64);
            }
            else if (OSDetector.IsLinux())
            {
                return GetLinuxEmuApiFolder(x64);
            }
            else if (OSDetector.IsMacOS())
            {
                return GetMacOSEmuApiFolder(x64);
            }

            return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;
        }

        static public string GetWindowsSteamAPIName(bool x64)
        {
            return x64 ? "steamclient64.dll" : "steamclient.dll";
        }

        static public string GetLinuxSteamAPIName(bool x64)
        {
            return "steamclient.so";
        }

        static public string GetMacOSSteamAPIName(bool x64)
        {
            return "steamclient.dylib";
        }

        static public string GetSteamAPIName(bool x64)
        {
            string game_api = string.Empty;

            if (OSDetector.IsWindows())
            {
                return GetWindowsSteamAPIName(x64);
            }
            else if (OSDetector.IsLinux())
            {
                return GetLinuxSteamAPIName(x64);
            }
            else if (OSDetector.IsMacOS())
            {
                return GetMacOSSteamAPIName(x64);
            }

            return game_api;
        }
    }
}
