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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

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
            "vietnamese",
            "croatian"
        };

        private EmuConfig _config = new EmuConfig();

        public EmuConfig Config
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
            Ucitavanje();
        }

        public void Ucitavanje()
        {
            Image img=null;
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
            if (File.Exists(Path.Combine(save_folder, "account_avatar.png")))
            {
                using (var bmpTemp = new Bitmap(Path.Combine(save_folder, "account_avatar.png")))
                {
                    img = new Bitmap(bmpTemp);
                }
            }
            if (File.Exists(Path.Combine(save_folder, "account_avatar.jpg")))
            {
                using (var bmpTemp = new Bitmap(Path.Combine(save_folder, "account_avatar.jpg")))
                {
                    img = new Bitmap(bmpTemp);
                }
            };
            avatar.Image = img;

            if (File.Exists(Path.Combine(save_folder, "overlay_appearance.txt")))
            {
                using (StreamReader streamReader = new StreamReader(Path.Combine(save_folder, "overlay_appearance.txt")))
                {
                    string line;
                    string prosliline = "a";
                    double result = 0;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        prosliline = line;
                        if (prosliline.Contains("Font_Size"))
                        {
                            //FontsizeText.Text = prosliline;
                            prosliline = prosliline.Replace("Font_Size ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            FontsizeText.Text = result.ToString().Replace(",", ".");
                        }


                        if (prosliline.Contains("Icon_Size"))
                        {
                            prosliline = prosliline.Replace("Icon_Size ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            ImgSizeText.Text = result.ToString().Replace(",", ".");
                            //ImgSizeText.Text = prosliline;
                        }


                        if (prosliline.Contains("Notification_R"))
                        {
                            prosliline = prosliline.Replace("Notification_R ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            NotifColourText.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_G"))
                        {
                            prosliline = prosliline.Replace("Notification_G ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            NotifColourText.Text = NotifColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_B"))
                        {
                            prosliline = prosliline.Replace("Notification_B ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            NotifColourText.Text = NotifColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Notification_A"))
                        {
                            prosliline = prosliline.Replace("Notification_A ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 100;
                            NotifColourText.Text = NotifColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }



                        if (prosliline.Contains("Background_R"))
                        {
                            prosliline = prosliline.Replace("Background_R ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            BackColourText.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_G"))
                        {
                            prosliline = prosliline.Replace("Background_G ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            BackColourText.Text = BackColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_B"))
                        {
                            prosliline = prosliline.Replace("Background_B ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            BackColourText.Text = BackColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Background_A"))
                        {
                            prosliline = prosliline.Replace("Background_A ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 100;
                            BackColourText.Text = BackColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }



                        if (prosliline.Contains("Element_R"))
                        {
                            prosliline = prosliline.Replace("Element_R ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementColourText.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_G"))
                        {
                            prosliline = prosliline.Replace("Element_G ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementColourText.Text = ElementColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_B"))
                        {
                            prosliline = prosliline.Replace("Element_B ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementColourText.Text = ElementColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("Element_A"))
                        {
                            prosliline = prosliline.Replace("Element_A ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 100;
                            ElementColourText.Text = ElementColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }


                        if (prosliline.Contains("ElementHovered_R"))
                        {
                            prosliline = prosliline.Replace("ElementHovered_R ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementHovColourText.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_G"))
                        {
                            prosliline = prosliline.Replace("ElementHovered_G ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementHovColourText.Text = ElementHovColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_B"))
                        {
                            prosliline = prosliline.Replace("ElementHovered_B ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            ElementHovColourText.Text = ElementHovColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementHovered_A"))
                        {
                            prosliline = prosliline.Replace("ElementHovered_A ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 100;
                            ElementHovColourText.Text = ElementHovColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }


                        if (prosliline.Contains("ElementActive_R"))
                        {
                            prosliline = prosliline.Replace("ElementActive_R ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            EleActColourText.Text = result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_G"))
                        {
                            prosliline = prosliline.Replace("ElementActive_G ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            EleActColourText.Text = EleActColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_B"))
                        {
                            prosliline = prosliline.Replace("ElementActive_B ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 255;
                            result = Math.Round(result);
                            EleActColourText.Text = EleActColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                        if (prosliline.Contains("ElementActive_A"))
                        {
                            prosliline = prosliline.Replace("ElementActive_A ", "");
                            double.TryParse(prosliline, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out result);
                            result = result * 100;
                            EleActColourText.Text = EleActColourText.Text + ", " + result.ToString().Replace(",", ".");
                        }
                            
                    }
                    streamReader.Close();
                }
            }
        }

        public void Spremanje()
        {
            double R,G,B,A = 0;
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
            if (!string.IsNullOrWhiteSpace(NotifColourText.Text) | !string.IsNullOrWhiteSpace(BackColourText.Text) | !string.IsNullOrWhiteSpace(ElementColourText.Text) | !string.IsNullOrWhiteSpace(ElementHovColourText.Text) | !string.IsNullOrWhiteSpace(EleActColourText.Text) | !string.IsNullOrWhiteSpace(FontsizeText.Text) | !string.IsNullOrWhiteSpace(ImgSizeText.Text))
            {
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "overlay_appearance.txt"), FileMode.Create), Encoding.ASCII))
                {
                    if (!string.IsNullOrWhiteSpace(FontsizeText.Text))
                    {
                        streamWriter.Write("Font_Size "+FontsizeText.Text+".0"+"\n");
                    }
                    if (!string.IsNullOrWhiteSpace(ImgSizeText.Text))
                    {
                        streamWriter.Write("Icon_Size "+ImgSizeText.Text + ".0"+"\n");
                    }
                    if (!string.IsNullOrWhiteSpace(NotifColourText.Text))
                    {
                        string lajna = NotifColourText.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        
                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);


                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);
                        A = A / 100;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("Notification_R " + R1 + "\n" + "Notification_G " + G1 + "\n" + "Notification_B " + B1 + "\n" + "Notification_A " + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(BackColourText.Text))
                    {
                        string lajna = BackColourText.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);
                        A = A / 100;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("Background_R " + R1 + "\n" + "Background_G " + G1 + "\n" + "Background_B " + B1 + "\n" + "Background_A " + A1 + "\n");

                    }
                    if (!string.IsNullOrWhiteSpace(ElementColourText.Text))
                    {
                        string lajna = ElementColourText.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);
                        A = A / 100;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("Element_R " + R1 + "\n" + "Element_G " + G1 + "\n" + "Element_B " + B1 + "\n" + "Element_A " + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(ElementHovColourText.Text))
                    {
                        string lajna = ElementHovColourText.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);
                        A = A / 100;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("ElementHovered_R " + R1 + "\n" + "ElementHovered_G " + G1 + "\n" + "ElementHovered_B " + B1 + "\n" + "ElementHovered_A " + A1 + "\n");
                    }
                    if (!string.IsNullOrWhiteSpace(EleActColourText.Text))
                    {
                        string lajna = EleActColourText.Text.Replace(" ", "");
                        string[] clanovi = lajna.Split(',');

                        double.TryParse(clanovi[0], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out R);
                        double.TryParse(clanovi[1], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out G);
                        double.TryParse(clanovi[2], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out B);
                        double.TryParse(clanovi[3], NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out A);

                        if (R > 255) R = 255;
                        if (G > 255) G = 255;
                        if (B > 255) B = 255;
                        if (A > 100) A = 100;

                        R = Math.Round(R / 255, 2);
                        G = Math.Round(G / 255, 2);
                        B = Math.Round(B / 255, 2);
                        A = A / 100;

                        string R1 = R.ToString().Replace(",", ".");
                        string G1 = G.ToString().Replace(",", ".");
                        string B1 = B.ToString().Replace(",", ".");
                        string A1 = A.ToString().Replace(",", ".");

                        streamWriter.Write("ElementActive_R " + R1 + "\n" + "ElementActive_G " + G1 + "\n" + "ElementActive_B " + B1 + "\n" + "ElementActive_A " + A1 + "\n");

                    }
                    streamWriter.Close();
                }
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            Spremanje();
            if( Check_settings() )
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

        private bool Check_settings()
        {
            try
            {
                Config.port = Convert.ToUInt16(port_edit.Text);
            }
            catch
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Config.steamid = steam_id_edit.Text;
            Config.username = username_edit.Text;
            Config.webapi_key = webapi_key_edit.Text;
            Config.language = language_combo.SelectedItem.ToString();

            if (Config.webapi_key.Length != 0 && Config.webapi_key.Length != 32 )
            {
                MessageBox.Show("The webapi key consists of 32 alphanum char in upper case.\n\nMore infos at https://steamcommunity.com/dev/apikey", "Webapi Key invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(Config.port != 0 && Config.port < 1024 )
            {
                MessageBox.Show("The port must be a number >1024", "Port invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Avatarchng_Click(object sender, EventArgs e)
        {
            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
            OpenFileDialog dijalog = new OpenFileDialog
            {
                Filter = "PNG|*.png|JPG|*.jpg|All files|*.*",
                FilterIndex = 3
            };
            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(dijalog.FileName, Path.Combine(save_folder, "account_avatar.png"), true);
                }
                catch (IOException)
                {
                    // File in use and can't be deleted; no permission etc.
                }
            }
            Ucitavanje();
        }
    }
}
