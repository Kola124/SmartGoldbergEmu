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
using System.Windows.Forms;

namespace SmartGoldbergEmu
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            SteamEmulator.Initialize();

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SmartGoldbergEmuMainForm());
            }
            else
            {
                try
                {
                    GameConfig game = SteamEmulator.Apps.Find(p => p.GameGuid == Guid.Parse(args[0]));
                    SteamEmulator.StartGame(game);
                    System.Threading.Thread.Sleep(20000); // Sleep for 20 seconds ?
                    SteamEmulator.RestoreSteam();
                }
                catch(Exception)
                { }
            }
        }
    }
}
