using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Schematix
{
    static class options
    {
        public const String iniFile = "Schematix.ini";
        public const int MAX_PING_PERIOD = 24*3600000;
        public const int MAX_PING_COUNT  =   10;
        public const int MAX_GRID_STEP   = 1000;
        public const int MIN_GRID_STEP   =    2;
        public const int MAX_GRID_THICK  =    5;

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
            PingCount  = 1;
        static public bool
            PingOnn = false;

        // Path roots
        static public String
            RootMaps    = "Maps",
            RootObjects = "Objects",
            RootLinks   = "Links",
            RootBoxes   = "Boxes";

        // Grid
        static public bool
            GridStoreOwn = false,
            GridAlign = false;
        static public int
            GridStyle = 0,
            GridStepX = 32,
            GridStepY = 32,
            GridThick = 1;
        static public Color
            GridColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);

        // Background
        static public bool   BackgroundStoreOwn = false;
        static public int    BackgroundStyle = 0;
        static public Color  BackgroundColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x80);
        static public Bitmap BackgroundImage = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        static public String BackgroundImagePath = "";


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

        static public String Load(String fileName = iniFile)//!!!
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
                            case "RootMaps":      RootMaps    = value;   break;
                            case "RootObjects":   RootObjects = value;   break;
                            case "RootLinks":     RootLinks   = value;   break;
                            case "RootBoxes":     RootBoxes   = value;   break;
                            // Behavior
                            case "OnStart":       OnStart = SetCounter(value, 2);                    break;//!!!
                            case "OnClose":       OnClose = SetCounter(value, 2);                    break;//!!!
                            case "PingOnn":       PingOnn = (value.ToUpper() == "YES");              break;
                            case "PingPeriod":    OnStart = SetCounter(value, MAX_PING_PERIOD, 1);   break;
                            case "PingCount":     OnStart = SetCounter(value, 10, 1);                break;

                            //# Map
                            // Grid
                            case "GridStoreOwn":  GridStoreOwn = (value.ToUpper() == "YES");                     break;
                            case "GridStyle":     GridStyle = SetCounter(value, 4);                              break;//!!!
                            case "GridColor":     GridColor = Color.FromArgb(StrToInt(value));                   break;
                            case "GridStepX":     GridStepX = SetCounter(value, MAX_GRID_STEP, MIN_GRID_STEP);   break;
                            case "GridStepY":     GridStepY = SetCounter(value, MAX_GRID_STEP, MIN_GRID_STEP);   break;
                            case "GridThick":     GridThick = SetCounter(value, MAX_GRID_THICK, 1);              break;
                            case "GridAlign":     GridAlign = (value.ToUpper() == "YES");                        break;
                            // Background
                            case "BackgroundStoreOwn":  BackgroundStoreOwn  = (value.ToUpper() == "YES");        break;
                            case "BackgroundStyle":     BackgroundStyle     = SetCounter(value, 4);              break;//!!!
                            case "BackgroundColor":     BackgroundColor     = Color.FromArgb(StrToInt(value));   break;
                            case "BackgroundImagePath":
                                BackgroundImagePath = value;
                                if (File.Exists(value))
                                    BackgroundImage = new Bitmap(value);
                                break;

                            //# Map list

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

        static public String Save(String fileName = iniFile)//!!!
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
                    file.WriteLine("GridStoreOwn\t" + (GridStoreOwn ? "yes" : "no"));
                    file.WriteLine("GridStyle\t"    + GridStyle);
                    file.WriteLine("GridColor\t"    + GridColor.ToArgb());
                    file.WriteLine("GridStepX\t"    + GridStepX);
                    file.WriteLine("GridStepY\t"    + GridStepY);
                    file.WriteLine("GridThick\t"    + GridThick);
                    file.WriteLine("GridAlign\t"    + GridAlign);
                    // Background
                    file.WriteLine("BackgroundStoreOwn\t"  + (BackgroundStoreOwn ? "yes" : "no"));
                    file.WriteLine("BackgroundStyle\t"     + BackgroundStyle);
                    file.WriteLine("BackgroundColor\t"     + BackgroundColor.ToArgb());
                    file.WriteLine("BackgroundImagePath\t" + BackgroundImagePath);

                    //# Map list
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
        }

    }
}