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
using System.Collections.Generic;
using System.Text;

namespace SmartGoldbergEmu
{
    public class EmuConfig
    {
        public string username;//account_name.txt
        public string language;//language.txt
        public ushort port;//listen_port.txt
        public string steamid;//user_steam_id.txt
        public string webapi_key;
        public bool darkmod;

        public EmuConfig()
        {
            username = "Goldberg";
            language = "english";
            port = 0;
            steamid = "";
            webapi_key = "";
            darkmod = false;
        }
    }
    public class SavedConf
    {
        public string darkmod;
        public string webapi_key = "";
        public List<GameConfig> apps = new List<GameConfig>();
    }
}
