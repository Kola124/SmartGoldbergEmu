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
namespace SmartGoldbergEmu
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.username_edit = new System.Windows.Forms.TextBox();
            this.steam_id_edit = new System.Windows.Forms.TextBox();
            this.port_edit = new System.Windows.Forms.TextBox();
            this.webapi_key_edit = new System.Windows.Forms.TextBox();
            this.language_combo = new System.Windows.Forms.ComboBox();
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SteamID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Language:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "WebAPI Key:";
            // 
            // username_edit
            // 
            this.username_edit.Location = new System.Drawing.Point(90, 22);
            this.username_edit.MaxLength = 32;
            this.username_edit.Name = "username_edit";
            this.username_edit.Size = new System.Drawing.Size(370, 20);
            this.username_edit.TabIndex = 5;
            // 
            // steam_id_edit
            // 
            this.steam_id_edit.Location = new System.Drawing.Point(90, 47);
            this.steam_id_edit.Name = "steam_id_edit";
            this.steam_id_edit.Size = new System.Drawing.Size(370, 20);
            this.steam_id_edit.TabIndex = 6;
            // 
            // port_edit
            // 
            this.port_edit.Location = new System.Drawing.Point(90, 97);
            this.port_edit.MaxLength = 5;
            this.port_edit.Name = "port_edit";
            this.port_edit.Size = new System.Drawing.Size(100, 20);
            this.port_edit.TabIndex = 8;
            // 
            // webapi_key_edit
            // 
            this.webapi_key_edit.Location = new System.Drawing.Point(90, 122);
            this.webapi_key_edit.MaxLength = 32;
            this.webapi_key_edit.Name = "webapi_key_edit";
            this.webapi_key_edit.Size = new System.Drawing.Size(370, 20);
            this.webapi_key_edit.TabIndex = 9;
            // 
            // language_combo
            // 
            this.language_combo.FormattingEnabled = true;
            this.language_combo.Location = new System.Drawing.Point(90, 72);
            this.language_combo.Name = "language_combo";
            this.language_combo.Size = new System.Drawing.Size(170, 21);
            this.language_combo.TabIndex = 10;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(385, 148);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 11;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(304, 148);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 12;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 182);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.language_combo);
            this.Controls.Add(this.webapi_key_edit);
            this.Controls.Add(this.port_edit);
            this.Controls.Add(this.steam_id_edit);
            this.Controls.Add(this.username_edit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox username_edit;
        private System.Windows.Forms.TextBox steam_id_edit;
        private System.Windows.Forms.TextBox port_edit;
        private System.Windows.Forms.TextBox webapi_key_edit;
        private System.Windows.Forms.ComboBox language_combo;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
    }
}