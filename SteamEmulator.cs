using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;

using Microsoft.Win32;

using OSUtility;

namespace SmartGoldbergEmu
{
    static class SteamEmulator
    {
        public static EmuConfig Config { get; set; } = new EmuConfig();
        public static List<GameConfig> Apps { get; set; } = new List<GameConfig>();
        private static List<Process> emuGamesProcess = new List<Process>();
        private static int? steamPid = 0;
        private static string steamClientDll = "";
        private static string steamClientDll64 = "";

        public static void Initialize()
        {
            LoadSave();

            string save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(save_folder, "account_name.txt"), FileMode.Open), Encoding.ASCII))
                {
                    Config.username = streamReader.ReadLine();
                }
            }
            catch { }
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(save_folder, "language.txt"), FileMode.Open), Encoding.ASCII))
                {
                    Config.language = streamReader.ReadLine();
                }
            }
            catch { }
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(save_folder, "listen_port.txt"), FileMode.Open), Encoding.ASCII))
                {
                    Config.port = ushort.Parse(streamReader.ReadLine());
                }
            }
            catch { }
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(Path.Combine(save_folder, "user_steam_id.txt"), FileMode.Open), Encoding.ASCII))
                {
                    Config.steamid = streamReader.ReadLine();
                }
            }
            catch { }
        }
        
        private static RegistryKey CreateOrOpenKey(string keyPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true);
            if (key == null)
            {
                string[] split = keyPath.Split('\\');
                key = CreateOrOpenKey(string.Join("\\", split.Take(split.Length - 1)));
                key.CreateSubKey(split.Last());
                key.Close();
            }
            return Registry.CurrentUser.OpenSubKey(keyPath, true);
        }

        public static bool SetupEmu(GameConfig app)
        {
            string game_emu_folder = app.GetGameEmuFolder();
            string save_folder;

            if (!app.LocalSave.Equals(""))
            {
                save_folder = Path.Combine(game_emu_folder, app.LocalSave, "settings");
            }
            else
            {
                save_folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Goldberg SteamEmu Saves", "settings");
            }
            try
            {
                if (!Directory.Exists(save_folder))
                    Directory.CreateDirectory(save_folder);

                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "account_name.txt"), FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.Write(Config.username);
                }
                using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "language.txt"), FileMode.Create), Encoding.ASCII))
                {
                    streamWriter.Write(Config.language);
                }
                if (Config.port != 0)
                {
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "listen_port.txt"), FileMode.Create), Encoding.ASCII))
                    {
                        streamWriter.Write(Config.port);
                    }
                }
                if (!Config.steamid.Equals(""))
                {
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(save_folder, "user_steam_id.txt"), FileMode.Create), Encoding.ASCII))
                    {
                        streamWriter.Write(Config.steamid);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }

        public static void LoadSave()
        {
            try
            {
                SavedConf save = new SavedConf();
                var xmlserializer = new XmlSerializer(save.GetType());

                using (FileStream file = File.Open("SmartGoldbergEmu.cfg", FileMode.Open))
                {
                    save = (SavedConf)xmlserializer.Deserialize(file);

                    Apps = save.apps;
                    Config.webapi_key = save.webapi_key;
                }
            }
            catch (Exception)
            {
            }
        }

        public static void Save()
        {
            try
            {
                SavedConf save = new SavedConf();
                var xmlserializer = new XmlSerializer(save.GetType());
                var stringWriter = new StringWriter();

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = ("  "),
                    OmitXmlDeclaration = true
                };

                save.apps = Apps;
                save.webapi_key = Config.webapi_key;

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlserializer.Serialize(writer, save);
                    using (FileStream file = File.Open("SmartGoldbergEmu.cfg", FileMode.Create))
                    {
                        byte[] datas = new UTF8Encoding(true).GetBytes(stringWriter.ToString());
                        file.Write(datas, 0, datas.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static void AddGame(GameConfig app)
        {
            Apps.Add(app);
            Save();
        }

        public static void SetGame(int index, GameConfig app)
        {
            Apps[index] = app;
            Save();
        }

        public static void RemoveGame(GameConfig app)
        {
            Apps.Remove(app);
            Save();
        }

        private static void Create_steam_settings_folder(GameConfig app)
        {
            string game_emu_folder = app.GetGameEmuFolder();
            if (!Directory.Exists(Path.Combine(game_emu_folder, "steam_settings") + Path.DirectorySeparatorChar))
                Directory.CreateDirectory(Path.Combine(game_emu_folder, "steam_settings") + Path.DirectorySeparatorChar);
            if (OSDetector.IsLinux())
            {
                if (!Directory.Exists(Path.Combine(game_emu_folder, ".steam") + Path.DirectorySeparatorChar))
                {
                    using (var p = Process.Start(new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "ln",
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = "-s . " + Path.Combine(game_emu_folder, ".steam")
                    }))
                    {
                        p.WaitForExit();
                    }
                }
                if (!Directory.Exists(Path.Combine(game_emu_folder, ".steam", (app.UseX64 ? "sdk64" : "sdk32"))))
                {
                    using (var p = Process.Start(new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "ln",
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = "-s . " + Path.Combine(game_emu_folder, ".steam", (app.UseX64 ? "sdk64" : "sdk32"))
                    }))
                    {
                        p.WaitForExit();
                    }
                }
            }
        }

        public static void ShowGameEmuFolder(GameConfig app)
        {
            string emu_folder = app.GetGameEmuFolder();

            SteamEmulator.Create_steam_settings_folder(app);

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

        private static bool SetupSteamEmu(GameConfig app)
        {
            try
            {
                if (OSDetector.IsWindows())
                {
                    RegistryKey key = CreateOrOpenKey(@"Software\Valve\Steam\ActiveProcess");

                    if (key == null)
                    {
                        MessageBox.Show(@"Cannot setup registry keys in HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (steamPid == 0)
                    {
                        steamPid = (int?)key.GetValue("pid") ?? (int?)0;
                        steamClientDll = key.GetValue("SteamClientDll")?.ToString() ?? string.Empty;
                        steamClientDll64 = key.GetValue("SteamClientDll64")?.ToString() ?? string.Empty;
                    }

                    key.SetValue("pid", Process.GetCurrentProcess().Id, RegistryValueKind.DWord);
                    key.SetValue("SteamClientDll" + (app.UseX64 ? "64" : ""), Path.Combine(app.GetGameEmuFolder(), OSFuncs.GetSteamAPIName(app.UseX64)), RegistryValueKind.String);

                    key.Close();
                }
                else if (OSDetector.IsLinux())
                {
                    Environment.SetEnvironmentVariable("HOME", app.GetGameEmuFolder());
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(app.GetGameEmuFolder(), "steam.pid"), FileMode.Create), Encoding.ASCII))
                    {
                        streamWriter.Write(Process.GetCurrentProcess().Id);
                    }
                    // On linux, steam_api.so checks for steamclient.so in $HOME/.steam/sdk(32|64)
                    // So if we set the HOME env variable before starting the game, it should use our steamclient.so
                }
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        private static bool SetupGameEmu(GameConfig app)
        {
            string os_folder = OSFuncs.GetEmuApiFolder(app.UseX64);

            if (os_folder == string.Empty)
            {
                return false;
            }

            string emu_path = os_folder + OSFuncs.GetSteamAPIName(app.UseX64);
            if (!File.Exists(emu_path))
            {
                MessageBox.Show("Cannot find SmartGoldbergEmu Launcher: " + emu_path);
                return false;
            }

            try
            {
                string game_emu_folder = app.GetGameEmuFolder();

                Create_steam_settings_folder(app);

                if (app.LocalSave.Equals(""))
                {
                    if (File.Exists(Path.Combine(game_emu_folder, "local_save.txt")))
                        File.Delete(Path.Combine(game_emu_folder, "local_save.txt"));
                    if (File.Exists(Path.Combine(game_emu_folder, "steam_settings", "disable_overlay_warning.txt")))
                        File.Delete(Path.Combine(game_emu_folder, "steam_settings", "disable_overlay_warning.txt"));
                }
                else
                {
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "local_save.txt"), FileMode.Create), Encoding.ASCII))
                    {
                        streamWriter.Write(app.LocalSave);
                        streamWriter.Close();
                    }
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "disable_overlay_warning.txt"), FileMode.Create), Encoding.ASCII))
                    {
                        streamWriter.Close();
                    }
                }

                if (app.CustomBroadcasts.Count > 0)
                {
                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(Path.Combine(game_emu_folder, "steam_settings", "custom_broadcasts.txt"), FileMode.Create), Encoding.ASCII))
                    {
                        foreach (string ip in app.CustomBroadcasts) streamWriter.WriteLine(ip);
                        streamWriter.Close();
                    }
                }
                File.Copy(emu_path, Path.Combine(game_emu_folder, OSFuncs.GetSteamAPIName(app.UseX64)), true);
            }
            catch (Exception)
            {
                return false;
            }

            return SetupSteamEmu(app);
        }

        public static void GenerateGameAchievements(GameConfig app)
        {
            if (Config.webapi_key.Equals(""))
            {
                MessageBox.Show("Can't generate achievements definition file, webapi key is missing.\n\nSee https://steamcommunity.com/dev/apikey to get yours.",
                    "Webapi Key error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string game_emu_folder = app.GetGameEmuFolder();
            string achievements_file = Path.Combine(game_emu_folder, "steam_settings", "achievements.json");

            Create_steam_settings_folder(app);

            string url = "http://api.steampowered.com/ISteamUserStats/GetSchemaForGame/v2/?l=" + Config.language + "&key=";
            url += Config.webapi_key + "&appid=" + app.AppId.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("Failed to get achievements definition (wrong webapi key ?)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Stream sresult = response.GetResponseStream();

                    StreamReader streamReader = new StreamReader(sresult);

                    string buffer = streamReader.ReadToEnd();

                    CSteamGameSchema schema = JsonConvert.DeserializeObject<CSteamGameSchema>(buffer);

                    string img_folder = Path.Combine(app.GetGameEmuFolder(), "steam_settings", "achievement_images");

                    foreach (CAchievement ach in schema.game.availableGameStats.achievements)
                    {
                        Directory.CreateDirectory(img_folder);
                        // download icon
                        using(WebClient wc = new WebClient())
                        {
                            wc.DownloadFile(ach.icon, Path.Combine(img_folder, ach.name + ".jpg"));
                        }
                        ach.icon = Path.Combine(ach.name + ".jpg");
                        // download icon gray
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile(ach.icongray, Path.Combine(img_folder, ach.name + "_gray.jpg"));
                        }
                        ach.icongray = Path.Combine(ach.name + "_gray.jpg");
                        ach.icon_gray = ach.icongray;
                    }

                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(achievements_file, FileMode.Create), Encoding.UTF8))
                    {
                        buffer = JsonConvert.SerializeObject(schema.game.availableGameStats.achievements, Newtonsoft.Json.Formatting.Indented);
                        streamWriter.Write(buffer);
                    }
                }
                MessageBox.Show("Achievements definition file created", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error, is appid wrong ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GenerateGameItems(GameConfig app)
        {
            if (Config.webapi_key.Equals(""))
            {
                MessageBox.Show("Can't generate achievements definition file, webapi key is missing.\n\nSee https://steamcommunity.com/dev/apikey to get yours.",
                    "Webapi Key error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string game_emu_folder = app.GetGameEmuFolder();
            string items_file = Path.Combine(game_emu_folder, "steam_settings", "items.json");

            Create_steam_settings_folder(app);

            string buffer;
            string url = "https://api.steampowered.com/IInventoryService/GetItemDefMeta/v1?key=";
            url += Config.webapi_key + "&appid=" + app.AppId.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("Failed to get items definition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Stream sresult = response.GetResponseStream();
                using (StreamReader streamReader = new StreamReader(sresult))
                {
                    buffer = streamReader.ReadToEnd();
                }
            }

            CSteamMetaResponse metaResponse;
            try
            {
                metaResponse = JsonConvert.DeserializeObject<CSteamMetaResponse>(buffer);
                if (metaResponse.response.digest == null ||
                metaResponse.response.digest.Equals(""))
                {
                    MessageBox.Show("No items for this game", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No items for this game: Invalid meta answer.", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            url = "https://api.steampowered.com/IGameInventory/GetItemDefArchive/v0001?appid=";
            url += app.AppId + "&digest=" + metaResponse.response.digest;

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Accept-encoding:gzip, deflate, br");
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream sresult = response.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(sresult))
                    {
                        buffer = streamReader.ReadToEnd();
                    }

                    JObject new_json = new JObject();
                    try
                    {
                        JArray json = JArray.Parse(buffer);
                        foreach (JObject item in json.Cast<JObject>())
                        {
                            string itemid = item["itemdefid"].Value<string>();
                            new_json.Add(itemid, new JObject());
                            foreach (KeyValuePair<string, JToken> attr in item)
                            {
                                switch (attr.Value.Type)
                                {
                                    case JTokenType.Boolean:
                                        new_json[itemid][attr.Key] = attr.Value.Value<bool>().ToString();
                                        break;

                                    case JTokenType.Float:
                                        new_json[itemid][attr.Key] = attr.Value.Value<float>().ToString();
                                        break;

                                    case JTokenType.Integer:
                                        new_json[itemid][attr.Key] = attr.Value.Value<long>().ToString();
                                        break;

                                    default:
                                        new_json[itemid][attr.Key] = attr.Value;
                                        break;
                                }
                            }
                        }

                        using (StreamWriter streamWriter = new StreamWriter(new FileStream(items_file, FileMode.Create), Encoding.UTF8))
                        {
                            buffer = JsonConvert.SerializeObject(new_json, Newtonsoft.Json.Formatting.Indented);
                            streamWriter.Write(buffer);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("No items for this game: Invalid items answer.", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            MessageBox.Show("Items definition file created", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SteamEmulator.Save();
        }

        /// <summary>
        /// Setups the Emu and starts the game
        /// </summary>
        /// <param name="app">The emu configuration for the game</param>
        public static void StartGame(GameConfig app)
        {
            if (app.AppId == 0)
            {
                MessageBox.Show("You need to set up game app id first. You can find your game app id on steam store url: http://store.steampowered.com/app/<AppId>", "Invalid app id", MessageBoxButtons.OK);
                return;
            }

            if (SetupEmu(app) && SetupGameEmu(app))
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = app.Path,
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = app.Parameters,
                        WorkingDirectory = app.StartFolder
                    };

                    foreach (string var in app.EnvVars)
                    {
                        int pos = var.IndexOf('=');
                        if (pos != -1)
                        {
                            string key = var.Substring(0, pos);
                            string val = var.Substring(pos + 1);
                            psi.EnvironmentVariables.Add(key, val);
                        }
                    }

                    psi.EnvironmentVariables.Add("SteamAppId", app.AppId.ToString());

                    Process p = new Process
                    {
                        EnableRaisingEvents = true,
                        StartInfo = psi
                    };
                    p.Exited += OnProcessExited;
                    emuGamesProcess.Add(p);

                    p.Start();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Cannot launch game: " + e.Message, "Game Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static void OnProcessExited(object sender, EventArgs e)
        {
            Type x = sender.GetType();
            emuGamesProcess.RemoveAll(p => p.HasExited);

            if (emuGamesProcess.Count == 0)
            {
                RestoreSteam();
            }
        }

        public static void CreateShortcut(GameConfig app)
        {
            if(!OSDetector.IsWindows())
            {
                MessageBox.Show("This feature is only available on Windows for the moment", "Unsupported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string launcherPath = Path.GetFullPath(Environment.GetCommandLineArgs()[0]);
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Path.DirectorySeparatorChar;


            SharpShortcut.Shortcut.Create(desktopDir + app.AppName + ".lnk", launcherPath, app.GameGuid.ToString(), 
                Path.GetDirectoryName(launcherPath), "Starts " + app.AppName + " with the steam emulator", 
                string.Empty, app.Path);
        }
        public static void RestoreSteam()
        {
            if (steamPid != 0)
            {
                if (OSDetector.IsWindows())
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam\ActiveProcess", true);

                    if (key == null)
                        return;

                    key.SetValue("pid", steamPid);
                    key.SetValue("SteamClientDll64", steamClientDll64);
                    key.SetValue("SteamClientDll", steamClientDll);
                }
            }
        }
    }
}
