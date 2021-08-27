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
   <http://www.gnu.org/licenses/>.  */

namespace SmartGoldbergEmu
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ok_button = new System.Windows.Forms.Button();
            this.steamapi_dll_folder = new System.Windows.Forms.Button();
            this.steamapi64_dll_folder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(473, 197);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 0;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // steamapi_dll_folder
            // 
            this.steamapi_dll_folder.Location = new System.Drawing.Point(12, 139);
            this.steamapi_dll_folder.Name = "steamapi_dll_folder";
            this.steamapi_dll_folder.Size = new System.Drawing.Size(536, 23);
            this.steamapi_dll_folder.TabIndex = 1;
            this.steamapi_dll_folder.Text = "Folder to goldberg\'s 32bits steamclient.dll";
            this.steamapi_dll_folder.UseVisualStyleBackColor = true;
            this.steamapi_dll_folder.Click += new System.EventHandler(this.Steamapi_dll_folder_Click);
            // 
            // steamapi64_dll_folder
            // 
            this.steamapi64_dll_folder.Location = new System.Drawing.Point(12, 168);
            this.steamapi64_dll_folder.Name = "steamapi64_dll_folder";
            this.steamapi64_dll_folder.Size = new System.Drawing.Size(536, 23);
            this.steamapi64_dll_folder.TabIndex = 2;
            this.steamapi64_dll_folder.Text = "Folder to goldberg\'s 64bits steamclient64.dll";
            this.steamapi64_dll_folder.UseVisualStyleBackColor = true;
            this.steamapi64_dll_folder.Click += new System.EventHandler(this.Steamapi64_dll_folder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartGoldbergEmu.Properties.Resources.steel_steam_128;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 104);
            this.label1.TabIndex = 4;
            this.label1.TabStop = true;
            this.label1.Text = "Smart Goldberg Emu.\r\nMade by Nemirtingas\r\nEdited by Kola124\r\n\r\nThis application U" +
    "I is inspired by SmartSteamEmu Launcher.\r\nYou can find original on gitlab:\r\n\r\nAn" +
    "d edit on github: ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(147, 83);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(242, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://gitlab.com/Nemirtingas/smartgoldbergemu";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(147, 109);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(235, 13);
            this.linkLabel2.TabIndex = 6;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://github.com/Kola124/SmartGoldbergEmu";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 230);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.steamapi64_dll_folder);
            this.Controls.Add(this.steamapi_dll_folder);
            this.Controls.Add(this.ok_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button steamapi_dll_folder;
        private System.Windows.Forms.Button steamapi64_dll_folder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}