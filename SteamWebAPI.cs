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
using System.Collections.Generic;

namespace SmartGoldbergEmu
{
    public class CSteamGameSchema
    {
        public CGame game = new CGame();
    }

    public class CGame
    {
        public string gameName = "";
        public string gameVersion = "";
        public CAvailableGameStats availableGameStats = new CAvailableGameStats();
    }

    public class CAvailableGameStats
    {
        public List<CAchievement> achievements = new List<CAchievement>();
    }

    public class CAchievement
    {
        public string name = "";
        public int defaultvalue = 0;
        public string displayName = "";
        public int hidden = 0;
        public string description = "";
        public string icon = "";
        public string icongray = "";
    }

    public class CSteamMetaResponse
    {
        public CMetaResponse response = new CMetaResponse();
    }

    public class CMetaResponse
    {
        public ulong modified;
        public string digest;
    }
}
