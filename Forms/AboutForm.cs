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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using OSUtility;

namespace SmartGoldbergEmu
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowEmuFolder(GameConfig app)
        {
            string emu_folder = OSFuncs.GetEmuApiFolder(app.UseX64);

            if (!Directory.Exists(emu_folder))
                Directory.CreateDirectory(emu_folder);

            try
            {
                if (OSDetector.IsWindows())
                    Process.Start("explorer.exe", emu_folder);
                else if (OSDetector.IsLinux())
                    Process.Start("nautilus", emu_folder);
            }
            catch
            {
                MessageBox.Show("Folder: " + emu_folder, "Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Steamapi_dll_folder_Click(object sender, EventArgs e)
        {
            GameConfig app = new GameConfig();
            app.UseX64 = false;
            ShowEmuFolder(app);
        }

        private void Steamapi64_dll_folder_Click(object sender, EventArgs e)
        {
            GameConfig app = new GameConfig();
            app.UseX64 = true;
            ShowEmuFolder(app);
        }
    }
}
