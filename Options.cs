using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace Schematix
{
    static class Options
    {
        public const String TIME_FORMAT = "yyyy.MM.dd HH:mm:ss";
        // IP
        public const int  DEFAULT_PING_PERIOD         = 3000;
        public const int  DEFAULT_PING_TIMEOUT_GREEN  = 100; // < Green
        public const int  DEFAULT_PING_TIMEOUT_YELLOW = 100; // < Yellow
        public const int  DEFAULT_PING_TIMEOUT_RED    = 100; // < Red, ... - Out
        public const bool DEFAULT_PING_ONN            = false;
        public const int  DEFAULT_PING_ARRAY          = 5;

        public static String RECORD_FILENAME = "\\Node.xRec";
        public static String RECORD_FILEEXT  = "Schematix Prototype file|*.xRec";
        // Object Prototype
        public static readonly Color DEFAULT_OBJECT_IMAGE_COLOR = Color.Black; // for preview
        public static readonly Color DEFAULT_OBJECT_APLHA_COLOR = Color.White;
        // Link Prototype
        public static readonly Color DEFAULT_LINK_LINE_COLOR = Color.Maroon;
        // Box Prototype
        public static readonly Font  DEFAULT_BOX_FONT       = new Font("Curier", 14);
        public static readonly Color DEFAULT_BOX_TEXT_COLOR = Color.Black;

        // Exemplars
        public const int DEFAULT_FRAME_PADDING = 3;

        // Main options
        public const String iniFile = "Schematix.ini";
        public const int    MAX_PING_PERIOD = 24 * 3600000;
        public const int    MAX_PING_COUNT  = 10;
        public const int    DEFAULT_MAP_WIDTH  = 820;
        public const int    DEFAULT_MAP_HEIGHT = 400;
        public const bool   DEFAULT_MAP_AUTOSIZE = false;
        // Grid
        public const int             MAX_GRID_STEP      = 1000;
        public const int             DEFAULT_GRID_STEP  = 32;
        public const int             MIN_GRID_STEP      = 2;
        public const int             MAX_GRID_THICK     = 5;
        public const GridStyles      DEFAULT_GRID_STYLE = GridStyles.None;
        public static readonly Color DEFAULT_GRID_COLOR = Color.Silver;
        // Back
        public const BackgroundStyles   DEFAULT_BACK_STYLE  = BackgroundStyles.Color;
        public const AlignTypes         DEFAULT_BACK_ALIGN  = AlignTypes.TopLeft;
        public static readonly Color    DEFAULT_BACK_COLOR  = Color.LightSkyBlue;
        public static readonly Color    DEFAULT_BACK_ACOLOR = Color.White;

        // Language
        static public LanguageRecord LangCur = new LanguageRecord();
        static public List<LanguageRecord> Langs = new List<LanguageRecord>() { LangCur };
        static public String
            LangPath = "Languages",
            LangName = LangCur.Name;

        // Behaiour
        static public int
            OnStart = 0,
            OnClose = 0,
            PingPeriod = 200,
            PingCount  =   1;
        static public bool
            PingOnn = false;
        static public  xIP[]       PingIPsIDs  = new xIP[10];
        static public  Ping[]      PingSenders = new Ping[10];
        static private PingOptions PingOptions = new PingOptions(64, true);

        // Path roots
        static public String
            RootMaps    = "Maps",
            RootObjects = "Objects",
            RootLinks   = "Links",
            RootBoxes   = "Boxes";

        static public xGrid Grid = new xGrid();
        static public xBackground Back = new xBackground();
        
        // Display window
        static public MainForm mainForm = null;
        static public int
            WindowW,
            WindowH;
        // Tools
        static public RadioButton rbDefault;
        static public RadioButton rbObject;
        static public RadioButton rbLink;
        static public RadioButton rbBox;
        static public ToolTip     ToolTip;
        // Catalog
        static public ListView lvUsedObjects;
        static public ListView lvUsedLinks;
        static public ListView lvUsedBoxes;
        static public List<xPObject> PObjects = new List<xPObject>();
        static public List<xPLink>   PLinks   = new List<xPLink>();
        static public List<xPBox>    PBoxes   = new List<xPBox>();
        static public List<xMap>     Maps     = new List<xMap>();
        static public List<String>   MapFiles = new List<String>();
        // Ping list
        static public List<xIP> IPs = new List<xIP>();
        static public int LastSendIPIdx = 0;

        static public void AddIP(xIP IP)//
        {
            if (!IPs.Contains(IP))
                IPs.Add(IP);
        }

        static public void RemoveIP(xIP IP)//
        {
            int idx = IPs.IndexOf(IP);
            if (0 <= idx)
                if (idx < LastSendIPIdx)
                    LastSendIPIdx--;
            IPs.Remove(IP);
        }

        static public int SelectLanguage(String name)//Ok
        {
            int i = Langs.Count() - 1;
            for (; 0 < i; i--)
                if (Langs[i].Name == name)
                    break;
            LangCur = Langs[i];
            return i;
        }

        static public String LoadLanguages(String Path = "")//Ok
        {
            String errorStr = "";
            if (Path == "")
                Path = Directory.GetCurrentDirectory();
            try
            {
                String[] fileNames = Directory.GetFiles(Path, "*.lng");
                foreach (String fileName in fileNames)
                {
                    try
                    {
                        using (StreamReader file = File.OpenText(fileName))
                        {
                            // Read language name
                            String langName = file.ReadLine();
                            // Try to find
                            int i = Langs.Count() - 1;
                            for (; 0 <= i; i--)
                                if (Langs[i].Name == langName)
                                    break;
                            // Add new record
                            if (i < 0)
                            {
                                i = Langs.Count();
                                Langs.Add(new LanguageRecord(langName, i));
                            }
                            // Load rest of content
                            String eStr = Langs[i].LoadFromStream(file);
                            errorStr += (errorStr == "" ? "" : "\r\n") + eStr;
                        }
                    }
                    catch (Exception e)
                    {
                        errorStr += (errorStr == "" ? "" : "\r\n") + e.Message;
                    }
                }// for each file
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return errorStr;
        }

        static public int StrToInt(String value, int def = 0)//Ok
        {
            try {
                return Convert.ToInt32(value); }
            catch {
                return def; }
        }

        static public int SetCounter(int value, int maxValue, int minValue = 0, int defaultValue = 0)//Ok
        {
            if (defaultValue < minValue)
                defaultValue = minValue;
            if (value < minValue)
                return defaultValue;
            if (maxValue < value)
                return defaultValue;
            return value;
        }

        static public int SetCounter(String str, int maxValue, int minValue = 0, int defaultValue = 0)//Ok
        {
            return SetCounter(StrToInt(str, defaultValue), maxValue, minValue, defaultValue);
        }

        static public String Load(String fileName = iniFile)//!
        {
            try
            {
                using (StreamReader file = File.OpenText(fileName))
                {
                    while (!file.EndOfStream)
                    {
                        String line = file.ReadLine();
                        //Decompress
                        String[] rec = line.Split('\t');
                        if (rec.Count() < 2)
                            continue; //not an option:value pair - skip
                        String option = rec[0],
                               value = rec[1];
                        //Set option
                        switch (option)
                        {
                            //# Main
                            case "Language":      LangName    = value;   break;
                            case "LanguagesPath": LangPath    = value;   break;
                            // Root folders
                            case "RootMaps":    RootMaps    = value;   break;
                            case "RootObjects": RootObjects = value;   break;
                            case "RootLinks":   RootLinks   = value;   break;
                            case "RootBoxes":   RootBoxes   = value;   break;
                            // Behavior
                            case "OnStart":    OnStart    = SetCounter(value, 2);                    break;
                            case "OnClose":    OnClose    = SetCounter(value, 2);                    break;
                            case "PingOnn":    PingOnn    = (value.ToUpper() == "YES");              break;
                            case "PingPeriod": PingPeriod = SetCounter(value, MAX_PING_PERIOD, 1);   break;
                            case "PingCount":  PingCount  = SetCounter(value, 10, 1);                break;

                            //# Map
                            // Grid
                            case "GridStoreOwn": Grid.StoreOwn  = (value.ToUpper() == "YES");                               break;
                            case "GridStyle":    Grid.Style     = (GridStyles)SetCounter(value, 4);                         break;
                            case "GridColor":    Grid.Pen.Color = Color.FromArgb(StrToInt(value));                          break;
                            case "GridStepX":    Grid.StepX     = (Int16)SetCounter(value, MAX_GRID_STEP, MIN_GRID_STEP);   break;
                            case "GridStepY":    Grid.StepY     = (Int16)SetCounter(value, MAX_GRID_STEP, MIN_GRID_STEP);   break;
                            case "GridThick":    Grid.Pen.Width = (Int16)SetCounter(value, MAX_GRID_THICK, 1);              break;
                            case "GridAlign":    Grid.Snap      = (value.ToUpper() == "YES");                               break;
                            // Background   
                            case "BackgroundStoreOwn":  Back.StoreOwn  = (value.ToUpper() == "YES");               break;
                            case "BackgroundStyle":     Back.Style     = (BackgroundStyles)SetCounter(value, 5);   break;
                            case "BackgroundColor":     Back.Color     = Color.FromArgb(StrToInt(value));          break;
                            case "BackgroundImagePath":
                                Back.Path = value;
                                if (File.Exists(value))
                                    Back.Image = new Bitmap(value);
                                break;
                            case "BackgroundImageAlign":   Back.Align   = (AlignTypes)SetCounter(value, 8);   break;
                            case "BackgroundImageFloat":   Back.Float   = (value.ToUpper() == "YES");         break;
                            case "BackgroundImageBuildIn": Back.BuildIn = (value.ToUpper() == "YES");         break;

                            //# Map list
                            case "MapFile": MapFiles.Add(value);   break;

                            default:
                                break;
                        }//case parameter
                    }//File reading
                }//File open
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        static public String Save(String fileName = iniFile)//!
        {
            try
            {
                using (StreamWriter file = File.CreateText(fileName))
                {
                    //# Main
                    file.WriteLine("Language\t"          + LangCur.Name);
                    file.WriteLine("LanguagesPath\t"     + LangPath);
                    // Root folders
                    file.WriteLine("RootMaps\t"    + RootMaps);
                    file.WriteLine("RootObjects\t" + RootObjects);
                    file.WriteLine("RootLinks\t"   + RootLinks);
                    file.WriteLine("RootBoxes\t"   + RootBoxes);
                    // Behavior
                    file.WriteLine("OnStart\t"    + OnStart);
                    file.WriteLine("OnClose\t"    + OnClose);
                    file.WriteLine("PingOnn\t"    + (PingOnn ? "yes" : "no"));
                    file.WriteLine("PingPeriod\t" + PingPeriod);
                    file.WriteLine("PingCount\t"  + PingCount);

                    //# Map
                    // Grid
                    file.WriteLine("GridStoreOwn\t" + (Grid.StoreOwn ? "yes" : "no"));
                    file.WriteLine("GridStyle\t"    + (int)Grid.Style);
                    file.WriteLine("GridColor\t"    + Grid.Pen.Color.ToArgb());
                    file.WriteLine("GridStepX\t"    + Grid.StepX);
                    file.WriteLine("GridStepY\t"    + Grid.StepY);
                    file.WriteLine("GridThick\t"    + (int)Grid.Pen.Width);
                    file.WriteLine("GridAlign\t"    + (Grid.Snap ? "yes" : "no"));
                    // Background
                    file.WriteLine("BackgroundStoreOwn\t"     + (Back.StoreOwn ? "yes" : "no"));
                    file.WriteLine("BackgroundStyle\t"        + (int)Back.Style);
                    file.WriteLine("BackgroundColor\t"        + Back.Color.ToArgb());
                    file.WriteLine("BackgroundImagePath\t"    + Back.Path);
                    file.WriteLine("BackgroundImageAlign\t"   + (int)Back.Align);
                    file.WriteLine("BackgroundImageFloat\t"   + (Back.Float ? "yes" : "no"));
                    file.WriteLine("BackgroundImageBuildIn\t" + (Back.BuildIn ? "yes" : "no"));

                    //# Map list
                    foreach(var Map in Maps)
                        if (Map.FileName != "")
                            file.WriteLine("MapFile\t" + Map.FileName);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }

        static public void Init()//Ok
        {
            for (int i = PingSenders.Length - 1; 0 <= i; i--)
            {
                PingIPsIDs[i] = null;
                PingSenders[i] = new Ping();
                PingSenders[i].PingCompleted += PingCallback;
            }
        }
        
        static public void timerPing_Tick(object sender, EventArgs e)//!
        {
            if (IPs.Count < 1)
                return;
            // Init loop
            if (IPs.Count <= LastSendIPIdx)
                LastSendIPIdx = 0;
            int count = 0;
            xIP startIP = IPs[LastSendIPIdx];
            int SendersIdx = PingSenders.Length - 1;
            do
            {
                // Find free sender
                for (; 0 <= SendersIdx; SendersIdx--)
                    if (PingIPsIDs[SendersIdx] == null)
                        break;
                // No free sender
                if (SendersIdx < 0)
                    break;
                // Send
                xIP IP = IPs[LastSendIPIdx];
                if (IP.AddPing(DateTime.Now))
                {
                    PingIPsIDs[SendersIdx] = IP;
                    PingSenders[SendersIdx].SendPingAsync(
                        IP.Address,
                        IP.TimeOutGreen + IP.TimeOutYellow + IP.TimeOutRed,
                        Encoding.ASCII.GetBytes(IP.ID.ToString()),
                        PingOptions);
                }
                // Step
                LastSendIPIdx++;
                count++;
                // Finish?
                if (IPs.Count <= LastSendIPIdx)
                    LastSendIPIdx = 0;
                if (startIP == IPs[LastSendIPIdx])
                    break;
            } while (count < PingCount);
        }

        private static void PingCallback(object sender, PingCompletedEventArgs e)//!
        {
            // Find sender index
            int SendersIdx = PingSenders.Length - 1;
            for (; 0 <= SendersIdx; SendersIdx--)
                if (PingSenders[SendersIdx] == sender)
                    break;
            // Error
            if (SendersIdx < 0)
                return;
            // Get IP record
            xIP IP = PingIPsIDs[SendersIdx];
            if (IPs.Contains(IP))
                if (IP.Pings[0] != null)
                {
                    // Update record
                    if (e.Cancelled)
                        IP.Pings[0].State = PingStates.Cancelled;
                    else
                    {
                        if (e.Error != null)
                            IP.Pings[0].Error = e.Error.Message;
                        IP.Pings[0].State = PingStates.Replayed;
                        IP.Pings[0].Replayer = e.Reply.Address.ToString();
                        IP.Pings[0].Status = e.Reply.Status;
                        IP.Pings[0].TripTime = (int)e.Reply.RoundtripTime;
                        // Update showed info
                        Share.lvIPs_Renew(IP.Obj_lvItem, IP);
                        Share.lvIPs_Renew(IP.Map_lvItem, IP);
                        Share.lvPings_Renew(IP.IP_lv?.Items[0], IP, IP.Pings[0]);
                    }
                }
            PingIPsIDs[SendersIdx] = null;
        }
    }
}