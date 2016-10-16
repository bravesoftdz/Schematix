using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Schematix
{
    class LanguageRecord
    {
        const String END_OF_TEXT = "\t\t\t";
        public int Idx = 0;
        public String Name;
        public String
            //# MainForm
            hAppMapNew   = "Create new map",
            hAppMapClose = "Close map",
            hAppOptions  = "Open program options",
            hAppLibrary  = "Open map objects catalog",
            hAppAbout    = "Open about program",
            hMapOptions  = "Open new options",
            // Context menu
            lMapCMOptions = "Options",
            lMapCMSave    = "Save",
            lMapCMLoad    = "Load",
            lMapCMReload  = "Reload",
            lMapCMClose   = "Close",

            //
            lDeleting         = "Deleting:",
            lCopying          = "Copying:",

            // Dialongs
            mLanguagesLoading = "Language packs loading",
            mOccurred         = "The following errors occurred:",

            // About form
            lAbout        = "About",
            lAppName      = "Product name:",
            lAppVersion   = "Version:",
            lOwner        = "Owner:",
            lContact      = "Contact:",
            tDescription  = "Description\n\nThis program designed for comparison and synchronization folders.";

        static public String ReadText(StreamReader file)//Ok
        {
            StringBuilder text = new StringBuilder();
            String line = file.ReadLine();
            if (line == END_OF_TEXT)
                return "";
            text.Append(line);
            do
            {
                line = file.ReadLine();
                if (line == END_OF_TEXT)
                    break;
                text.Append("\r\n");
                text.Append(line);
            } while (!file.EndOfStream);
            return text.ToString();
        }

        public LanguageRecord(String languageName = "English", int newIdx = 0)//Ok
        {
            Name = languageName;
            Idx = newIdx;
        }

        public String LoadFromStream(StreamReader file)//Ok
        {
            if (file == null)
                return "";
            String lblName, lblText, lblHint;
            try
            {   //Fill record
                while (!file.EndOfStream)
                {
                    String[] rec = file.ReadLine().Split('\t'); //read command line and splits to label's name:text:hint
                    if (rec[0] == "")
                        continue;
                    lblName = rec[0];
                    lblText = (rec.Count() < 2) ? rec[0] : rec[1]; //no text - use name as label
                    lblHint = (rec.Count() < 3) ? "" : rec[2];
                    //Fill label's text[:hint]
                    switch (lblName)
                    {
                        //# Main
                        case "hAppMapNew":        hAppMapNew        = lblText;   break;
                        case "hAppMapClose":      hAppMapClose      = lblText;   break;
                        case "hAppOptions":       hAppOptions       = lblText;   break;
                        case "hAppLibrary":       hAppLibrary       = lblText;   break;
                        case "hAppAbout":         hAppAbout         = lblText;   break;
                        case "hMapOptions":       hMapOptions       = lblText;   break;
                        // Context menu
                        case "lMapCMOptions":     lMapCMOptions     = lblText;   break;
                        case "lMapCMSave":        lMapCMSave        = lblText;   break;
                        case "lMapCMLoad":        lMapCMLoad        = lblText;   break;
                        case "lMapCMReload":      lMapCMReload      = lblText;   break;
                        case "lMapCMClose":       lMapCMClose       = lblText;   break;

                        // Dialongs
                        case "mLanguagesLoading": mLanguagesLoading = lblText;   break;
                        case "mOccurred":         mOccurred         = lblText;   break;

                        //# About form
                        case "lAbout":    lAbout       = lblText;          break;
                        case "lAName":    lAppName     = lblText;          break;
                        case "lAVertion": lAppVersion  = lblText;          break;
                        case "lOwner":    lOwner       = lblText;          break;
                        case "lContact":  lContact     = lblText;          break;
                        case "tAbout":    tDescription = ReadText(file);   break;

                        default:
                            break;
                    }
                }
                // End of file
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "";
        }
    }

}
