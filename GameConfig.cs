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
using System.Text;

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
        public bool EnableHTTP { get; set; }
        public bool DisableAvatar { get; set; }
        public bool DisableSQuery { get; set; }
        public bool DisableAchNotif { get; set; }
        public bool DisableFriendNotif { get; set; }
        public bool SteamDeck { get; set; }
        public bool AchBypass { get; set; }
        public bool Offline { get; set; }
        //Stats
        public bool UnknownStats { get; set; }
        public bool SaveHigherStat { get; set; }
        public bool GameserverStat { get; set; }
        public bool DisableStatShare { get; set; }
        public bool UnlockAllDLC { get; set; }
        //Newadded
        public bool DisLobbyCreation { get; set; }
        public bool ShareLeaderboard { get; set; }
        public bool UnknownLeaderboard { get; set; }
        public bool ActualType { get; set; }
        public bool MatchmakeSource { get; set; }
        public bool HttpSuccess { get; set; }

        public string LocalSave { get; set; }
        public string CustomIcon { get; set; }

        public List<string> CustomBroadcasts { get; set; }
        public List<string> EnvVars { get; set; }


        public Guid GameGuid { get; set; }
        public GameConfig()
        {
            StartFolder = AppName = Parameters = path = LocalSave = string.Empty;
            CustomIcon = string.Empty;
            GameGuid = Guid.NewGuid();
            AppId = 0;
            UseX64 = false;
            DisableOverlay = false;
            DisableLANOnly = false;
            Offline = false;
            DisableNetworking = false;
            EnableHTTP = false;
            DisableAvatar = false;
            DisableSQuery = false;
            DisableAchNotif = false;
            DisableFriendNotif = false;
            SteamDeck = false;
            AchBypass = false;
            UnlockAllDLC = false;
            //stats
            UnknownStats = false;
            SaveHigherStat = true;
            GameserverStat = false;
            DisableStatShare = false;
            //
            //Newer stuff
            DisLobbyCreation = false;
            ShareLeaderboard = false;
            UnknownLeaderboard = false;
            ActualType = false;
            MatchmakeSource = false;
            HttpSuccess = false;
            //

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
            GameConfig copy = new GameConfig
            {
                StartFolder = StartFolder,
                AppName = AppName,
                AppId = AppId,
                Parameters = Parameters,
                UseX64 = UseX64,
                DisableOverlay = DisableOverlay,
                DisableNetworking = DisableNetworking,
                Offline = Offline,
                DisableLANOnly = DisableLANOnly,
                EnableHTTP = EnableHTTP,
                DisableAvatar = DisableAvatar,
                DisableSQuery = DisableSQuery,
                DisableAchNotif = DisableAchNotif,
                DisableFriendNotif = DisableFriendNotif,
                SteamDeck = SteamDeck,
                AchBypass = AchBypass,
                UnlockAllDLC= UnlockAllDLC,
                UnknownStats = UnknownStats,
                SaveHigherStat = SaveHigherStat,
                GameserverStat = GameserverStat,
                DisableStatShare = DisableStatShare,
                DisLobbyCreation=DisLobbyCreation,
                ShareLeaderboard=ShareLeaderboard,
                UnknownLeaderboard=UnknownLeaderboard,
                ActualType = ActualType,
                MatchmakeSource = MatchmakeSource,
                HttpSuccess = HttpSuccess,
                CustomBroadcasts = new List<string>(CustomBroadcasts),
                EnvVars = new List<string>(EnvVars),
                GameGuid = GameGuid
            };
            return copy;
        }

        public string GetGameEmuFolder()
        {
            return System.IO.Path.Combine(System.IO.Path.GetFullPath("."), "games", AppId.ToString());
        }
    }
}
