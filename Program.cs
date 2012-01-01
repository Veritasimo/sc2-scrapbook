using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace SC2Scrapbook
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{8f294ecd-7a0f-4a71-a76b-e32268fef2cf}");

        internal static Models.Patch ActivePatch { get; set; }
        internal static BuildCollection BuildsDB { get; set; }
        internal static List<Models.Patch> PatchList { get; set; }
        internal static string SCDirectory { get; set; }
        internal static string DataDirectory { get; set; }
        internal static bool Initialized { get; set; }
        internal static Thread _sc2InteractionThread;

        internal static System.Drawing.Rectangle SC2WindowRect;
        internal static double xScale { get; set; }
        internal static double yScale { get; set; }

        internal static frmPlayerInfo PlayerInfoForm {get;set;}
        internal static frmIngameBuildSelection IngameBuildSelectionForm { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string sharecode = null;
            string[] args = Environment.GetCommandLineArgs();

            DataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sc2Path = string.Format("{0}{1}StarCraft II", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.DirectorySeparatorChar);

            if (Directory.Exists(sc2Path))
            {
                SCDirectory = sc2Path;
                DataDirectory = string.Format("{0}{1}Scrapbook", sc2Path, Path.DirectorySeparatorChar);
                Directory.CreateDirectory(DataDirectory);
            }


            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                frmSplash.ShowSplash();

                try
                {
                    if (args.Length < 2)
                    {
                        var key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("sc2bo");
                        key.SetValue("URL Protocol", "");
                        var commandKey = key.CreateSubKey("shell\\open\\command");
                        commandKey.SetValue("", string.Format("\"{0}\" \"%1\"", System.Reflection.Assembly.GetExecutingAssembly().Location));
                        commandKey.Close();
                        key.Close();
                    }
                    else
                    {
                        if (args[1].ToLower().StartsWith("sc2bo://"))
                        {
                            sharecode = args[1].Substring(8);
                        }
                    }
                }
                catch { }

                
                SC2WindowRect = new System.Drawing.Rectangle();

                LoadPatchData();
                LoadConfigurationXML();
                LoadBuildsXML();

                if (Configuration.Instance.UseAdvancedOptions)
                    StartSC2InteractionThread();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain(sharecode));
                mutex.ReleaseMutex();
            }
            else
            {
                if (args.Length < 2)
                {
                    Win32.PostMessage((IntPtr)Win32.HWND_BROADCAST, Win32.WM_SHOWBON, IntPtr.Zero, IntPtr.Zero);
                }
                else
                {
                    if (args[1].ToLower().StartsWith("sc2bo://"))
                    {
                        // Yes, this is bad. But trying to SendMessage a COPYDATASTRUCT is much worse.
                        File.WriteAllText(string.Format("{0}\\{1}.import", DataDirectory, new Random().Next()), args[1].Substring(8));
                        Win32.PostMessage((IntPtr)Win32.HWND_BROADCAST, Win32.WM_BONIMPORT, IntPtr.Zero, IntPtr.Zero);
                    }
                }
            }
        }

        internal static void StartSC2InteractionThread()
        {
            if (_sc2InteractionThread != null)
                KillSC2InteractionThread();

            _sc2InteractionThread = new Thread(new ThreadStart(SC2InteractionThreadWorker));
            _sc2InteractionThread.Start();
        }

        internal static void KillSC2InteractionThread()
        {
            if (_sc2InteractionThread != null)
            {
                _sc2InteractionThread.Abort();
                HideBuildSelection();
                HideOverlay();
                HidePlayerInfo();
            }
        }

        internal static void ShowPlayerInfo(Models.Player player)
        {
            if (frmMain.Instance.InvokeRequired)
            {
                frmMain.Instance.BeginInvoke(new Action<Models.Player>(ShowPlayerInfo), player);
            }
            else
            {
                if (PlayerInfoForm != null)
                    PlayerInfoForm.Dispose();

                PlayerInfoForm = new frmPlayerInfo(player);
                PlayerInfoForm.Show();
            }
        }

        internal static void HidePlayerInfo()
        {
            if (frmMain.Instance.InvokeRequired)
            {
                frmMain.Instance.BeginInvoke(new Action(HidePlayerInfo));
            }
            else
            {
                if (PlayerInfoForm != null)
                {
                    PlayerInfoForm.Animator.Direction = FormAnimator.AnimationDirection.Left;
                    PlayerInfoForm.Close();
                }
            }

        }

        internal static void ShowBuildSelection()
        {
            if (frmMain.Instance.InvokeRequired)
            {
                frmMain.Instance.BeginInvoke(new Action(ShowBuildSelection));
            }
            else
            {
                if (IngameBuildSelectionForm != null)
                    IngameBuildSelectionForm.Dispose();

                IngameBuildSelectionForm = new frmIngameBuildSelection();

#if DEBUG
                IngameBuildSelectionForm.Top = 0;
                IngameBuildSelectionForm.Left = 0;
                
#else
                IngameBuildSelectionForm.Top = SC2WindowRect.Top + (SC2WindowRect.Height - IngameBuildSelectionForm.Height - 20);
                IngameBuildSelectionForm.Left = SC2WindowRect.Left + ((SC2WindowRect.Width / 2) - IngameBuildSelectionForm.Width / 2);
                
#endif
                IngameBuildSelectionForm.Show();
                
            }
        }

        internal static void HideBuildSelection()
        {
            if (frmMain.Instance.InvokeRequired)
            {
                frmMain.Instance.BeginInvoke(new Action(HideBuildSelection));
            }
            else
            {
                if (IngameBuildSelectionForm != null)
                {
                    IngameBuildSelectionForm.Close();
                    IngameBuildSelectionForm = null;
                }
            }

        }

        internal static void HideOverlay()
        {
            if (frmMain.Instance.InvokeRequired)
            {
                frmMain.Instance.BeginInvoke(new Action(HideOverlay));
            }
            else
            {
                if (frmBuildOverlay.Instance != null)
                {
                    frmBuildOverlay.Instance.Close();
                    frmBuildOverlay.Instance = null;
                }
            }

        }


        private static string ReadBufferToNull(byte[] buffer, int start, int length)
        {
            int len = start;

            for (int i = 0; i < length; i++)
            {
                if (buffer[i] == 0)
                {
                    break;
                }

                len++;
            }

            return Encoding.UTF8.GetString(buffer, 0, len);
        }

        private static string GetProfileFromID(string name, string id)
        {
            Match match = Regex.Match(id, @"(\d)-S2-(\d)-(\d+)");
            // Region-Game-Generation/Expo-ID
            // I've observed that Generation/Expo is usually 1 or 2. From my observations on NA and KR,
            // Generation has been 1 for NA and KR players, and 2 for LA and TW players.
            // Not really relevant, but interesting.

            if (match.Success)
            {
                int region = int.Parse(match.Groups[1].Value);
                string domain = "";
                string language = "";

                switch (region)
                {
                    case 1:
                        domain = "us.battle.net";
                        language = "en";
                        break;
                    case 2:
                        domain = "eu.battle.net";
                        language = "en";
                        break;
                    case 3:
                        domain = "kr.battle.net";
                        language = "kr";
                        break;
                    case 5:
                        domain = "www.battlenet.com.cn";
                        language = "cn";
                        break;
                    case 6:
                        domain = "sea.battle.net";
                        language = "en";
                        break;
                    default:
                        return null;

                        //What region is 4? LA or TW maybe.
                }

                return string.Format("http://{0}/sc2/{1}/profile/{2}/{3}/{4}/", domain, language, match.Groups[3].Value, match.Groups[2].Value, name);
            }
            else
            {
                return null;
                // Should probably do something meaningful here, since we're likely boned.
            }
        }

        internal static Models.Player GetPlayer(string name, string id)
        {
            string url = GetProfileFromID(name, id);
            if (string.IsNullOrEmpty(url))
                return null;

            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                string data = client.DownloadString(url);

                int initPos = data.IndexOf(@"<div class=""ladder"" data-tooltip=""#best-team-1"">");
                int boundary = data.IndexOf(@"<div class=""ladder"" data-tooltip=""#best-team-2"">");
                int pos = initPos;
                int pos2 = -1;


                if (pos == -1)
                    return null;


                string league = "none";
                pos = data.IndexOf(@"<span class=""badge badge-", pos);
                if ((pos == -1) || pos > boundary)
                    league = "none";
                else
                {

                    pos += 25;
                    pos2 = data.IndexOf(@" badge", pos);
                    league = data.Substring(pos, pos2 - pos);
                }
                
                int rank = 100;

                pos = data.IndexOf("<strong>Rank:</strong> ", initPos);
                if ((pos == -1) || pos > boundary)
                    rank = 0;
                else {

                    pos += 23;
                    pos2 = data.IndexOf('\n', pos);

                    if (!int.TryParse(data.Substring(pos, pos2 - pos).Trim('\r'), out rank))
                        rank = 0;
                }

                string race = "";
                pos = data.IndexOf(@"<a href=""ladder/"" class=""race-", initPos);
                if (pos == -1)
                    race = "random";
                else
                {
                    pos += 30;
                    pos2 = data.IndexOf(@"""", pos);

                    race = data.Substring(pos, pos2 - pos);
                }

                int wins = -1;
                int losses = -1;
                int points = -1;

                if (rank > 0)
                {
                    pos = data.IndexOf(@"<a href=""", initPos);

                    if (pos > -1)
                    {
                        pos += 9;
                        if (pos < boundary)
                        {
                            pos2 = data.IndexOf(@""">", pos);

                            string ladderPath = data.Substring(pos, pos2 - pos);
                            Uri uri = new Uri(url);
                            uri = new Uri(string.Format("http://{0}{1}", uri.Host, ladderPath));

                            try
                            {
                                string ladderData = client.DownloadString(uri);

                                pos = ladderData.IndexOf(@"id=""current-rank"">");
                                if (pos > -1)
                                {
                                    int ladderBoundary = ladderData.IndexOf("</tr>", pos);
                                    if (ladderBoundary > -1)
                                    {
                                        pos = ladderData.IndexOf(@"<td class=""align-center"">", pos);
                                        if (pos > -1 && pos < ladderBoundary)
                                        {
                                            pos += 25;
                                            pos2 = ladderData.IndexOf("</td>", pos);

                                            if (!int.TryParse(ladderData.Substring(pos, pos2 - pos), out points))
                                            {
                                                points = -1;
                                            }

                                            pos = ladderData.IndexOf(@"<td class=""align-center"">", pos2);

                                            if (pos > -1 && pos < ladderBoundary)
                                            {
                                                pos += 25;
                                                pos2 = ladderData.IndexOf("</td>", pos);

                                                if (!int.TryParse(ladderData.Substring(pos, pos2 - pos), out wins))
                                                {
                                                    wins = -1;
                                                }

                                                pos = ladderData.IndexOf(@"<td class=""align-center"">", pos2);

                                                if (pos > -1 && pos < ladderBoundary)
                                                {
                                                    pos += 25;
                                                    pos2 = ladderData.IndexOf("</td>", pos);

                                                    if (!int.TryParse(ladderData.Substring(pos, pos2 - pos), out losses))
                                                    {
                                                        losses = -1;
                                                    }
                                                }
                                            }
                                        }


                                    }


                                }
                            }
                            catch { }
                        }
                    }
                }
                



                Models.Player.PortraitData portrait = null;

                pos = data.IndexOf(@"<span class=""icon-frame """);

                
                if (pos > -1)
                {
                    pos = data.IndexOf(@"style=""", pos);
                    if (pos > -1)
                    {
                        pos += 7;
                        pos2 = data.IndexOf('"', pos);
                        string style = data.Substring(pos, pos2 - pos);

                        Match match = Regex.Match(style, @".*background: url\('(.*)'\) \-?(\d+)px \-?(\d+)px.*");

                        if (match.Success)
                        {
                            Uri uri = new Uri(url);
                            uri = new Uri(string.Format("http://{0}{1}", uri.Host, match.Groups[1].Value));

                            string localFile = string.Format(@"{0}\PortraitCache\{1}\{2}", Program.DataDirectory, uri.Query.Trim('?'), Path.GetFileName(uri.LocalPath));

                            if (!File.Exists(localFile))
                            {
                                try
                                {
                                    Directory.CreateDirectory(Path.GetDirectoryName(localFile));
                                    client.DownloadFile(uri, localFile);
                                }
                                catch { localFile = null; }
                            }

                            if (localFile != null)
                            {
                                portrait = new Models.Player.PortraitData(localFile, int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), 90, 90);
                            }
                        }

                    }
                }

                return new Models.Player(name, race, league, rank, points, wins, losses, portrait);

            }
            catch { return null; }
        }

        internal static void SC2InteractionThreadWorker()
        {
            try
            {

                while (true)
                {
                    Process sc2Process = null;

                    while (sc2Process == null)
                    {
                        if (!Configuration.Instance.UseAdvancedOptions)
                            throw new Exception();
                        System.Threading.Thread.Sleep(100);
                        Process[] processes = Process.GetProcessesByName("SC2");

                        foreach (Process p in processes)
                        {
                            if (!p.HasExited)
                            {
                                if (p.MainWindowTitle == "StarCraft II")
                                {
                                    sc2Process = p;
                                }
                            }
                        }
                    }



                    byte[] buffer = new byte[256];
                    int read;

                    bool inGame = false;
                    bool tabbed = false;
                    string game_player_1 = null;
                    string game_player_1_id = null;
                    string game_player_2 = null;
                    string game_player_2_id = null;


                    while (!sc2Process.HasExited)
                    {
                        if (!Configuration.Instance.UseAdvancedOptions)
                            throw new Exception();
                        if (Program.ActivePatch != null)
                        {
                            if (sc2Process.MainWindowHandle == IntPtr.Zero || !Win32.IsWindow(sc2Process.MainWindowHandle))
                            {
                                inGame = false;
                                Debug.WriteLine("SC2 main window gone.");
                                HidePlayerInfo();
                                HideBuildSelection();
                                HideOverlay();
                            }

                            Win32.RECT rct;
                            Win32.GetWindowRect(sc2Process.MainWindowHandle, out rct);

                            SC2WindowRect.X = rct.Left;
                            SC2WindowRect.Y = rct.Top;
                            SC2WindowRect.Width = rct.Right - rct.Left;
                            SC2WindowRect.Height = rct.Bottom - rct.Top;

                            yScale = (double)Program.SC2WindowRect.Height / (double)720;
                            xScale = (double)Program.SC2WindowRect.Width / (double)1280;
                            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                            if (!inGame)
                            {
                                bool result = Win32.ReadProcessMemory(sc2Process.Handle, Program.ActivePatch.Ptr1, buffer, 256, out read);

                                if (result)
                                {
                                    if (buffer[0] != 0)
                                    {


                                        game_player_1 = ReadBufferToNull(buffer, 0, read);

                                        Win32.ReadProcessMemory(sc2Process.Handle, Program.ActivePatch.Ptr1 + Program.ActivePatch.Ptr1Size, buffer, 256, out read);
                                        game_player_2 = ReadBufferToNull(buffer, 0, read);

                                        Win32.ReadProcessMemory(sc2Process.Handle, Program.ActivePatch.Ptr2, buffer, 256, out read);
                                        game_player_1_id = ReadBufferToNull(buffer, 0, read);

                                        Win32.ReadProcessMemory(sc2Process.Handle, Program.ActivePatch.Ptr2 + Program.ActivePatch.Ptr2Size, buffer, 256, out read);
                                        game_player_2_id = ReadBufferToNull(buffer, 0, read);

                                        if (string.IsNullOrEmpty(game_player_1_id) && (string.IsNullOrEmpty(game_player_2_id)))
                                        {
                                            Debug.WriteLine("AI Showmatch?");
                                        }
                                        else if (!string.IsNullOrEmpty(game_player_1_id) && (string.IsNullOrEmpty(game_player_2_id)))
                                        {
                                            Debug.WriteLine(string.Format("Now in game: {0} @ {1} ({2})", game_player_1, game_player_1_id, GetProfileFromID(game_player_1, game_player_1_id)));
                                            Debug.WriteLine("Now in game: AI?");

                                            if (Configuration.Instance.BuildSelectionOverlay)
                                            {
                                                ShowBuildSelection();
                                            }

                                        }
                                        else
                                        {
                                            Debug.WriteLine(string.Format("Now in game: {0} @ {1} ({2})", game_player_1, game_player_1_id, GetProfileFromID(game_player_1, game_player_1_id)));
                                            Debug.WriteLine(string.Format("Now in game: {0} @ {1} ({2})", game_player_2, game_player_2_id, GetProfileFromID(game_player_2, game_player_2_id)));

                                            if (Configuration.Instance.OpponentInfoOverlay)
                                            {
                                                Models.Player player = null;
                                                if (game_player_1.ToLower() == Configuration.Instance.MySC2Character.ToLower())
                                                {
                                                    player = GetPlayer(game_player_2, game_player_2_id);
                                                }
                                                else
                                                {
                                                    player = GetPlayer(game_player_1, game_player_1_id);
                                                }

                                                ShowPlayerInfo(player);
                                            }

                                            if (Configuration.Instance.BuildSelectionOverlay)
                                            {
                                                ShowBuildSelection();
                                            }
                                        }

                                        inGame = true;
                                    }
                                }
                            }
                            else
                            {
                                bool result = Win32.ReadProcessMemory(sc2Process.Handle, Program.ActivePatch.Ptr1, buffer, 256, out read);
                                if (!result)
                                {
                                    inGame = false;
                                }
                                else
                                {
                                    if (buffer[0] == 0)
                                    {
                                        inGame = false;
                                        Debug.WriteLine("Now out of game.");
                                        HidePlayerInfo();
                                        HideBuildSelection();
                                        HideOverlay();
                                    }
                                    else
                                    {
                                        IntPtr fgw = Win32.GetForegroundWindow();

                                        if (tabbed)
                                        {
                                            if (fgw == sc2Process.MainWindowHandle)
                                            {
                                                tabbed = false;
                                                Debug.WriteLine("Tabbed in");

                                                if (frmPlayerInfo.Instance != null)
                                                {
                                                    frmPlayerInfo.Instance.ShowNoActivate();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (fgw != sc2Process.MainWindowHandle)
                                            {

                                                tabbed = true;
                                                Debug.WriteLine("Tabbed out");
                                                if (frmPlayerInfo.Instance != null)
                                                {
                                                    frmPlayerInfo.Instance.HideWindow();
                                                }
                                            }


                                        }
                                    }
                                }
                            }
                            
                        }

                        System.Threading.Thread.Sleep(500);
                    }

                    inGame = false;
                    Debug.WriteLine("Process exited");
                    HidePlayerInfo();
                    HideBuildSelection();
                    HideOverlay();
                }

            }
            catch
            {
                HidePlayerInfo();
                HideBuildSelection();
                _sc2InteractionThread = null;
            }
        }

        


        internal static void LoadDefaultBuilds()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            
            try
            {
                client.DownloadFile("http://www.veritasimo.cjb.net/builds.xml", string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml"));
                if (!File.ReadAllText(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml")).StartsWith("<?xml"))
                {
                    throw new XmlException();
                }
            }
            catch {
                try
                {
                    File.WriteAllText(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml"), Properties.Resources.builds);
                }
                catch (Exception ex)
                {
                    // shit, son.
                    MessageBox.Show("Failed to save the build defaults. Something is probably wrong here. {0}", ex.ToString());
                }
            }
        }

        internal static void LoadPatchData()
        {
            XmlDocument document = new XmlDocument();
            ActivePatch = null;
            PatchList = new List<Models.Patch>();

            try
            {
                document.Load("http://www.veritasimo.cjb.net/patch.xml");
            }
            catch
            {
                try
                {
                    document.LoadXml(Properties.Resources.patch);
                }
                catch (Exception ex)
                {
                    document = null;
                }
            }

            if (document == null)
            {
                MessageBox.Show("The patch data couldn't load. There's probably a horrific error with the XML file. Tell someone in charge.");
                return;
            }

            XmlNodeList nodes = document.GetElementsByTagName("Patch");

            foreach (XmlNode node in nodes)
            {
                PatchList.Add(new Models.Patch(node.Attributes["Version"].Value, (IntPtr)int.Parse(node.Attributes["Ptr1"].Value, System.Globalization.NumberStyles.HexNumber), (IntPtr)int.Parse(node.Attributes["Ptr2"].Value, System.Globalization.NumberStyles.HexNumber), int.Parse(node.Attributes["Size1"].Value, System.Globalization.NumberStyles.HexNumber), int.Parse(node.Attributes["Size2"].Value, System.Globalization.NumberStyles.HexNumber)));
            }

            if (PatchList.Count > 0)
                ActivePatch = PatchList[0];
        }

        internal static void LoadBuildsXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildCollection));

            if (!File.Exists(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml")))
                LoadDefaultBuilds();

            if (File.Exists(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml")))
            {
                XmlReader reader = XmlReader.Create(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml"));
                BuildsDB = (BuildCollection)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                BuildsDB = new BuildCollection();
                SaveBuildsXML();
            }

        }

        internal static void SaveBuildsXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildCollection));
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true;
            xws.IndentChars = "\t";
            xws.NewLineHandling = NewLineHandling.Entitize;

            XmlWriter writer = XmlWriter.Create(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "builds.xml"), xws);
            serializer.Serialize(writer, BuildsDB);

            writer.Close();
        }

        internal static void LoadConfigurationXML()
        {
            XmlSerializer configSerializer = new XmlSerializer(typeof(Configuration));

            if (File.Exists(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "config.xml")))
            {
                XmlReader reader = XmlReader.Create(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "config.xml"));
                Configuration.Instance = (Configuration)configSerializer.Deserialize(reader);
                Configuration.Instance.FirstRun = false;
                reader.Close();
            }
            else
            {
                Configuration.Instance = new Configuration();
                Configuration.Instance.FirstRun = true;
                Configuration.Instance.OverlayContentFont = "Arial";
                Configuration.Instance.OverlayTitleFont = "Arial";
                Configuration.Instance.OverlayTitleSize = 24.0f;
                Configuration.Instance.OverlayContentSize = 16.0f;
                Configuration.Instance.OverlayTextColour = System.Drawing.Color.FromArgb(255, 255, 255);
                Configuration.Instance.OverlayTextOutlineColour = System.Drawing.Color.FromArgb(255, 0, 128, 192);
                Configuration.Instance.OverlayTextOutlineSize = 1;
                Configuration.Instance.OverlayImageScale = 2;
            }
        }


        internal static void SaveConfigurationXML()
        {
            XmlSerializer configSerializer = new XmlSerializer(typeof(Configuration));
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true;
            xws.IndentChars = "\t";
            xws.NewLineHandling = NewLineHandling.Entitize;

            XmlWriter writer = XmlWriter.Create(string.Format("{0}{1}{2}", DataDirectory, Path.DirectorySeparatorChar, "config.xml"), xws);
            configSerializer.Serialize(writer, Configuration.Instance);

            writer.Close();
        }
    }
}
