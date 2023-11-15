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
            this.save_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generaltab = new System.Windows.Forms.TabPage();
            this.avatar = new System.Windows.Forms.PictureBox();
            this.avatarchng = new System.Windows.Forms.Button();
            this.language_combo = new System.Windows.Forms.ComboBox();
            this.webapi_key_edit = new System.Windows.Forms.TextBox();
            this.port_edit = new System.Windows.Forms.TextBox();
            this.steam_id_edit = new System.Windows.Forms.TextBox();
            this.username_edit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.appearancetab = new System.Windows.Forms.TabPage();
            this.ImgSizeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.FontsizeText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.EleActColourText = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.ElementHovColourText = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ElementColourText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BackColourText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NotifColourText = new System.Windows.Forms.TextBox();
            this.soundtab = new System.Windows.Forms.TabPage();
            this.delachsoundbutton = new System.Windows.Forms.Button();
            this.delfriendsoundbutton = new System.Windows.Forms.Button();
            this.addachsoundbutton = new System.Windows.Forms.Button();
            this.addfriendsoundbutton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.generaltab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.appearancetab.SuspendLayout();
            this.soundtab.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(385, 178);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 11;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(304, 178);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 12;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generaltab);
            this.tabControl1.Controls.Add(this.appearancetab);
            this.tabControl1.Controls.Add(this.soundtab);
            this.tabControl1.Location = new System.Drawing.Point(13, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 167);
            this.tabControl1.TabIndex = 15;
            // 
            // generaltab
            // 
            this.generaltab.BackColor = System.Drawing.SystemColors.Control;
            this.generaltab.Controls.Add(this.avatar);
            this.generaltab.Controls.Add(this.avatarchng);
            this.generaltab.Controls.Add(this.language_combo);
            this.generaltab.Controls.Add(this.webapi_key_edit);
            this.generaltab.Controls.Add(this.port_edit);
            this.generaltab.Controls.Add(this.steam_id_edit);
            this.generaltab.Controls.Add(this.username_edit);
            this.generaltab.Controls.Add(this.label5);
            this.generaltab.Controls.Add(this.label4);
            this.generaltab.Controls.Add(this.label3);
            this.generaltab.Controls.Add(this.label2);
            this.generaltab.Controls.Add(this.label1);
            this.generaltab.Location = new System.Drawing.Point(4, 22);
            this.generaltab.Name = "generaltab";
            this.generaltab.Padding = new System.Windows.Forms.Padding(3);
            this.generaltab.Size = new System.Drawing.Size(439, 141);
            this.generaltab.TabIndex = 0;
            this.generaltab.Text = "General";
            // 
            // avatar
            // 
            this.avatar.ErrorImage = null;
            this.avatar.ImageLocation = "";
            this.avatar.Location = new System.Drawing.Point(6, 14);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(94, 94);
            this.avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatar.TabIndex = 26;
            this.avatar.TabStop = false;
            // 
            // avatarchng
            // 
            this.avatarchng.Location = new System.Drawing.Point(6, 110);
            this.avatarchng.Name = "avatarchng";
            this.avatarchng.Size = new System.Drawing.Size(94, 24);
            this.avatarchng.TabIndex = 25;
            this.avatarchng.Text = "Change Avatar";
            this.avatarchng.UseVisualStyleBackColor = true;
            // 
            // language_combo
            // 
            this.language_combo.FormattingEnabled = true;
            this.language_combo.Location = new System.Drawing.Point(175, 61);
            this.language_combo.Name = "language_combo";
            this.language_combo.Size = new System.Drawing.Size(245, 21);
            this.language_combo.TabIndex = 24;
            // 
            // webapi_key_edit
            // 
            this.webapi_key_edit.Location = new System.Drawing.Point(175, 114);
            this.webapi_key_edit.MaxLength = 32;
            this.webapi_key_edit.Name = "webapi_key_edit";
            this.webapi_key_edit.Size = new System.Drawing.Size(245, 20);
            this.webapi_key_edit.TabIndex = 23;
            // 
            // port_edit
            // 
            this.port_edit.Location = new System.Drawing.Point(175, 88);
            this.port_edit.MaxLength = 5;
            this.port_edit.Name = "port_edit";
            this.port_edit.Size = new System.Drawing.Size(86, 20);
            this.port_edit.TabIndex = 22;
            // 
            // steam_id_edit
            // 
            this.steam_id_edit.Location = new System.Drawing.Point(175, 35);
            this.steam_id_edit.Name = "steam_id_edit";
            this.steam_id_edit.Size = new System.Drawing.Size(245, 20);
            this.steam_id_edit.TabIndex = 21;
            // 
            // username_edit
            // 
            this.username_edit.Location = new System.Drawing.Point(175, 9);
            this.username_edit.MaxLength = 32;
            this.username_edit.Name = "username_edit";
            this.username_edit.Size = new System.Drawing.Size(245, 20);
            this.username_edit.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "WebAPI Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "SteamID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Username:";
            // 
            // appearancetab
            // 
            this.appearancetab.BackColor = System.Drawing.SystemColors.Control;
            this.appearancetab.Controls.Add(this.ImgSizeText);
            this.appearancetab.Controls.Add(this.label9);
            this.appearancetab.Controls.Add(this.FontsizeText);
            this.appearancetab.Controls.Add(this.label8);
            this.appearancetab.Controls.Add(this.label29);
            this.appearancetab.Controls.Add(this.label30);
            this.appearancetab.Controls.Add(this.EleActColourText);
            this.appearancetab.Controls.Add(this.label24);
            this.appearancetab.Controls.Add(this.label25);
            this.appearancetab.Controls.Add(this.ElementHovColourText);
            this.appearancetab.Controls.Add(this.label19);
            this.appearancetab.Controls.Add(this.label20);
            this.appearancetab.Controls.Add(this.ElementColourText);
            this.appearancetab.Controls.Add(this.label14);
            this.appearancetab.Controls.Add(this.label15);
            this.appearancetab.Controls.Add(this.BackColourText);
            this.appearancetab.Controls.Add(this.label7);
            this.appearancetab.Controls.Add(this.label6);
            this.appearancetab.Controls.Add(this.NotifColourText);
            this.appearancetab.Location = new System.Drawing.Point(4, 22);
            this.appearancetab.Name = "appearancetab";
            this.appearancetab.Padding = new System.Windows.Forms.Padding(3);
            this.appearancetab.Size = new System.Drawing.Size(439, 141);
            this.appearancetab.TabIndex = 1;
            this.appearancetab.Text = "Appearance";
            // 
            // ImgSizeText
            // 
            this.ImgSizeText.Location = new System.Drawing.Point(368, 36);
            this.ImgSizeText.Name = "ImgSizeText";
            this.ImgSizeText.Size = new System.Drawing.Size(38, 20);
            this.ImgSizeText.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Image Size";
            // 
            // FontsizeText
            // 
            this.FontsizeText.Location = new System.Drawing.Point(368, 10);
            this.FontsizeText.Name = "FontsizeText";
            this.FontsizeText.Size = new System.Drawing.Size(38, 20);
            this.FontsizeText.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Font Size";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(123, 117);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(46, 13);
            this.label29.TabIndex = 41;
            this.label29.Text = "R,G,B,A";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 117);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 13);
            this.label30.TabIndex = 40;
            this.label30.Text = "Element Active";
            // 
            // EleActColourText
            // 
            this.EleActColourText.Location = new System.Drawing.Point(175, 114);
            this.EleActColourText.Name = "EleActColourText";
            this.EleActColourText.Size = new System.Drawing.Size(117, 20);
            this.EleActColourText.TabIndex = 36;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(123, 91);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "R,G,B,A";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(16, 91);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 13);
            this.label25.TabIndex = 31;
            this.label25.Text = "Element Hovered";
            // 
            // ElementHovColourText
            // 
            this.ElementHovColourText.Location = new System.Drawing.Point(175, 88);
            this.ElementHovColourText.Name = "ElementHovColourText";
            this.ElementHovColourText.Size = new System.Drawing.Size(117, 20);
            this.ElementHovColourText.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(123, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 23;
            this.label19.Text = "R,G,B,A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 13);
            this.label20.TabIndex = 22;
            this.label20.Text = "Element";
            // 
            // ElementColourText
            // 
            this.ElementColourText.Location = new System.Drawing.Point(175, 62);
            this.ElementColourText.Name = "ElementColourText";
            this.ElementColourText.Size = new System.Drawing.Size(117, 20);
            this.ElementColourText.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(123, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "R,G,B,A";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Background";
            // 
            // BackColourText
            // 
            this.BackColourText.Location = new System.Drawing.Point(175, 36);
            this.BackColourText.Name = "BackColourText";
            this.BackColourText.Size = new System.Drawing.Size(117, 20);
            this.BackColourText.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "R,G,B,A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Notification";
            // 
            // NotifColourText
            // 
            this.NotifColourText.Location = new System.Drawing.Point(175, 10);
            this.NotifColourText.Name = "NotifColourText";
            this.NotifColourText.Size = new System.Drawing.Size(117, 20);
            this.NotifColourText.TabIndex = 0;
            // 
            // soundtab
            // 
            this.soundtab.BackColor = System.Drawing.SystemColors.Control;
            this.soundtab.Controls.Add(this.delachsoundbutton);
            this.soundtab.Controls.Add(this.delfriendsoundbutton);
            this.soundtab.Controls.Add(this.addachsoundbutton);
            this.soundtab.Controls.Add(this.addfriendsoundbutton);
            this.soundtab.Controls.Add(this.label11);
            this.soundtab.Controls.Add(this.label10);
            this.soundtab.Location = new System.Drawing.Point(4, 22);
            this.soundtab.Name = "soundtab";
            this.soundtab.Size = new System.Drawing.Size(439, 141);
            this.soundtab.TabIndex = 2;
            this.soundtab.Text = "Sound";
            // 
            // delachsoundbutton
            // 
            this.delachsoundbutton.Location = new System.Drawing.Point(119, 90);
            this.delachsoundbutton.Name = "delachsoundbutton";
            this.delachsoundbutton.Size = new System.Drawing.Size(94, 29);
            this.delachsoundbutton.TabIndex = 29;
            this.delachsoundbutton.Text = "Delete Sound";
            this.delachsoundbutton.UseVisualStyleBackColor = true;
            this.delachsoundbutton.Click += new System.EventHandler(this.delachsoundbutton_Click);
            // 
            // delfriendsoundbutton
            // 
            this.delfriendsoundbutton.Location = new System.Drawing.Point(119, 29);
            this.delfriendsoundbutton.Name = "delfriendsoundbutton";
            this.delfriendsoundbutton.Size = new System.Drawing.Size(94, 31);
            this.delfriendsoundbutton.TabIndex = 28;
            this.delfriendsoundbutton.Text = "Delete Sound";
            this.delfriendsoundbutton.UseVisualStyleBackColor = true;
            this.delfriendsoundbutton.Click += new System.EventHandler(this.delfriendsoundbutton_Click);
            // 
            // addachsoundbutton
            // 
            this.addachsoundbutton.Location = new System.Drawing.Point(19, 90);
            this.addachsoundbutton.Name = "addachsoundbutton";
            this.addachsoundbutton.Size = new System.Drawing.Size(94, 29);
            this.addachsoundbutton.TabIndex = 27;
            this.addachsoundbutton.Text = "Change Sound";
            this.addachsoundbutton.UseVisualStyleBackColor = true;
            this.addachsoundbutton.Click += new System.EventHandler(this.addachsoundbutton_Click);
            // 
            // addfriendsoundbutton
            // 
            this.addfriendsoundbutton.Location = new System.Drawing.Point(19, 29);
            this.addfriendsoundbutton.Name = "addfriendsoundbutton";
            this.addfriendsoundbutton.Size = new System.Drawing.Size(94, 31);
            this.addfriendsoundbutton.TabIndex = 26;
            this.addfriendsoundbutton.Text = "Change Sound";
            this.addfriendsoundbutton.UseVisualStyleBackColor = true;
            this.addfriendsoundbutton.Click += new System.EventHandler(this.addfriendsoundbutton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Achievement Notification";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Friend Notification";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 205);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.save_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.generaltab.ResumeLayout(false);
            this.generaltab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.appearancetab.ResumeLayout(false);
            this.appearancetab.PerformLayout();
            this.soundtab.ResumeLayout(false);
            this.soundtab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generaltab;
        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Button avatarchng;
        private System.Windows.Forms.ComboBox language_combo;
        private System.Windows.Forms.TextBox webapi_key_edit;
        private System.Windows.Forms.TextBox port_edit;
        private System.Windows.Forms.TextBox steam_id_edit;
        private System.Windows.Forms.TextBox username_edit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage appearancetab;
        private System.Windows.Forms.TextBox NotifColourText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox EleActColourText;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox ElementHovColourText;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox ElementColourText;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox BackColourText;
        private System.Windows.Forms.TextBox ImgSizeText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FontsizeText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage soundtab;
        private System.Windows.Forms.Button delachsoundbutton;
        private System.Windows.Forms.Button delfriendsoundbutton;
        private System.Windows.Forms.Button addachsoundbutton;
        private System.Windows.Forms.Button addfriendsoundbutton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}