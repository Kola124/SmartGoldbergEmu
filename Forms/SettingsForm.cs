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
using System.Windows.Forms;

namespace SmartGoldbergEmu
{
    public partial class SettingsForm : Form
    {
        static public readonly List<string> languages = new List<string>
        {
            "arabic",
            "bulgarian",
            "schinese",
            "tchinese",
            "czech",
            "danish",
            "dutch",
            "english",
            "finnish",
            "french",
            "german",
            "greek",
            "hungarian",
            "italian",
            "japanese",
            "koreana",
            "norwegian",
            "polish",
            "portuguese",
            "brazilian",
            "romanian",
            "russian",
            "spanish",
            "latam",
            "swedish",
            "thai",
            "turkish",
            "ukrainian",
            "vietnamese"
        };

        private EmuConfig _config = new EmuConfig();

        public EmuConfig config
        {
            set
            {
                _config.language = value.language;
                _config.port = value.port;
                _config.steamid = value.steamid;
                _config.username = value.username;
                _config.webapi_key = value.webapi_key;

                webapi_key_edit.Text = _config.webapi_key;
                username_edit.Text   = _config.username;
                port_edit.Text       = _config.port.ToString();
                steam_id_edit.Text   = _config.steamid;

                bool found_prefered_lang = false;

                foreach (string lang in languages)
                {
                    language_combo.Items.Add(lang);
                    if (!found_prefered_lang)
                    {
                        if (lang.Equals(_config.language))
                        {
                            language_combo.SelectedItem = lang;
                            found_prefered_lang = true;
                        }
                        else if (lang.Equals("english"))
                        {
                            language_combo.SelectedItem = lang;
                        }
                    }
                }
            }

            get
            {
                return _config;
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if( check_settings() )
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool check_settings()
        {
            try
            {
                config.port = Convert.ToUInt16(port_edit.Text);
            }
            catch
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            config.steamid = steam_id_edit.Text;
            config.username = username_edit.Text;
            config.webapi_key = webapi_key_edit.Text;
            config.language = language_combo.SelectedItem.ToString();

            if (config.webapi_key.Length != 0 && config.webapi_key.Length != 32 )
            {
                MessageBox.Show("The webapi key consists of 32 alphanum char in upper case.\n\nMore infos at https://steamcommunity.com/dev/apikey", "Webapi Key invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(config.port != 0 && config.port < 1024 )
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
