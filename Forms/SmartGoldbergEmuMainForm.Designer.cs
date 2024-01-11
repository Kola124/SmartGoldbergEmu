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
using System.Windows.Forms;

namespace SmartGoldbergEmu
{
    partial class SmartGoldbergEmuMainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartGoldbergEmuMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.app_list_view = new System.Windows.Forms.ListView();
            this.capp_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.generateAchievementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameEmuFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkmode = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.capp_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(371, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.editGameToolStripMenuItem,
            this.deleteGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addGameToolStripMenuItem.Text = "Add Game";
            this.addGameToolStripMenuItem.Click += new System.EventHandler(this.AddGameToolStripMenuItem_Click);
            // 
            // editGameToolStripMenuItem
            // 
            this.editGameToolStripMenuItem.Name = "editGameToolStripMenuItem";
            this.editGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.editGameToolStripMenuItem.Text = "Edit Game";
            this.editGameToolStripMenuItem.Click += new System.EventHandler(this.EditGameToolStripMenuItem_Click);
            // 
            // deleteGameToolStripMenuItem
            // 
            this.deleteGameToolStripMenuItem.Name = "deleteGameToolStripMenuItem";
            this.deleteGameToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteGameToolStripMenuItem.Text = "Delete Game";
            this.deleteGameToolStripMenuItem.Click += new System.EventHandler(this.DeleteGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // app_list_view
            // 
            this.app_list_view.AllowDrop = true;
            this.app_list_view.HideSelection = false;
            this.app_list_view.Location = new System.Drawing.Point(0, 27);
            this.app_list_view.Name = "app_list_view";
            this.app_list_view.Size = new System.Drawing.Size(371, 270);
            this.app_list_view.TabIndex = 1;
            this.app_list_view.UseCompatibleStateImageBehavior = false;
            this.app_list_view.DragDrop += new System.Windows.Forms.DragEventHandler(this.App_list_view_DragDrop);
            this.app_list_view.DragEnter += new System.Windows.Forms.DragEventHandler(this.App_list_view_DragEnter);
            this.app_list_view.DoubleClick += new System.EventHandler(this.App_list_view_MouseDoubleClick);
            this.app_list_view.KeyUp += new System.Windows.Forms.KeyEventHandler(this.App_list_view_KeyUp);
            this.app_list_view.MouseClick += new System.Windows.Forms.MouseEventHandler(this.App_list_view_Click);
            // 
            // capp_contextMenuStrip
            // 
            this.capp_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateAchievementsToolStripMenuItem,
            this.generateItemsToolStripMenuItem,
            this.toolStripSeparator2,
            this.createShortcutToolStripMenuItem,
            this.openGameEmuFolderToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeToolStripMenuItem});
            this.capp_contextMenuStrip.Name = "capp_contextMenuStrip";
            this.capp_contextMenuStrip.Size = new System.Drawing.Size(201, 148);
            // 
            // generateAchievementsToolStripMenuItem
            // 
            this.generateAchievementsToolStripMenuItem.Name = "generateAchievementsToolStripMenuItem";
            this.generateAchievementsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.generateAchievementsToolStripMenuItem.Text = "Generate Achievements";
            this.generateAchievementsToolStripMenuItem.Click += new System.EventHandler(this.GenerateAchievementsToolStripMenuItem_Click);
            // 
            // generateItemsToolStripMenuItem
            // 
            this.generateItemsToolStripMenuItem.Name = "generateItemsToolStripMenuItem";
            this.generateItemsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.generateItemsToolStripMenuItem.Text = "Generate Items";
            this.generateItemsToolStripMenuItem.Click += new System.EventHandler(this.GenerateItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // createShortcutToolStripMenuItem
            // 
            this.createShortcutToolStripMenuItem.Name = "createShortcutToolStripMenuItem";
            this.createShortcutToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createShortcutToolStripMenuItem.Text = "Create Shortcut";
            this.createShortcutToolStripMenuItem.Click += new System.EventHandler(this.CreateShortcutToolStripMenuItem_Click);
            // 
            // openGameEmuFolderToolStripMenuItem
            // 
            this.openGameEmuFolderToolStripMenuItem.Name = "openGameEmuFolderToolStripMenuItem";
            this.openGameEmuFolderToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.openGameEmuFolderToolStripMenuItem.Text = "Open Game Emu Folder";
            this.openGameEmuFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenGameEmuFolderToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // darkmode
            // 
            this.darkmode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.darkmode.Location = new System.Drawing.Point(257, 1);
            this.darkmode.Name = "darkmode";
            this.darkmode.Size = new System.Drawing.Size(102, 23);
            this.darkmode.TabIndex = 2;
            this.darkmode.Text = "Dark Mode";
            this.darkmode.UseVisualStyleBackColor = true;
            this.darkmode.Click += new System.EventHandler(this.darkmode_Click);
            // 
            // SmartGoldbergEmuMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 297);
            this.Controls.Add(this.darkmode);
            this.Controls.Add(this.app_list_view);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SmartGoldbergEmuMainForm";
            this.Text = "SmartGoldbergEmu Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Zatvaranje);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SmartGoldbergEmuMainForm_FormClosed);
            this.Load += new System.EventHandler(this.Otvaranje);
            this.SizeChanged += new System.EventHandler(this.SmartGoldbergEmuMainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.capp_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ListView app_list_view;
        private System.Windows.Forms.ContextMenuStrip capp_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem generateAchievementsToolStripMenuItem;
        private ToolStripMenuItem generateItemsToolStripMenuItem;
        private ToolStripMenuItem openGameEmuFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem createShortcutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Button darkmode;
    }
}

