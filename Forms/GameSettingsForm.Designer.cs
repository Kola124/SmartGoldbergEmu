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
            this.Force_tab = new System.Windows.Forms.TabPage();
            this.force_steamidpoigri_add = new System.Windows.Forms.TextBox();
            this.force_listen_port_add = new System.Windows.Forms.TextBox();
            this.force_langugae_add = new System.Windows.Forms.TextBox();
            this.force_account_name_add = new System.Windows.Forms.TextBox();
            this.local_save_edit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Apppaths_tab = new System.Windows.Forms.TabPage();
            this.depots_add = new System.Windows.Forms.TextBox();
            this.depots_desc = new System.Windows.Forms.Label();
            this.sg_add = new System.Windows.Forms.TextBox();
            this.sg_desc = new System.Windows.Forms.Label();
            this.Apppt_desc = new System.Windows.Forms.Label();
            this.Apppt_add = new System.Windows.Forms.TextBox();
            this.Stats_tab = new System.Windows.Forms.TabPage();
            this.stat_desc = new System.Windows.Forms.Label();
            this.stat_add = new System.Windows.Forms.TextBox();
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
            this.DLC_tab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.DLC_desc = new System.Windows.Forms.Label();
            this.DLC_add = new System.Windows.Forms.TextBox();
            this.game_setting_tab = new System.Windows.Forms.TabPage();
            this.checkBox_DisableAchNotif = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableSQuery = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableAvatar = new System.Windows.Forms.CheckBox();
            this.clan_tag_add = new System.Windows.Forms.TextBox();
            this.game_appid_edit = new System.Windows.Forms.TextBox();
            this.game_folder_edit = new System.Windows.Forms.TextBox();
            this.game_parameters_edit = new System.Windows.Forms.TextBox();
            this.game_exe_edit = new System.Windows.Forms.TextBox();
            this.game_name_edit = new System.Windows.Forms.TextBox();
            this.Clantag = new System.Windows.Forms.Label();
            this.checkBox_EnableHTTP = new System.Windows.Forms.CheckBox();
            this.getgamenameBUT = new System.Windows.Forms.Button();
            this.checkbox_offline = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableNetworking = new System.Windows.Forms.CheckBox();
            this.checkBox_DisableLANOnly = new System.Windows.Forms.CheckBox();
            this.checkBox_disableOverlay = new System.Windows.Forms.CheckBox();
            this.browse_start_folder = new System.Windows.Forms.Button();
            this.browse_game_exe = new System.Windows.Forms.Button();
            this.x64_checkbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.game_setting_tab_ctrl = new System.Windows.Forms.TabControl();
            this.ServerBrowser = new System.Windows.Forms.TabPage();
            this.HisServ_add = new System.Windows.Forms.TextBox();
            this.History_label = new System.Windows.Forms.Label();
            this.FavServ_add = new System.Windows.Forms.TextBox();
            this.serfav_label = new System.Windows.Forms.Label();
            this.serbrow_label = new System.Windows.Forms.Label();
            this.Server_add = new System.Windows.Forms.TextBox();
            this.DLCinfo_gameinfo = new System.Windows.Forms.Button();
            this.textBox_env_var_value = new CueTextBox();
            this.textBox_env_var_key = new CueTextBox();
            this.ip_textBox = new CueTextBox();
            this.GetStats = new System.Windows.Forms.Button();
            this.Force_tab.SuspendLayout();
            this.Apppaths_tab.SuspendLayout();
            this.Stats_tab.SuspendLayout();
            this.broadcast_tab.SuspendLayout();
            this.DLC_tab.SuspendLayout();
            this.game_setting_tab.SuspendLayout();
            this.game_setting_tab_ctrl.SuspendLayout();
            this.ServerBrowser.SuspendLayout();
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
            // Force_tab
            // 
            this.Force_tab.Controls.Add(this.force_steamidpoigri_add);
            this.Force_tab.Controls.Add(this.force_listen_port_add);
            this.Force_tab.Controls.Add(this.force_langugae_add);
            this.Force_tab.Controls.Add(this.force_account_name_add);
            this.Force_tab.Controls.Add(this.local_save_edit);
            this.Force_tab.Controls.Add(this.label13);
            this.Force_tab.Controls.Add(this.label12);
            this.Force_tab.Controls.Add(this.label11);
            this.Force_tab.Controls.Add(this.label10);
            this.Force_tab.Controls.Add(this.label7);
            this.Force_tab.Location = new System.Drawing.Point(4, 22);
            this.Force_tab.Name = "Force_tab";
            this.Force_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Force_tab.Size = new System.Drawing.Size(604, 371);
            this.Force_tab.TabIndex = 7;
            this.Force_tab.Text = "Force";
            this.Force_tab.UseVisualStyleBackColor = true;
            // 
            // force_steamidpoigri_add
            // 
            this.force_steamidpoigri_add.Location = new System.Drawing.Point(170, 122);
            this.force_steamidpoigri_add.Name = "force_steamidpoigri_add";
            this.force_steamidpoigri_add.Size = new System.Drawing.Size(357, 20);
            this.force_steamidpoigri_add.TabIndex = 44;
            // 
            // force_listen_port_add
            // 
            this.force_listen_port_add.Location = new System.Drawing.Point(170, 97);
            this.force_listen_port_add.Name = "force_listen_port_add";
            this.force_listen_port_add.Size = new System.Drawing.Size(144, 20);
            this.force_listen_port_add.TabIndex = 42;
            // 
            // force_langugae_add
            // 
            this.force_langugae_add.Location = new System.Drawing.Point(170, 72);
            this.force_langugae_add.Name = "force_langugae_add";
            this.force_langugae_add.Size = new System.Drawing.Size(357, 20);
            this.force_langugae_add.TabIndex = 40;
            // 
            // force_account_name_add
            // 
            this.force_account_name_add.Location = new System.Drawing.Point(170, 47);
            this.force_account_name_add.Name = "force_account_name_add";
            this.force_account_name_add.Size = new System.Drawing.Size(357, 20);
            this.force_account_name_add.TabIndex = 38;
            // 
            // local_save_edit
            // 
            this.local_save_edit.Location = new System.Drawing.Point(170, 22);
            this.local_save_edit.Name = "local_save_edit";
            this.local_save_edit.Size = new System.Drawing.Size(357, 20);
            this.local_save_edit.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(49, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Force SteamID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(49, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Force Listen Port:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Force Language:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Force Account Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Local Save Name:";
            // 
            // Apppaths_tab
            // 
            this.Apppaths_tab.Controls.Add(this.depots_add);
            this.Apppaths_tab.Controls.Add(this.depots_desc);
            this.Apppaths_tab.Controls.Add(this.sg_add);
            this.Apppaths_tab.Controls.Add(this.sg_desc);
            this.Apppaths_tab.Controls.Add(this.Apppt_desc);
            this.Apppaths_tab.Controls.Add(this.Apppt_add);
            this.Apppaths_tab.Location = new System.Drawing.Point(4, 22);
            this.Apppaths_tab.Name = "Apppaths_tab";
            this.Apppaths_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Apppaths_tab.Size = new System.Drawing.Size(604, 371);
            this.Apppaths_tab.TabIndex = 6;
            this.Apppaths_tab.Text = "Paths, Groups,Depot";
            this.Apppaths_tab.UseVisualStyleBackColor = true;
            // 
            // depots_add
            // 
            this.depots_add.AcceptsReturn = true;
            this.depots_add.AcceptsTab = true;
            this.depots_add.Location = new System.Drawing.Point(30, 262);
            this.depots_add.Multiline = true;
            this.depots_add.Name = "depots_add";
            this.depots_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.depots_add.Size = new System.Drawing.Size(541, 95);
            this.depots_add.TabIndex = 14;
            // 
            // depots_desc
            // 
            this.depots_desc.AutoSize = true;
            this.depots_desc.Location = new System.Drawing.Point(27, 246);
            this.depots_desc.Name = "depots_desc";
            this.depots_desc.Size = new System.Drawing.Size(82, 13);
            this.depots_desc.TabIndex = 13;
            this.depots_desc.Text = "Custom Depots:";
            // 
            // sg_add
            // 
            this.sg_add.AcceptsReturn = true;
            this.sg_add.AcceptsTab = true;
            this.sg_add.Location = new System.Drawing.Point(30, 148);
            this.sg_add.Multiline = true;
            this.sg_add.Name = "sg_add";
            this.sg_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sg_add.Size = new System.Drawing.Size(541, 95);
            this.sg_add.TabIndex = 12;
            // 
            // sg_desc
            // 
            this.sg_desc.AutoSize = true;
            this.sg_desc.Location = new System.Drawing.Point(27, 132);
            this.sg_desc.Name = "sg_desc";
            this.sg_desc.Size = new System.Drawing.Size(153, 13);
            this.sg_desc.TabIndex = 11;
            this.sg_desc.Text = "Custom Subscribed Groups list:";
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
            // Apppt_add
            // 
            this.Apppt_add.AcceptsReturn = true;
            this.Apppt_add.AcceptsTab = true;
            this.Apppt_add.Location = new System.Drawing.Point(30, 34);
            this.Apppt_add.Multiline = true;
            this.Apppt_add.Name = "Apppt_add";
            this.Apppt_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Apppt_add.Size = new System.Drawing.Size(541, 95);
            this.Apppt_add.TabIndex = 8;
            // 
            // Stats_tab
            // 
            this.Stats_tab.Controls.Add(this.GetStats);
            this.Stats_tab.Controls.Add(this.stat_desc);
            this.Stats_tab.Controls.Add(this.stat_add);
            this.Stats_tab.Location = new System.Drawing.Point(4, 22);
            this.Stats_tab.Name = "Stats_tab";
            this.Stats_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Stats_tab.Size = new System.Drawing.Size(604, 371);
            this.Stats_tab.TabIndex = 3;
            this.Stats_tab.Text = "Stats";
            this.Stats_tab.UseVisualStyleBackColor = true;
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
            this.broadcast_tab.Controls.Add(this.ip_textBox);
            this.broadcast_tab.Controls.Add(this.listBox_env_var);
            this.broadcast_tab.Controls.Add(this.label6);
            this.broadcast_tab.Controls.Add(this.clear_broadcast_button);
            this.broadcast_tab.Controls.Add(this.remove_broadcast_button);
            this.broadcast_tab.Controls.Add(this.add_broadcast_button);
            this.broadcast_tab.Controls.Add(this.ip_listBox);
            this.broadcast_tab.Controls.Add(this.label8);
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
            this.button_clear_env_var.Click += new System.EventHandler(this.Button_clear_env_var_Click);
            // 
            // button_remove_env_var
            // 
            this.button_remove_env_var.Location = new System.Drawing.Point(500, 186);
            this.button_remove_env_var.Name = "button_remove_env_var";
            this.button_remove_env_var.Size = new System.Drawing.Size(98, 23);
            this.button_remove_env_var.TabIndex = 34;
            this.button_remove_env_var.Text = "Remove";
            this.button_remove_env_var.UseVisualStyleBackColor = true;
            this.button_remove_env_var.Click += new System.EventHandler(this.Button_remove_env_var_Click);
            // 
            // button_add_env_var
            // 
            this.button_add_env_var.Location = new System.Drawing.Point(500, 157);
            this.button_add_env_var.Name = "button_add_env_var";
            this.button_add_env_var.Size = new System.Drawing.Size(98, 23);
            this.button_add_env_var.TabIndex = 33;
            this.button_add_env_var.Text = "Add";
            this.button_add_env_var.UseVisualStyleBackColor = true;
            this.button_add_env_var.Click += new System.EventHandler(this.Button_add_env_var_Click);
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
            this.clear_broadcast_button.Click += new System.EventHandler(this.Clear_broadcast_button_Click);
            // 
            // remove_broadcast_button
            // 
            this.remove_broadcast_button.Location = new System.Drawing.Point(225, 42);
            this.remove_broadcast_button.Name = "remove_broadcast_button";
            this.remove_broadcast_button.Size = new System.Drawing.Size(93, 23);
            this.remove_broadcast_button.TabIndex = 4;
            this.remove_broadcast_button.Text = "Remove";
            this.remove_broadcast_button.UseVisualStyleBackColor = true;
            this.remove_broadcast_button.Click += new System.EventHandler(this.Remove_broadcast_button_Click);
            // 
            // add_broadcast_button
            // 
            this.add_broadcast_button.Location = new System.Drawing.Point(225, 13);
            this.add_broadcast_button.Name = "add_broadcast_button";
            this.add_broadcast_button.Size = new System.Drawing.Size(93, 23);
            this.add_broadcast_button.TabIndex = 3;
            this.add_broadcast_button.Text = "Add";
            this.add_broadcast_button.UseVisualStyleBackColor = true;
            this.add_broadcast_button.Click += new System.EventHandler(this.Add_broadcast_button_Click);
            // 
            // ip_listBox
            // 
            this.ip_listBox.FormattingEnabled = true;
            this.ip_listBox.Location = new System.Drawing.Point(130, 41);
            this.ip_listBox.Name = "ip_listBox";
            this.ip_listBox.Size = new System.Drawing.Size(89, 82);
            this.ip_listBox.TabIndex = 2;
            this.ip_listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ip_listBox_KeyDown);
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
            // DLC_tab
            // 
            this.DLC_tab.Controls.Add(this.DLCinfo_gameinfo);
            this.DLC_tab.Controls.Add(this.button1);
            this.DLC_tab.Controls.Add(this.DLC_desc);
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
            this.button1.Location = new System.Drawing.Point(287, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Get DLC info from Steam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
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
            // game_setting_tab
            // 
            this.game_setting_tab.Controls.Add(this.checkBox_DisableAchNotif);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableSQuery);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableAvatar);
            this.game_setting_tab.Controls.Add(this.clan_tag_add);
            this.game_setting_tab.Controls.Add(this.game_appid_edit);
            this.game_setting_tab.Controls.Add(this.game_folder_edit);
            this.game_setting_tab.Controls.Add(this.game_parameters_edit);
            this.game_setting_tab.Controls.Add(this.game_exe_edit);
            this.game_setting_tab.Controls.Add(this.game_name_edit);
            this.game_setting_tab.Controls.Add(this.Clantag);
            this.game_setting_tab.Controls.Add(this.checkBox_EnableHTTP);
            this.game_setting_tab.Controls.Add(this.getgamenameBUT);
            this.game_setting_tab.Controls.Add(this.checkbox_offline);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableNetworking);
            this.game_setting_tab.Controls.Add(this.checkBox_DisableLANOnly);
            this.game_setting_tab.Controls.Add(this.checkBox_disableOverlay);
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
            // checkBox_DisableAchNotif
            // 
            this.checkBox_DisableAchNotif.AutoSize = true;
            this.checkBox_DisableAchNotif.Location = new System.Drawing.Point(359, 195);
            this.checkBox_DisableAchNotif.Name = "checkBox_DisableAchNotif";
            this.checkBox_DisableAchNotif.Size = new System.Drawing.Size(182, 17);
            this.checkBox_DisableAchNotif.TabIndex = 41;
            this.checkBox_DisableAchNotif.Text = "Disable Achievement Notification";
            this.checkBox_DisableAchNotif.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableSQuery
            // 
            this.checkBox_DisableSQuery.AutoSize = true;
            this.checkBox_DisableSQuery.Location = new System.Drawing.Point(170, 195);
            this.checkBox_DisableSQuery.Name = "checkBox_DisableSQuery";
            this.checkBox_DisableSQuery.Size = new System.Drawing.Size(129, 17);
            this.checkBox_DisableSQuery.TabIndex = 40;
            this.checkBox_DisableSQuery.Text = "Disable Source Query";
            this.checkBox_DisableSQuery.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableAvatar
            // 
            this.checkBox_DisableAvatar.AutoSize = true;
            this.checkBox_DisableAvatar.Location = new System.Drawing.Point(253, 172);
            this.checkBox_DisableAvatar.Name = "checkBox_DisableAvatar";
            this.checkBox_DisableAvatar.Size = new System.Drawing.Size(95, 17);
            this.checkBox_DisableAvatar.TabIndex = 39;
            this.checkBox_DisableAvatar.Text = "Disable Avatar";
            this.checkBox_DisableAvatar.UseVisualStyleBackColor = true;
            // 
            // clan_tag_add
            // 
            this.clan_tag_add.Location = new System.Drawing.Point(403, 122);
            this.clan_tag_add.Name = "clan_tag_add";
            this.clan_tag_add.Size = new System.Drawing.Size(124, 20);
            this.clan_tag_add.TabIndex = 38;
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
            // Clantag
            // 
            this.Clantag.AutoSize = true;
            this.Clantag.Location = new System.Drawing.Point(344, 125);
            this.Clantag.Name = "Clantag";
            this.Clantag.Size = new System.Drawing.Size(53, 13);
            this.Clantag.TabIndex = 37;
            this.Clantag.Text = "Clan Tag:";
            // 
            // checkBox_EnableHTTP
            // 
            this.checkBox_EnableHTTP.AutoSize = true;
            this.checkBox_EnableHTTP.Location = new System.Drawing.Point(359, 172);
            this.checkBox_EnableHTTP.Name = "checkBox_EnableHTTP";
            this.checkBox_EnableHTTP.Size = new System.Drawing.Size(236, 17);
            this.checkBox_EnableHTTP.TabIndex = 36;
            this.checkBox_EnableHTTP.Text = "Enable HTTP (Disable lan only has to be on)";
            this.checkBox_EnableHTTP.UseVisualStyleBackColor = true;
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
            this.getgamenameBUT.Click += new System.EventHandler(this.GetgamenameBUT_Click);
            // 
            // checkbox_offline
            // 
            this.checkbox_offline.AutoSize = true;
            this.checkbox_offline.Location = new System.Drawing.Point(170, 172);
            this.checkbox_offline.Name = "checkbox_offline";
            this.checkbox_offline.Size = new System.Drawing.Size(56, 17);
            this.checkbox_offline.TabIndex = 26;
            this.checkbox_offline.Text = "Offline";
            this.checkbox_offline.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisableNetworking
            // 
            this.checkBox_DisableNetworking.AutoSize = true;
            this.checkBox_DisableNetworking.Location = new System.Drawing.Point(170, 218);
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
            this.game_setting_tab_ctrl.Controls.Add(this.Force_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.DLC_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.ServerBrowser);
            this.game_setting_tab_ctrl.Controls.Add(this.Stats_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.Apppaths_tab);
            this.game_setting_tab_ctrl.Controls.Add(this.broadcast_tab);
            this.game_setting_tab_ctrl.Location = new System.Drawing.Point(12, 12);
            this.game_setting_tab_ctrl.Name = "game_setting_tab_ctrl";
            this.game_setting_tab_ctrl.SelectedIndex = 0;
            this.game_setting_tab_ctrl.Size = new System.Drawing.Size(612, 397);
            this.game_setting_tab_ctrl.TabIndex = 3;
            // 
            // ServerBrowser
            // 
            this.ServerBrowser.Controls.Add(this.HisServ_add);
            this.ServerBrowser.Controls.Add(this.History_label);
            this.ServerBrowser.Controls.Add(this.FavServ_add);
            this.ServerBrowser.Controls.Add(this.serfav_label);
            this.ServerBrowser.Controls.Add(this.serbrow_label);
            this.ServerBrowser.Controls.Add(this.Server_add);
            this.ServerBrowser.Location = new System.Drawing.Point(4, 22);
            this.ServerBrowser.Name = "ServerBrowser";
            this.ServerBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.ServerBrowser.Size = new System.Drawing.Size(604, 371);
            this.ServerBrowser.TabIndex = 8;
            this.ServerBrowser.Text = "Server Browser";
            this.ServerBrowser.UseVisualStyleBackColor = true;
            // 
            // HisServ_add
            // 
            this.HisServ_add.AcceptsReturn = true;
            this.HisServ_add.AcceptsTab = true;
            this.HisServ_add.Location = new System.Drawing.Point(30, 262);
            this.HisServ_add.Multiline = true;
            this.HisServ_add.Name = "HisServ_add";
            this.HisServ_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HisServ_add.Size = new System.Drawing.Size(541, 95);
            this.HisServ_add.TabIndex = 20;
            // 
            // History_label
            // 
            this.History_label.AutoSize = true;
            this.History_label.Location = new System.Drawing.Point(27, 246);
            this.History_label.Name = "History_label";
            this.History_label.Size = new System.Drawing.Size(64, 13);
            this.History_label.TabIndex = 19;
            this.History_label.Text = "History Tab:";
            // 
            // FavServ_add
            // 
            this.FavServ_add.AcceptsReturn = true;
            this.FavServ_add.AcceptsTab = true;
            this.FavServ_add.Location = new System.Drawing.Point(30, 148);
            this.FavServ_add.Multiline = true;
            this.FavServ_add.Name = "FavServ_add";
            this.FavServ_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FavServ_add.Size = new System.Drawing.Size(541, 95);
            this.FavServ_add.TabIndex = 18;
            // 
            // serfav_label
            // 
            this.serfav_label.AutoSize = true;
            this.serfav_label.Location = new System.Drawing.Point(27, 132);
            this.serfav_label.Name = "serfav_label";
            this.serfav_label.Size = new System.Drawing.Size(75, 13);
            this.serfav_label.TabIndex = 17;
            this.serfav_label.Text = "Favorites Tab:";
            // 
            // serbrow_label
            // 
            this.serbrow_label.AutoSize = true;
            this.serbrow_label.Location = new System.Drawing.Point(27, 18);
            this.serbrow_label.Name = "serbrow_label";
            this.serbrow_label.Size = new System.Drawing.Size(140, 13);
            this.serbrow_label.TabIndex = 16;
            this.serbrow_label.Text = "Internet and Spectate Tabs:";
            // 
            // Server_add
            // 
            this.Server_add.AcceptsReturn = true;
            this.Server_add.AcceptsTab = true;
            this.Server_add.Location = new System.Drawing.Point(30, 34);
            this.Server_add.Multiline = true;
            this.Server_add.Name = "Server_add";
            this.Server_add.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Server_add.Size = new System.Drawing.Size(541, 95);
            this.Server_add.TabIndex = 15;
            // 
            // DLCinfo_gameinfo
            // 
            this.DLCinfo_gameinfo.Location = new System.Drawing.Point(432, 18);
            this.DLCinfo_gameinfo.Name = "DLCinfo_gameinfo";
            this.DLCinfo_gameinfo.Size = new System.Drawing.Size(139, 23);
            this.DLCinfo_gameinfo.TabIndex = 6;
            this.DLCinfo_gameinfo.Text = "Get DLC info from GitHub";
            this.DLCinfo_gameinfo.UseVisualStyleBackColor = true;
            this.DLCinfo_gameinfo.Click += new System.EventHandler(this.DLCinfo_gameinfo_Click);
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
            this.ip_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ip_textBox_KeyDown);
            // 
            // GetStats
            // 
            this.GetStats.Location = new System.Drawing.Point(432, 18);
            this.GetStats.Name = "GetStats";
            this.GetStats.Size = new System.Drawing.Size(139, 23);
            this.GetStats.TabIndex = 11;
            this.GetStats.Text = "Get Stats";
            this.GetStats.UseVisualStyleBackColor = true;
            this.GetStats.Click += new System.EventHandler(this.GetStats_Click);
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
            this.Force_tab.ResumeLayout(false);
            this.Force_tab.PerformLayout();
            this.Apppaths_tab.ResumeLayout(false);
            this.Apppaths_tab.PerformLayout();
            this.Stats_tab.ResumeLayout(false);
            this.Stats_tab.PerformLayout();
            this.broadcast_tab.ResumeLayout(false);
            this.broadcast_tab.PerformLayout();
            this.DLC_tab.ResumeLayout(false);
            this.DLC_tab.PerformLayout();
            this.game_setting_tab.ResumeLayout(false);
            this.game_setting_tab.PerformLayout();
            this.game_setting_tab_ctrl.ResumeLayout(false);
            this.ServerBrowser.ResumeLayout(false);
            this.ServerBrowser.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TabPage Force_tab;
        private System.Windows.Forms.TextBox force_steamidpoigri_add;
        private System.Windows.Forms.TextBox force_listen_port_add;
        private System.Windows.Forms.TextBox force_langugae_add;
        private System.Windows.Forms.TextBox force_account_name_add;
        private System.Windows.Forms.TextBox local_save_edit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage Apppaths_tab;
        private System.Windows.Forms.Label Apppt_desc;
        private System.Windows.Forms.TextBox Apppt_add;
        private System.Windows.Forms.TabPage Stats_tab;
        private System.Windows.Forms.Label stat_desc;
        private System.Windows.Forms.TextBox stat_add;
        private System.Windows.Forms.TabPage broadcast_tab;
        private System.Windows.Forms.Button DLLfold;
        private System.Windows.Forms.Button Mods;
        private System.Windows.Forms.Button button_clear_env_var;
        private System.Windows.Forms.Button button_remove_env_var;
        private System.Windows.Forms.Button button_add_env_var;
        private System.Windows.Forms.Label label9;
        private CueTextBox textBox_env_var_value;
        private CueTextBox textBox_env_var_key;
        private CueTextBox ip_textBox;
        private System.Windows.Forms.ListBox listBox_env_var;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button clear_broadcast_button;
        private System.Windows.Forms.Button remove_broadcast_button;
        private System.Windows.Forms.Button add_broadcast_button;
        private System.Windows.Forms.ListBox ip_listBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage DLC_tab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label DLC_desc;
        private System.Windows.Forms.TextBox DLC_add;
        private System.Windows.Forms.TabPage game_setting_tab;
        private System.Windows.Forms.TextBox clan_tag_add;
        private System.Windows.Forms.TextBox game_appid_edit;
        private System.Windows.Forms.TextBox game_folder_edit;
        private System.Windows.Forms.TextBox game_parameters_edit;
        private System.Windows.Forms.TextBox game_exe_edit;
        private System.Windows.Forms.TextBox game_name_edit;
        private System.Windows.Forms.Label Clantag;
        private System.Windows.Forms.CheckBox checkBox_EnableHTTP;
        private System.Windows.Forms.Button getgamenameBUT;
        private System.Windows.Forms.CheckBox checkbox_offline;
        private System.Windows.Forms.CheckBox checkBox_DisableNetworking;
        private System.Windows.Forms.CheckBox checkBox_DisableLANOnly;
        private System.Windows.Forms.CheckBox checkBox_disableOverlay;
        private System.Windows.Forms.Button browse_start_folder;
        private System.Windows.Forms.Button browse_game_exe;
        private System.Windows.Forms.CheckBox x64_checkbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl game_setting_tab_ctrl;
        private System.Windows.Forms.CheckBox checkBox_DisableAchNotif;
        private System.Windows.Forms.CheckBox checkBox_DisableSQuery;
        private System.Windows.Forms.CheckBox checkBox_DisableAvatar;
        private System.Windows.Forms.TextBox depots_add;
        private System.Windows.Forms.Label depots_desc;
        private System.Windows.Forms.TextBox sg_add;
        private System.Windows.Forms.Label sg_desc;
        private System.Windows.Forms.TabPage ServerBrowser;
        private System.Windows.Forms.TextBox HisServ_add;
        private System.Windows.Forms.Label History_label;
        private System.Windows.Forms.TextBox FavServ_add;
        private System.Windows.Forms.Label serfav_label;
        private System.Windows.Forms.Label serbrow_label;
        private System.Windows.Forms.TextBox Server_add;
        private System.Windows.Forms.Button DLCinfo_gameinfo;
        private System.Windows.Forms.Button GetStats;
    }
}