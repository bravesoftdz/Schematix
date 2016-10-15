using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Schematix
{
    static class options
    {
        public const String iniFile = "Schematix.ini";
        // Language
        static public LanguageRecord LangCur = new LanguageRecord();
        static public List<LanguageRecord> Langs = new List<LanguageRecord>() { LangCur };
        static public String 
            LangPath = "",
            LangName = "";

        static public int SelectLanguage(String name)//Ok
        {
            int i = Langs.Count() - 1;
            for (; 0 < i; i--)
                if (Langs[i].name == name)
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
                                if (Langs[i].name == langName)
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

        static public String Load(String fileName = iniFile)//Ok
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
                            case "Language":
                                LangName = value;
                                SelectLanguage(value);
                                break;
                            case "LanguagesPath":
                                LangPath = value;
                                break;
                            // Behavior

                            //...

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

        static public String Save(String fileName = iniFile)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(fileName))
                {
                    file.WriteLine("Language\t"          + LangCur.name);
                    file.WriteLine("LanguagesPath\t"     + LangPath);
                    // Behavior

                    //...

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