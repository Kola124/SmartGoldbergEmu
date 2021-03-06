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
    partial class GameSettingsForm
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
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.game_setting_tab = new System.Windows.Forms.TabPage();
            this.checkbox_offline = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableNetworking = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableLANOnly = new System.Windows.Forms.CheckBox();
            this.checkBox_disableOverlay = new System.Windows.Forms.CheckBox();
            this.local_save_edit = new System.Windows.Forms.TextBox();
            this.game_appid_edit = new System.Windows.Forms.TextBox();
            this.game_folder_edit = new System.Windows.Forms.TextBox();
            this.game_parameters_edit = new System.Windows.Forms.TextBox();
            this.game_exe_edit = new System.Windows.Forms.TextBox();
            this.game_name_edit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.browse_start_folder = new System.Windows.Forms.Button();
            this.browse_game_exe = new System.Windows.Forms.Button();
            this.x64_checkbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.game_setting_tab_ctrl = new System.Windows.Forms.TabControl();
            this.DLC_tab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.BrisanjeDLC = new System.Windows.Forms.Button();
            this.DLC_desc = new System.Windows.Forms.Label();
            this.DLC_save = new System.Windows.Forms.Button();
            this.DLC_add = new System.Windows.Forms.TextBox();
            this.broadcast_tab = new System.Windows.Forms.TabPage();
            this.DLLfold = new System.Windows.Forms.Button();
            this.Mods = new System.Windows.Forms.Button();
            this.button_clear_env_var = new System.Windows.Forms.Button();
            this.button_remove_env_var = new System.Windows.Forms.Button();
            this.button_add_env_var = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.listBox_env_var = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clear_broadcast_button = new System.Windows.Forms.Button();
            this.remove_broadcast_button = new System.Windows.Forms.Button();
            this.add_broadcast_button = new System.Windows.Forms.Button();
            this.ip_listBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.force_tab = new System.Windows.Forms.TabPage();
            this.delete_force_steamid = new System.Windows.Forms.Button();
            this.Delete_Port = new System.Windows.Forms.Button();
            this.Delete_Language = new System.Windows.Forms.Button();
            this.Delete_Name = new System.Windows.Forms.Button();
            this.force_steamid_save = new System.Windows.Forms.Button();
            this.force_listen_port_save = new System.Windows.Forms.Button();
            this.force_langugae_save = new System.Windows.Forms.Button();
            this.force_account_name_save = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.force_steamidpoigri_add = new System.Windows.Forms.TextBox();
            this.force_listen_port_add = new System.Windows.Forms.TextBox();
            this.force_langugae_add = new System.Windows.Forms.TextBox();
            this.force_account_name_add = new System.Windows.Forms.TextBox();
            this.Stats_tab = new System.Windows.Forms.TabPage();
            this.DeleteStats = new System.Windows.Forms.Button();
            this.stat_desc = new System.Windows.Forms.Label();
            this.stat_save = new System.Windows.Forms.Button();
            this.stat_add = new System.Windows.Forms.TextBox();
            this.Apppaths_tab = new System.Windows.Forms.TabPage();
            this.Apppt_Delete = new System.Windows.Forms.Button();
            this.Apppt_desc = new System.Windows.Forms.Label();
            this.Apppt_save = new System.Windows.Forms.Button();
            this.Apppt_add = new System.Windows.Forms.TextBox();
            this.Subgroups_tab = new System.Windows.Forms.TabPage();
            this.Sg_Delete = new System.Windows.Forms.Button();
            this.sg_desc = new System.Windows.Forms.Label();
            this.sg_save = new System.Windows.Forms.Button();
            this.sg_add = new System.Windows.Forms.TextBox();
            this.Depots_tab = new System.Windows.Forms.TabPage();
            this.Depots_Delete = new System.Windows.Forms.Button();
            this.depots_desc = new System.Windows.Forms.Label();
            this.depots_save = new System.Windows.Forms.Button();
            this.depots_add = new System.Windows.Forms.TextBox();
            this.getgamenameBUT = new System.Windows.Forms.Button();
            this.textBox_env_var_value = new CueTextBox();
            this.textBox_env_var_key = new CueTextBox();
            this.ip_textBox = new CueTextBox();
            this.game_setting_tab.SuspendLayout();
            this.game_setting_tab_ctrl.SuspendLayout();
            this.DLC_tab.SuspendLayout();
            this.broadcast_tab.SuspendLayout();
            this.force_tab.SuspendLayout();
            this.Stats_tab.SuspendLayout();
            this.Apppaths_tab.SuspendLayout();
            this.Subgroups_tab.SuspendLayout();
            this.Depots_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(549, 415);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 1;
            this.save.Text = "&Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(468, 415);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // game_setting_tab
            // 
            this.game_setting_tab.Controls.Add(this.getgamenameBUT);
            this.game_setting_tab.Controls.Add(this.checkbox_offline);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableNetworking);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableLANOnly);
            this.game_setting_tab.Controls.Add(this.checkBox_disableOverlay);
            this.game_setting_tab.Controls.Add(this.local_save_edit);
            this.game_setting_tab.Controls.Add(this.game_appid_edit);
            this.game_setting_tab.Controls.Add(this.game_folder_edit);
            this.game_setting_tab.Controls.Add(this.game_parameters_edit);
            this.game_setting_tab.Controls.Add(this.game_exe_edit);
            this.game_setting_tab.Controls.Add(this.game_name_edit);
            this.game_setting_tab.Controls.Add(this.label7);
            this.game_setting_tab.Controls.Add(this.browse_start_folder);
            this.game_setting_tab.Controls.Add(this.browse_game_exe);
            this.game_setting_tab.Controls.Add(this.x64_checkbox);
            this.game_setting_tab.Controls.Add(this.label5);
            this.game_setting_tab.Controls.Add(this.label4);
            this.game_setting_tab.Controls.Add(this.label3);
            this.game_setting_tab.Controls.Add(this.label2);
            this.game_setting_tab.Controls.Add(this.label1);
            this.game_setting_tab.Location = new System.Drawing.Point(4, 22);
            this.game_setting_tab.Name = "game_setting_tab";
            this.game_setting_tab.Padding = new System.Windows.Forms.Padding(3);
            this.game_setting_tab.Size = new System.Drawing.Size(604, 371);
            this.game_setting_tab.TabIndex = 0;
            this.game_setting_tab.Text = "Game Settings";
            this.game_setting_tab.UseVisualStyleBackColor = true;
            // 
            // checkbox_offline
            // 
            this.checkbox_offline.AutoSize = true;
            this.checkbox_offline.Location = new System.Drawing.Point(294, 172);
            this.checkbox_offline.Name = "checkbox_offline";
            this.checkbox_offline.Size = new System.Drawing.Size(56, 17);
            this.checkbox_offline.TabIndex = 26;
            this.checkbox_offline.Text = "Offline";
            this.checkbox_offline.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableNetworking
            // 
            this.checkBox_DisableNetworking.AutoSize = true;
            this.checkBox_DisableNetworking.Location = new System.Drawing.Point(170, 172);
            this.checkBox_DisableNetworking.Name = "checkBox_DisableNetworking";
            this.checkBox_DisableNetworking.Size = new System.Drawing.Size(118, 17);
            this.checkBox_DisableNetworking.TabIndex = 25;
            this.checkBox_DisableNetworking.Text = "Disable Networking";
            this.checkBox_DisableNetworking.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableLANOnly
            // 
            this.checkBox_DisableLANOnly.AutoSize = true;
            this.checkBox_DisableLANOnly.Location = new System.Drawing.Point(359, 149);
            this.checkBox_DisableLANOnly.Name = "checkBox_DisableLANOnly";
            this.checkBox_DisableLANOnly.Size = new System.Drawing.Size(109, 17);
            this.checkBox_DisableLANOnly.TabIndex = 24;
            this.checkBox_DisableLANOnly.Text = "Disable LAN Only";
            this.checkBox_DisableLANOnly.UseVisualStyleBackColor = true;
            // 
            // checkBox_disableOverlay
            // 
            this.checkBox_disableOverlay.AutoSize = true;
            this.checkBox_disableOverlay.Location = new System.Drawing.Point(253, 149);
            this.checkBox_disableOverlay.Name = "checkBox_disableOverlay";
            this.checkBox_disableOverlay.Size = new System.Drawing.Size(100, 17);
            this.checkBox_disableOverlay.TabIndex = 23;
            this.checkBox_disableOverlay.Text = "Disable Overlay";
            this.checkBox_disableOverlay.UseVisualStyleBackColor = true;
            // 
            // local_save_edit
            // 
            this.local_save_edit.Location = new System.Drawing.Point(170, 195);
            this.local_save_edit.Name = "local_save_edit";
            this.local_save_edit.Size = new System.Drawing.Size(357, 20);
            this.local_save_edit.TabIndex = 22;
            // 
            // game_appid_edit
            // 
            this.game_appid_edit.Location = new System.Drawing.Point(170, 122);
            this.game_appid_edit.Name = "game_appid_edit";
            this.game_appid_edit.Size = new System.Drawing.Size(168, 20);
            this.game_appid_edit.TabIndex = 9;
            // 
            // game_folder_edit
            // 
            this.game_folder_edit.Location = new System.Drawing.Point(170, 97);
            this.game_folder_edit.Name = "game_folder_edit";
            this.game_folder_edit.Size = new System.Drawing.Size(357, 20);
            this.game_folder_edit.TabIndex = 8;
            // 
            // game_parameters_edit
            // 
            this.game_parameters_edit.Location = new System.Drawing.Point(170, 72);
            this.game_parameters_edit.Name = "game_parameters_edit";
            this.game_parameters_edit.Size = new System.Drawing.Size(357, 20);
            this.game_parameters_edit.TabIndex = 6;
            // 
            // game_exe_edit
            // 
            this.game_exe_edit.Location = new System.Drawing.Point(170, 47);
            this.game_exe_edit.Name = "game_exe_edit";
            this.game_exe_edit.Size = new System.Drawing.Size(357, 20);
            this.game_exe_edit.TabIndex = 4;
            // 
            // game_name_edit
            // 
            this.game_name_edit.Location = new System.Drawing.Point(170, 22);
            this.game_name_edit.Name = "game_name_edit";
            this.game_name_edit.Size = new System.Drawing.Size(357, 20);
            this.game_name_edit.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Local Save Name:";
            // 
            // browse_start_folder
            // 
            this.browse_start_folder.Location = new System.Drawing.Point(534, 97);
            this.browse_start_folder.Name = "browse_start_folder";
            this.browse_start_folder.Size = new System.Drawing.Size(44, 20);
            this.browse_start_folder.TabIndex = 17;
            this.browse_start_folder.Text = "...";
            this.browse_start_folder.UseVisualStyleBackColor = true;
            this.browse_start_folder.Click += new System.EventHandler(this.Browse_start_folder_Click);
            // 
            // browse_game_exe
            // 
            this.browse_game_exe.Location = new System.Drawing.Point(534, 47);
            this.browse_game_exe.Name = "browse_game_exe";
            this.browse_game_exe.Size = new System.Drawing.Size(44, 20);
            this.browse_game_exe.TabIndex = 16;
            this.browse_game_exe.Text = "...";
            this.browse_game_exe.UseVisualStyleBackColor = true;
            this.browse_game_exe.Click += new System.EventHandler(this.Browse_game_exe_Click);
            // 
            // x64_checkbox
            // 
            this.x64_checkbox.AutoSize = true;
            this.x64_checkbox.Location = new System.Drawing.Point(170, 149);
            this.x64_checkbox.Name = "x64_checkbox";
            this.x64_checkbox.Size = new System.Drawing.Size(76, 17);
            this.x64_checkbox.TabIndex = 11;
            this.x64_checkbox.Text = "Use 64bits";
            this.x64_checkbox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Game AppID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Game Folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Game Parameters:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game Exe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game Name:";
            // 
            // game_setting_tab_ctrl
            // 
            this.game_setting_tab_ctrl.Controls.Add(this.game_setting_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.DLC_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.broadcast_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.force_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.Stats_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.Apppaths_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.Subgroups_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.Depots_tab);
            this.game_setting_tab_ctrl.Location = new System.Drawing.Point(12, 12);
            this.game_setting_tab_ctrl.Name = "game_setting_tab_ctrl";
            this.game_setting_tab_ctrl.SelectedIndex = 0;
            this.game_setting_tab_ctrl.Size = new System.Drawing.Size(612, 397);
            this.game_setting_tab_ctrl.TabIndex = 3;
            // 
            // DLC_tab
            // 
            this.DLC_tab.Controls.Add(this.button1);
            this.DLC_tab.Controls.Add(this.BrisanjeDLC);
            this.DLC_tab.Controls.Add(this.DLC_desc);
            this.DLC_tab.Controls.Add(this.DLC_save);
            this.DLC_tab.Controls.Add(this.DLC_add);
            this.DLC_tab.Location = new System.Drawing.Point(4, 22);
            this.DLC_tab.Name = "DLC_tab";
            this.DLC_tab.Padding = new System.Windows.Forms.Padding(3);
            this.DLC_tab.Size = new System.Drawing.Size(604, 371);
            this.DLC_tab.TabIndex = 2;
            this.DLC_tab.Text = "DLC";
            this.DLC_tab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get DLC info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BrisanjeDLC
            // 
            this.BrisanjeDLC.Location = new System.Drawing.Point(287, 13);
            this.BrisanjeDLC.Name = "BrisanjeDLC";
            this.BrisanjeDLC.Size = new System.Drawing.Size(139, 23);
            this.BrisanjeDLC.TabIndex = 3;
            this.BrisanjeDLC.Text = "Delete";
            this.BrisanjeDLC.UseVisualStyleBackColor = true;
            this.BrisanjeDLC.Click += new System.EventHandler(this.BrisanjeDLC_Click);
            // 
            // DLC_desc
            // 
            this.DLC_desc.AutoSize = true;
            this.DLC_desc.Location = new System.Drawing.Point(27, 18);
            this.DLC_desc.Name = "DLC_desc";
            this.DLC_desc.Size = new System.Drawing.Size(84, 13);
            this.DLC_desc.TabIndex = 2;
            this.DLC_desc.Text = "Custom DLC list:";
            // 
            // DLC_save
            // 
            this.DLC_save.Location = new System.Drawing.Point(432, 13);
            this.DLC_save.Name = "DLC_save";
            this.DLC_save.Size = new System.Drawing.Size(139, 23);
            this.DLC_save.TabIndex = 1;
            this.DLC_save.Text = "Save";
            this.DLC_save.UseVisualStyleBackColor = true;
            this.DLC_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // DLC_add
            // 
            this.DLC_add.AcceptsReturn = true;
            this.DLC_add.AcceptsTab = true;
            this.DLC_add.Location = new System.Drawing.Point(30, 53);
            this.DLC_add.Multiline = true;
            this.DLC_add.Name = "DLC_add";
            this.DLC_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DLC_add.Size = new System.Drawing.Size(541, 287);
            this.DLC_add.TabIndex = 0;
            // 
            // broadcast_tab
            // 
            this.broadcast_tab.Controls.Add(this.DLLfold);
            this.broadcast_tab.Controls.Add(this.Mods);
            this.broadcast_tab.Controls.Add(this.button_clear_env_var);
            this.broadcast_tab.Controls.Add(this.button_remove_env_var);
            this.broadcast_tab.Controls.Add(this.button_add_env_var);
            this.broadcast_tab.Controls.Add(this.label9);
            this.broadcast_tab.Controls.Add(this.textBox_env_var_value);
            this.broadcast_tab.Controls.Add(this.textBox_env_var_key);
            this.broadcast_tab.Controls.Add(this.listBox_env_var);
            this.broadcast_tab.Controls.Add(this.label6);
            this.broadcast_tab.Controls.Add(this.clear_broadcast_button);
            this.broadcast_tab.Controls.Add(this.remove_broadcast_button);
            this.broadcast_tab.Controls.Add(this.add_broadcast_button);
            this.broadcast_tab.Controls.Add(this.ip_listBox);
            this.broadcast_tab.Controls.Add(this.label8);
            this.broadcast_tab.Controls.Add(this.ip_textBox);
            this.broadcast_tab.Location = new System.Drawing.Point(4, 22);
            this.broadcast_tab.Name = "broadcast_tab";
            this.broadcast_tab.Padding = new System.Windows.Forms.Padding(3);
            this.broadcast_tab.Size = new System.Drawing.Size(604, 371);
            this.broadcast_tab.TabIndex = 1;
            this.broadcast_tab.Text = "Custom";
            this.broadcast_tab.UseVisualStyleBackColor = true;
            // 
            // DLLfold
            // 
            this.DLLfold.Location = new System.Drawing.Point(457, 41);
            this.DLLfold.Name = "DLLfold";
            this.DLLfold.Size = new System.Drawing.Size(141, 23);
            this.DLLfold.TabIndex = 37;
            this.DLLfold.Text = "Create DLL Folder";
            this.DLLfold.UseVisualStyleBackColor = true;
            this.DLLfold.Click += new System.EventHandler(this.DLLfold_Click);
            // 
            // Mods
            // 
            this.Mods.Location = new System.Drawing.Point(457, 13);
            this.Mods.Name = "Mods";
            this.Mods.Size = new System.Drawing.Size(141, 23);
            this.Mods.TabIndex = 36;
            this.Mods.Text = "Create Mods Folder";
            this.Mods.UseVisualStyleBackColor = true;
            this.Mods.Click += new System.EventHandler(this.Mods_Click);
            // 
            // button_clear_env_var
            // 
            this.button_clear_env_var.Location = new System.Drawing.Point(500, 215);
            this.button_clear_env_var.Name = "button_clear_env_var";
            this.button_clear_env_var.Size = new System.Drawing.Size(98, 23);
            this.button_clear_env_var.TabIndex = 35;
            this.button_clear_env_var.Text = "Clear";
            this.button_clear_env_var.UseVisualStyleBackColor = true;
            this.button_clear_env_var.Click += new System.EventHandler(this.button_clear_env_var_Click);
            // 
            // button_remove_env_var
            // 
            this.button_remove_env_var.Location = new System.Drawing.Point(500, 186);
            this.button_remove_env_var.Name = "button_remove_env_var";
            this.button_remove_env_var.Size = new System.Drawing.Size(98, 23);
            this.button_remove_env_var.TabIndex = 34;
            this.button_remove_env_var.Text = "Remove";
            this.button_remove_env_var.UseVisualStyleBackColor = true;
            this.button_remove_env_var.Click += new System.EventHandler(this.button_remove_env_var_Click);
            // 
            // button_add_env_var
            // 
            this.button_add_env_var.Location = new System.Drawing.Point(500, 157);
            this.button_add_env_var.Name = "button_add_env_var";
            this.button_add_env_var.Size = new System.Drawing.Size(98, 23);
            this.button_add_env_var.TabIndex = 33;
            this.button_add_env_var.Text = "Add";
            this.button_add_env_var.UseVisualStyleBackColor = true;
            this.button_add_env_var.Click += new System.EventHandler(this.button_add_env_var_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(177, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Custom Env var value";
            // 
            // listBox_env_var
            // 
            this.listBox_env_var.FormattingEnabled = true;
            this.listBox_env_var.Location = new System.Drawing.Point(30, 186);
            this.listBox_env_var.Name = "listBox_env_var";
            this.listBox_env_var.Size = new System.Drawing.Size(463, 121);
            this.listBox_env_var.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Custom Env var name";
            // 
            // clear_broadcast_button
            // 
            this.clear_broadcast_button.Location = new System.Drawing.Point(225, 72);
            this.clear_broadcast_button.Name = "clear_broadcast_button";
            this.clear_broadcast_button.Size = new System.Drawing.Size(93, 23);
            this.clear_broadcast_button.TabIndex = 27;
            this.clear_broadcast_button.Text = "Clear";
            this.clear_broadcast_button.UseVisualStyleBackColor = true;
            this.clear_broadcast_button.Click += new System.EventHandler(this.clear_broadcast_button_Click);
            // 
            // remove_broadcast_button
            // 
            this.remove_broadcast_button.Location = new System.Drawing.Point(225, 42);
            this.remove_broadcast_button.Name = "remove_broadcast_button";
            this.remove_broadcast_button.Size = new System.Drawing.Size(93, 23);
            this.remove_broadcast_button.TabIndex = 4;
            this.remove_broadcast_button.Text = "Remove";
            this.remove_broadcast_button.UseVisualStyleBackColor = true;
            this.remove_broadcast_button.Click += new System.EventHandler(this.remove_broadcast_button_Click);
            // 
            // add_broadcast_button
            // 
            this.add_broadcast_button.Location = new System.Drawing.Point(225, 13);
            this.add_broadcast_button.Name = "add_broadcast_button";
            this.add_broadcast_button.Size = new System.Drawing.Size(93, 23);
            this.add_broadcast_button.TabIndex = 3;
            this.add_broadcast_button.Text = "Add";
            this.add_broadcast_button.UseVisualStyleBackColor = true;
            this.add_broadcast_button.Click += new System.EventHandler(this.add_broadcast_button_Click);
            // 
            // ip_listBox
            // 
            this.ip_listBox.FormattingEnabled = true;
            this.ip_listBox.Location = new System.Drawing.Point(130, 41);
            this.ip_listBox.Name = "ip_listBox";
            this.ip_listBox.Size = new System.Drawing.Size(89, 82);
            this.ip_listBox.TabIndex = 2;
            this.ip_listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ip_listBox_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Custom Broadcast:";
            // 
            // force_tab
            // 
            this.force_tab.Controls.Add(this.delete_force_steamid);
            this.force_tab.Controls.Add(this.Delete_Port);
            this.force_tab.Controls.Add(this.Delete_Language);
            this.force_tab.Controls.Add(this.Delete_Name);
            this.force_tab.Controls.Add(this.force_steamid_save);
            this.force_tab.Controls.Add(this.force_listen_port_save);
            this.force_tab.Controls.Add(this.force_langugae_save);
            this.force_tab.Controls.Add(this.force_account_name_save);
            this.force_tab.Controls.Add(this.label13);
            this.force_tab.Controls.Add(this.label12);
            this.force_tab.Controls.Add(this.label11);
            this.force_tab.Controls.Add(this.label10);
            this.force_tab.Controls.Add(this.force_steamidpoigri_add);
            this.force_tab.Controls.Add(this.force_listen_port_add);
            this.force_tab.Controls.Add(this.force_langugae_add);
            this.force_tab.Controls.Add(this.force_account_name_add);
            this.force_tab.Location = new System.Drawing.Point(4, 22);
            this.force_tab.Name = "force_tab";
            this.force_tab.Padding = new System.Windows.Forms.Padding(3);
            this.force_tab.Size = new System.Drawing.Size(604, 371);
            this.force_tab.TabIndex = 7;
            this.force_tab.Text = "Force";
            this.force_tab.UseVisualStyleBackColor = true;
            // 
            // delete_force_steamid
            // 
            this.delete_force_steamid.Location = new System.Drawing.Point(315, 219);
            this.delete_force_steamid.Name = "delete_force_steamid";
            this.delete_force_steamid.Size = new System.Drawing.Size(120, 25);
            this.delete_force_steamid.TabIndex = 15;
            this.delete_force_steamid.Text = "Delete SteamID";
            this.delete_force_steamid.UseVisualStyleBackColor = true;
            this.delete_force_steamid.Click += new System.EventHandler(this.delete_force_steamid_Click);
            // 
            // Delete_Port
            // 
            this.Delete_Port.Location = new System.Drawing.Point(315, 162);
            this.Delete_Port.Name = "Delete_Port";
            this.Delete_Port.Size = new System.Drawing.Size(120, 25);
            this.Delete_Port.TabIndex = 14;
            this.Delete_Port.Text = "Delete Port";
            this.Delete_Port.UseVisualStyleBackColor = true;
            this.Delete_Port.Click += new System.EventHandler(this.Delete_Port_Click);
            // 
            // Delete_Language
            // 
            this.Delete_Language.Location = new System.Drawing.Point(315, 105);
            this.Delete_Language.Name = "Delete_Language";
            this.Delete_Language.Size = new System.Drawing.Size(120, 25);
            this.Delete_Language.TabIndex = 13;
            this.Delete_Language.Text = "Delete Language";
            this.Delete_Language.UseVisualStyleBackColor = true;
            this.Delete_Language.Click += new System.EventHandler(this.Delete_Language_Click);
            // 
            // Delete_Name
            // 
            this.Delete_Name.Location = new System.Drawing.Point(315, 48);
            this.Delete_Name.Name = "Delete_Name";
            this.Delete_Name.Size = new System.Drawing.Size(120, 25);
            this.Delete_Name.TabIndex = 12;
            this.Delete_Name.Text = "Delete Name";
            this.Delete_Name.UseVisualStyleBackColor = true;
            this.Delete_Name.Click += new System.EventHandler(this.Delete_Name_Click);
            // 
            // force_steamid_save
            // 
            this.force_steamid_save.Location = new System.Drawing.Point(175, 219);
            this.force_steamid_save.Name = "force_steamid_save";
            this.force_steamid_save.Size = new System.Drawing.Size(120, 25);
            this.force_steamid_save.TabIndex = 11;
            this.force_steamid_save.Text = "Save SteamID";
            this.force_steamid_save.UseVisualStyleBackColor = true;
            this.force_steamid_save.Click += new System.EventHandler(this.force_steamid_save_Click);
            // 
            // force_listen_port_save
            // 
            this.force_listen_port_save.Location = new System.Drawing.Point(175, 162);
            this.force_listen_port_save.Name = "force_listen_port_save";
            this.force_listen_port_save.Size = new System.Drawing.Size(120, 25);
            this.force_listen_port_save.TabIndex = 10;
            this.force_listen_port_save.Text = "Save Port";
            this.force_listen_port_save.UseVisualStyleBackColor = true;
            this.force_listen_port_save.Click += new System.EventHandler(this.force_listen_port_save_Click);
            // 
            // force_langugae_save
            // 
            this.force_langugae_save.Location = new System.Drawing.Point(175, 105);
            this.force_langugae_save.Name = "force_langugae_save";
            this.force_langugae_save.Size = new System.Drawing.Size(120, 25);
            this.force_langugae_save.TabIndex = 9;
            this.force_langugae_save.Text = "Save Language";
            this.force_langugae_save.UseVisualStyleBackColor = true;
            this.force_langugae_save.Click += new System.EventHandler(this.force_langugae_save_Click);
            // 
            // force_account_name_save
            // 
            this.force_account_name_save.Location = new System.Drawing.Point(175, 48);
            this.force_account_name_save.Name = "force_account_name_save";
            this.force_account_name_save.Size = new System.Drawing.Size(120, 25);
            this.force_account_name_save.TabIndex = 8;
            this.force_account_name_save.Text = "Save Name";
            this.force_account_name_save.UseVisualStyleBackColor = true;
            this.force_account_name_save.Click += new System.EventHandler(this.force_account_name_save_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Force SteamID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Force Listen Port:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Force Language:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Force Account Name:";
            // 
            // force_steamidpoigri_add
            // 
            this.force_steamidpoigri_add.Location = new System.Drawing.Point(175, 193);
            this.force_steamidpoigri_add.Name = "force_steamidpoigri_add";
            this.force_steamidpoigri_add.Size = new System.Drawing.Size(260, 20);
            this.force_steamidpoigri_add.TabIndex = 3;
            // 
            // force_listen_port_add
            // 
            this.force_listen_port_add.Location = new System.Drawing.Point(175, 136);
            this.force_listen_port_add.Name = "force_listen_port_add";
            this.force_listen_port_add.Size = new System.Drawing.Size(260, 20);
            this.force_listen_port_add.TabIndex = 2;
            // 
            // force_langugae_add
            // 
            this.force_langugae_add.Location = new System.Drawing.Point(175, 79);
            this.force_langugae_add.Name = "force_langugae_add";
            this.force_langugae_add.Size = new System.Drawing.Size(260, 20);
            this.force_langugae_add.TabIndex = 1;
            // 
            // force_account_name_add
            // 
            this.force_account_name_add.Location = new System.Drawing.Point(175, 22);
            this.force_account_name_add.Name = "force_account_name_add";
            this.force_account_name_add.Size = new System.Drawing.Size(260, 20);
            this.force_account_name_add.TabIndex = 0;
            // 
            // Stats_tab
            // 
            this.Stats_tab.Controls.Add(this.DeleteStats);
            this.Stats_tab.Controls.Add(this.stat_desc);
            this.Stats_tab.Controls.Add(this.stat_save);
            this.Stats_tab.Controls.Add(this.stat_add);
            this.Stats_tab.Location = new System.Drawing.Point(4, 22);
            this.Stats_tab.Name = "Stats_tab";
            this.Stats_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Stats_tab.Size = new System.Drawing.Size(604, 371);
            this.Stats_tab.TabIndex = 3;
            this.Stats_tab.Text = "Stats";
            this.Stats_tab.UseVisualStyleBackColor = true;
            // 
            // DeleteStats
            // 
            this.DeleteStats.Location = new System.Drawing.Point(287, 13);
            this.DeleteStats.Name = "DeleteStats";
            this.DeleteStats.Size = new System.Drawing.Size(139, 23);
            this.DeleteStats.TabIndex = 11;
            this.DeleteStats.Text = "Delete";
            this.DeleteStats.UseVisualStyleBackColor = true;
            this.DeleteStats.Click += new System.EventHandler(this.DeleteStats_Click);
            // 
            // stat_desc
            // 
            this.stat_desc.AutoSize = true;
            this.stat_desc.Location = new System.Drawing.Point(27, 18);
            this.stat_desc.Name = "stat_desc";
            this.stat_desc.Size = new System.Drawing.Size(72, 13);
            this.stat_desc.TabIndex = 10;
            this.stat_desc.Text = "Custom Stats:";
            // 
            // stat_save
            // 
            this.stat_save.Location = new System.Drawing.Point(432, 13);
            this.stat_save.Name = "stat_save";
            this.stat_save.Size = new System.Drawing.Size(139, 23);
            this.stat_save.TabIndex = 9;
            this.stat_save.Text = "Save";
            this.stat_save.UseVisualStyleBackColor = true;
            this.stat_save.Click += new System.EventHandler(this.stat_save_Click);
            // 
            // stat_add
            // 
            this.stat_add.AcceptsReturn = true;
            this.stat_add.AcceptsTab = true;
            this.stat_add.Location = new System.Drawing.Point(30, 53);
            this.stat_add.Multiline = true;
            this.stat_add.Name = "stat_add";
            this.stat_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.stat_add.Size = new System.Drawing.Size(541, 287);
            this.stat_add.TabIndex = 8;
            // 
            // Apppaths_tab
            // 
            this.Apppaths_tab.Controls.Add(this.Apppt_Delete);
            this.Apppaths_tab.Controls.Add(this.Apppt_desc);
            this.Apppaths_tab.Controls.Add(this.Apppt_save);
            this.Apppaths_tab.Controls.Add(this.Apppt_add);
            this.Apppaths_tab.Location = new System.Drawing.Point(4, 22);
            this.Apppaths_tab.Name = "Apppaths_tab";
            this.Apppaths_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Apppaths_tab.Size = new System.Drawing.Size(604, 371);
            this.Apppaths_tab.TabIndex = 6;
            this.Apppaths_tab.Text = "App Paths";
            this.Apppaths_tab.UseVisualStyleBackColor = true;
            // 
            // Apppt_Delete
            // 
            this.Apppt_Delete.Location = new System.Drawing.Point(287, 13);
            this.Apppt_Delete.Name = "Apppt_Delete";
            this.Apppt_Delete.Size = new System.Drawing.Size(139, 23);
            this.Apppt_Delete.TabIndex = 12;
            this.Apppt_Delete.Text = "Delete";
            this.Apppt_Delete.UseVisualStyleBackColor = true;
            this.Apppt_Delete.Click += new System.EventHandler(this.Apppt_Delete_Click);
            // 
            // Apppt_desc
            // 
            this.Apppt_desc.AutoSize = true;
            this.Apppt_desc.Location = new System.Drawing.Point(27, 18);
            this.Apppt_desc.Name = "Apppt_desc";
            this.Apppt_desc.Size = new System.Drawing.Size(112, 13);
            this.Apppt_desc.TabIndex = 10;
            this.Apppt_desc.Text = "Custom App Paths list:";
            // 
            // Apppt_save
            // 
            this.Apppt_save.Location = new System.Drawing.Point(432, 13);
            this.Apppt_save.Name = "Apppt_save";
            this.Apppt_save.Size = new System.Drawing.Size(139, 23);
            this.Apppt_save.TabIndex = 9;
            this.Apppt_save.Text = "Save";
            this.Apppt_save.UseVisualStyleBackColor = true;
            this.Apppt_save.Click += new System.EventHandler(this.Apppt_save_Click);
            // 
            // Apppt_add
            // 
            this.Apppt_add.AcceptsReturn = true;
            this.Apppt_add.AcceptsTab = true;
            this.Apppt_add.Location = new System.Drawing.Point(30, 53);
            this.Apppt_add.Multiline = true;
            this.Apppt_add.Name = "Apppt_add";
            this.Apppt_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Apppt_add.Size = new System.Drawing.Size(541, 287);
            this.Apppt_add.TabIndex = 8;
            // 
            // Subgroups_tab
            // 
            this.Subgroups_tab.Controls.Add(this.Sg_Delete);
            this.Subgroups_tab.Controls.Add(this.sg_desc);
            this.Subgroups_tab.Controls.Add(this.sg_save);
            this.Subgroups_tab.Controls.Add(this.sg_add);
            this.Subgroups_tab.Location = new System.Drawing.Point(4, 22);
            this.Subgroups_tab.Name = "Subgroups_tab";
            this.Subgroups_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Subgroups_tab.Size = new System.Drawing.Size(604, 371);
            this.Subgroups_tab.TabIndex = 4;
            this.Subgroups_tab.Text = "Subscribed Groups";
            this.Subgroups_tab.UseVisualStyleBackColor = true;
            // 
            // Sg_Delete
            // 
            this.Sg_Delete.Location = new System.Drawing.Point(287, 13);
            this.Sg_Delete.Name = "Sg_Delete";
            this.Sg_Delete.Size = new System.Drawing.Size(139, 23);
            this.Sg_Delete.TabIndex = 13;
            this.Sg_Delete.Text = "Delete";
            this.Sg_Delete.UseVisualStyleBackColor = true;
            this.Sg_Delete.Click += new System.EventHandler(this.Sg_Delete_Click);
            // 
            // sg_desc
            // 
            this.sg_desc.AutoSize = true;
            this.sg_desc.Location = new System.Drawing.Point(27, 18);
            this.sg_desc.Name = "sg_desc";
            this.sg_desc.Size = new System.Drawing.Size(153, 13);
            this.sg_desc.TabIndex = 6;
            this.sg_desc.Text = "Custom Subscribed Groups list:";
            // 
            // sg_save
            // 
            this.sg_save.Location = new System.Drawing.Point(432, 13);
            this.sg_save.Name = "sg_save";
            this.sg_save.Size = new System.Drawing.Size(139, 23);
            this.sg_save.TabIndex = 5;
            this.sg_save.Text = "Save";
            this.sg_save.UseVisualStyleBackColor = true;
            this.sg_save.Click += new System.EventHandler(this.sg_save_Click);
            // 
            // sg_add
            // 
            this.sg_add.AcceptsReturn = true;
            this.sg_add.AcceptsTab = true;
            this.sg_add.Location = new System.Drawing.Point(30, 53);
            this.sg_add.Multiline = true;
            this.sg_add.Name = "sg_add";
            this.sg_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sg_add.Size = new System.Drawing.Size(541, 287);
            this.sg_add.TabIndex = 4;
            // 
            // Depots_tab
            // 
            this.Depots_tab.Controls.Add(this.Depots_Delete);
            this.Depots_tab.Controls.Add(this.depots_desc);
            this.Depots_tab.Controls.Add(this.depots_save);
            this.Depots_tab.Controls.Add(this.depots_add);
            this.Depots_tab.Location = new System.Drawing.Point(4, 22);
            this.Depots_tab.Name = "Depots_tab";
            this.Depots_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Depots_tab.Size = new System.Drawing.Size(604, 371);
            this.Depots_tab.TabIndex = 5;
            this.Depots_tab.Text = "Depots";
            this.Depots_tab.UseVisualStyleBackColor = true;
            // 
            // Depots_Delete
            // 
            this.Depots_Delete.Location = new System.Drawing.Point(287, 13);
            this.Depots_Delete.Name = "Depots_Delete";
            this.Depots_Delete.Size = new System.Drawing.Size(139, 23);
            this.Depots_Delete.TabIndex = 14;
            this.Depots_Delete.Text = "Delete";
            this.Depots_Delete.UseVisualStyleBackColor = true;
            this.Depots_Delete.Click += new System.EventHandler(this.depots_brisanje_Click);
            // 
            // depots_desc
            // 
            this.depots_desc.AutoSize = true;
            this.depots_desc.Location = new System.Drawing.Point(27, 18);
            this.depots_desc.Name = "depots_desc";
            this.depots_desc.Size = new System.Drawing.Size(82, 13);
            this.depots_desc.TabIndex = 10;
            this.depots_desc.Text = "Custom Depots:";
            // 
            // depots_save
            // 
            this.depots_save.Location = new System.Drawing.Point(432, 13);
            this.depots_save.Name = "depots_save";
            this.depots_save.Size = new System.Drawing.Size(139, 23);
            this.depots_save.TabIndex = 9;
            this.depots_save.Text = "Save";
            this.depots_save.UseVisualStyleBackColor = true;
            this.depots_save.Click += new System.EventHandler(this.depots_save_Click);
            // 
            // depots_add
            // 
            this.depots_add.AcceptsReturn = true;
            this.depots_add.AcceptsTab = true;
            this.depots_add.Location = new System.Drawing.Point(30, 53);
            this.depots_add.Multiline = true;
            this.depots_add.Name = "depots_add";
            this.depots_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.depots_add.Size = new System.Drawing.Size(541, 287);
            this.depots_add.TabIndex = 8;
            // 
            // getgamenameBUT
            // 
            this.getgamenameBUT.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.getgamenameBUT.Location = new System.Drawing.Point(534, 22);
            this.getgamenameBUT.Name = "getgamenameBUT";
            this.getgamenameBUT.Size = new System.Drawing.Size(44, 20);
            this.getgamenameBUT.TabIndex = 27;
            this.getgamenameBUT.Text = "Q";
            this.getgamenameBUT.UseVisualStyleBackColor = true;
            this.getgamenameBUT.Click += new System.EventHandler(this.getgamenameBUT_Click);
            // 
            // textBox_env_var_value
            // 
            this.textBox_env_var_value.Cue = null;
            this.textBox_env_var_value.Location = new System.Drawing.Point(177, 157);
            this.textBox_env_var_value.Name = "textBox_env_var_value";
            this.textBox_env_var_value.Size = new System.Drawing.Size(316, 20);
            this.textBox_env_var_value.TabIndex = 31;
            // 
            // textBox_env_var_key
            // 
            this.textBox_env_var_key.Cue = null;
            this.textBox_env_var_key.Location = new System.Drawing.Point(30, 157);
            this.textBox_env_var_key.Name = "textBox_env_var_key";
            this.textBox_env_var_key.Size = new System.Drawing.Size(140, 20);
            this.textBox_env_var_key.TabIndex = 30;
            // 
            // ip_textBox
            // 
            this.ip_textBox.Cue = "127.0.0.1";
            this.ip_textBox.Location = new System.Drawing.Point(130, 15);
            this.ip_textBox.Name = "ip_textBox";
            this.ip_textBox.Size = new System.Drawing.Size(89, 20);
            this.ip_textBox.TabIndex = 1;
            this.ip_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ip_textBox_KeyDown);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 450);
            this.Controls.Add(this.game_setting_tab_ctrl);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Game Settings";
            this.game_setting_tab.ResumeLayout(false);
            this.game_setting_tab.PerformLayout();
            this.game_setting_tab_ctrl.ResumeLayout(false);
            this.DLC_tab.ResumeLayout(false);
            this.DLC_tab.PerformLayout();
            this.broadcast_tab.ResumeLayout(false);
            this.broadcast_tab.PerformLayout();
            this.force_tab.ResumeLayout(false);
            this.force_tab.PerformLayout();
            this.Stats_tab.ResumeLayout(false);
            this.Stats_tab.PerformLayout();
            this.Apppaths_tab.ResumeLayout(false);
            this.Apppaths_tab.PerformLayout();
            this.Subgroups_tab.ResumeLayout(false);
            this.Subgroups_tab.PerformLayout();
            this.Depots_tab.ResumeLayout(false);
            this.Depots_tab.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TabPage game_setting_tab;
        private System.Windows.Forms.TextBox local_save_edit;
        private System.Windows.Forms.TextBox game_appid_edit;
        private System.Windows.Forms.TextBox game_folder_edit;
        private System.Windows.Forms.TextBox game_parameters_edit;
        private System.Windows.Forms.TextBox game_exe_edit;
        private System.Windows.Forms.TextBox game_name_edit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button browse_start_folder;
        private System.Windows.Forms.Button browse_game_exe;
        private System.Windows.Forms.CheckBox x64_checkbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl game_setting_tab_ctrl;
        private System.Windows.Forms.TabPage broadcast_tab;
        private System.Windows.Forms.Button remove_broadcast_button;
        private System.Windows.Forms.Button add_broadcast_button;
        private System.Windows.Forms.ListBox ip_listBox;
        private CueTextBox ip_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button clear_broadcast_button;
        private System.Windows.Forms.Button button_clear_env_var;
        private System.Windows.Forms.Button button_remove_env_var;
        private System.Windows.Forms.Button button_add_env_var;
        private System.Windows.Forms.Label label9;
        private CueTextBox textBox_env_var_value;
        private CueTextBox textBox_env_var_key;
        private System.Windows.Forms.ListBox listBox_env_var;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_disableOverlay;
        private System.Windows.Forms.CheckBox checkBox_DisableLANOnly;
        private System.Windows.Forms.CheckBox checkBox_DisableNetworking;
        private System.Windows.Forms.CheckBox checkbox_offline;
        private System.Windows.Forms.TabPage DLC_tab;
        private System.Windows.Forms.TextBox DLC_add;
        private System.Windows.Forms.Button DLC_save;
        private System.Windows.Forms.Label DLC_desc;
        private System.Windows.Forms.TabPage Stats_tab;
        private System.Windows.Forms.TabPage Subgroups_tab;
        private System.Windows.Forms.TabPage Depots_tab;
        private System.Windows.Forms.TabPage Apppaths_tab;
        private System.Windows.Forms.Label sg_desc;
        private System.Windows.Forms.Button sg_save;
        private System.Windows.Forms.TextBox sg_add;
        private System.Windows.Forms.Label stat_desc;
        private System.Windows.Forms.Button stat_save;
        private System.Windows.Forms.TextBox stat_add;
        private System.Windows.Forms.Label Apppt_desc;
        private System.Windows.Forms.Button Apppt_save;
        private System.Windows.Forms.TextBox Apppt_add;
        private System.Windows.Forms.Label depots_desc;
        private System.Windows.Forms.Button depots_save;
        private System.Windows.Forms.TextBox depots_add;
        private System.Windows.Forms.Button Mods;
        private System.Windows.Forms.Button DLLfold;
        private System.Windows.Forms.TabPage force_tab;
        private System.Windows.Forms.TextBox force_steamidpoigri_add;
        private System.Windows.Forms.TextBox force_listen_port_add;
        private System.Windows.Forms.TextBox force_langugae_add;
        private System.Windows.Forms.TextBox force_account_name_add;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button force_account_name_save;
        private System.Windows.Forms.Button force_langugae_save;
        private System.Windows.Forms.Button force_steamid_save;
        private System.Windows.Forms.Button force_listen_port_save;
        private System.Windows.Forms.Button BrisanjeDLC;
        private System.Windows.Forms.Button DeleteStats;
        private System.Windows.Forms.Button Apppt_Delete;
        private System.Windows.Forms.Button Sg_Delete;
        private System.Windows.Forms.Button Depots_Delete;
        private System.Windows.Forms.Button Delete_Name;
        private System.Windows.Forms.Button delete_force_steamid;
        private System.Windows.Forms.Button Delete_Port;
        private System.Windows.Forms.Button Delete_Language;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button getgamenameBUT;
    }
}