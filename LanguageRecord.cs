using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Schematix
{
    class LanguageRecord
    {
        public const String END_OF_TEXT = "\t\t\t";
        public int Idx = 0;
        public String name;
        // Main
        public String
            //
            hAbout          = "About program",
            lDeleting         = "Deleting:",
            lCopying          = "Copying:",
            // Dialongs
            mLanguagesLoading = "Language packs loading",
            mOpenFolder       = "Open folder",
            mRunFile          = "Open file",
            mOccurred         = "The following errors occurred:",
            mDeleteRight      = "Delete from right:",

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
            name = languageName;
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
                        case "hAbout":         hAbout         = lblText;   break;
                        case "lDeleting":      lDeleting      = lblText;   break;
                        case "lCopying":       lCopying       = lblText;   break;
                        // Dialongs
                        case "mLanguagesLoading": mLanguagesLoading = lblText;   break;
                        case "mOpenFolder":       mOpenFolder       = lblText;   break;
                        case "mRunFile":          mRunFile          = lblText;   break;
                        case "mDeleteRight":      mDeleteRight      = lblText;   break;

                        //# About form
                        case "lAbout":    lAbout        = lblText;         break;
                        case "lAName":    lAppName      = lblText;         break;
                        case "lAVertion": lAppVersion   = lblText;         break;
                        case "lOwner":    lOwner        = lblText;         break;
                        case "lContact":  lContact      = lblText;         break;
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
