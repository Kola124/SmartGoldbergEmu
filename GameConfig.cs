/* Copyright (C) 2019-2020 Nemirtingas
   This file is part of the SmartGoldbergEmu Launcher

   The SmartGoldbergEmu Launcher is free software; you can redistribute it and/or
   modify it under the terms of the GNU Lesser General Public
   License as published by the Free Software Foundation; either
   version 3 of the License, or (at your option) any later version.

   The SmartGoldbergEmu Launcher is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
   Lesser General Public License for more details.

   You should have received a copy of the GNU Lesser General Public
   License along with the SmartGoldbergEmu Launcher; if not, see
   <http://www.gnu.org/licenses/>.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace SmartGoldbergEmu
{
    public class GameConfig
    {
        public EmuConfig Config { get; set; }
        public string StartFolder { get; set; }
        public string AppName { get; set; }
        public ulong AppId { get; set; }
        public string Parameters { get; set; }
        public bool UseX64 { get; set; }
        public bool DisableOverlay { get; set; }
        public bool DisableNetworking { get; set; }
        public bool DisableLANOnly { get; set; }
        public bool Offline { get; set; }
        public string LocalSave { get; set; }
        public List<string> CustomBroadcasts { get; set; }
        public List<string> EnvVars { get; set; }
        
        public Guid GameGuid { get; set; }
        public GameConfig()
        {
            StartFolder = AppName = Parameters = path = LocalSave = string.Empty;
            GameGuid = Guid.NewGuid();
            AppId = 0;
            UseX64 = false;
            DisableOverlay = false;
            DisableLANOnly = false;
            Offline = false;
            DisableNetworking = false;
            CustomBroadcasts = new List<string>();
            EnvVars = new List<string>();
        }

        // Absolute game path
        private string path;

        public string Path
        {
            get { return path; }
            set
            {
                try
                {
                    string path = System.IO.Path.GetFullPath(value);
                    /*if (File.Exists(path))
                    {
                        this.path = path;
                    }*/
                    this.path = path;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }

        public GameConfig Clone()
        {
            GameConfig copy = new GameConfig();
            copy.StartFolder = StartFolder;
            copy.AppName = AppName;
            copy.AppId = AppId;
            copy.Parameters = Parameters;
            copy.UseX64 = UseX64;
            copy.DisableOverlay = DisableOverlay;
            copy.DisableNetworking = DisableNetworking;
            copy.Offline = Offline;
            copy.DisableLANOnly = DisableLANOnly;
            copy.CustomBroadcasts = new List<string>(CustomBroadcasts);
            copy.EnvVars = new List<string>(EnvVars);
            copy.GameGuid = GameGuid;
            return copy;
        }

        public string GetGameEmuFolder()
        {
            return System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "games", AppId.ToString());
        }
    }
}
