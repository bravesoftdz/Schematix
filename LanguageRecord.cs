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
            //# Main Form
            hMFNewMap     = "Create new map",
            hMFCloseMap   = "Close map",
            hMFOptions    = "Open program options",
            hMFLibrary    = "Open map objects catalog",
            hMFAbout      = "Open about program",
            hMFMapOptions = "Open new options",
            // Context menu
            lMFMapCMOptions = "Options",
            lMFMapCMSave    = "Save",
            lMFMapCMLoad    = "Load",
            lMFMapCMReload  = "Reload",
            lMFMapCMClose   = "Close",

            //# Main Options
            lOFTitle = "Main options",
            //* Main tab
            lOFMainTab = "Main",
            // Language
            lOFMainLanguage     = "Language",
            lOFMainLanguagePath = "Load from",
            // Root folders
            lOFMainRoots       = "Root folders",
            hOFMainRootGet     = "Select folder",
            lOFMainRootMaps    = "Maps",
            lOFMainRootObjects = "Objects",
            lOFMainRootLinks   = "Links",
            lOFMainRootBoxes   = "Boxes",
            // Behaiour
            lOFMainBehaiour      = "Behaiour",
            lOFMainOnStart       = "On starting program",
            lOFMainOnStart0Empty = "Start empty",
            lOFMainOnStart1Ask   = "Ask to load last maps",
            lOFMainOnStart2Load  = "Load last maps",
            lOFMainOnClose       = "On closing program",
            lOFMainOnClose0Exit  = "Just exit",
            lOFMainOnClose1Ask   = "Ask to save maps",
            lOFMainOnClose2Save  = "Save maps",
            lOFMainPingPeriod    = "Period of ping (miliseconds)",
            lOFMainPingCount     = "Maximum count of pings per period",
            //* Map tab
            lOFMapTab = "New map",
            lOFMapStore = "Save options in map",
            // Grid
            lOFMapGrid = "Grid",
            lOFMapGridStyle0None    = "None",
            lOFMapGridStyle1Dots    = "Dots",
            lOFMapGridStyle2Corners = "Corners",
            lOFMapGridStyle3Crosses = "Crosses",
            lOFMapGridStyle4Grid    = "Grid",
            hOFMapGridColor         = "Pick color",
            lOFMapGridThick         = "Thickness",
            lOFMapGridAlign         = "Align elements to grid",
            // Background
            lOFMapBack = "Background",
            lOFMapBackStyle0Color        = "Color",
            lOFMapBackStyle1ImageAlign   = "Image (1:1)",
            lOFMapBackStyle2ImageTile    = "Image (tile)",
            lOFMapBackStyle3ImageStrech  = "Image (strech)",
            lOFMapBackStyle4ImageZInner  = "Image (Zoom inner)",
            lOFMapBackStyle5ImageZOutter = "Image (Zoom outter)",
            hOFMapBackColor              = "Pick color",
            lOFMapBackImagePath          = "Path to image",
            hOFMapBackImageLoad          = "Load image",
            lOFMapBackImageAlign         = "Image align",
            lOFMapBackImageAlign0TL      = "Top Left",
            lOFMapBackImageAlign1T       = "Top",
            lOFMapBackImageAlign2TR      = "Top Right",
            lOFMapBackImageAlign3L       = "Left",
            lOFMapBackImageAlign4C       = "Center",
            lOFMapBackImageAlign5R       = "Right",
            lOFMapBackImageAlign6BL      = "Bottom Left",
            lOFMapBackImageAlign7B       = "Bottom",
            lOFMapBackImageAlign8BR      = "Bottom Right",
            lOFMapBackImageFloat         = "Float image",
            lOFMapBackImageBuildIn       = "Save to file",

            //...

            // Dialongs
            dLanguagesLoading  = "Language packs loading",
            mErrorsOccurred    = "The following errors occurred:",
            dOptionsLoading    = "Loading options",
            dOptionsSaving     = "Saving options",
            mNoFolders         = "These folders doesn't exists:",
            mCreateThem        = "Create them?",
            dImageLoading      = "Loading image",

            // About form
            lAbout        = "About",
            lAppName      = "Product name:",
            lAppVersion   = "Version:",
            lOwner        = "Owner:",
            lContact      = "Contact:",
            tDescription  = "Description\n\nThis program designed for visualize and monitor computer network.";

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
                        //# Main Form
                        case "hMFMapNew":       hMFNewMap       = lblText;   break;
                        case "hMFMapClose":     hMFCloseMap     = lblText;   break;
                        case "hMFOptions":      hMFOptions      = lblText;   break;
                        case "hMFLibrary":      hMFLibrary      = lblText;   break;
                        case "hMFAbout":        hMFAbout        = lblText;   break;
                        case "hMFMapOptions":   hMFMapOptions   = lblText;   break;
                        // Context menu
                        case "lMFMapCMOptions": lMFMapCMOptions = lblText;   break;
                        case "lMFMapCMSave":    lMFMapCMSave    = lblText;   break;
                        case "lMFMapCMLoad":    lMFMapCMLoad    = lblText;   break;
                        case "lMFMapCMReload":  lMFMapCMReload  = lblText;   break;
                        case "lMFMapCMClose":   lMFMapCMClose   = lblText;   break;

                        //# Main Options
                        case "lOFTitle": lOFTitle = lblText;   break;
                        //* Main tab
                        case "lOFMainTab": lOFMainTab = lblText;   break;
                        // Language
                        case "lOFMainLanguage":     lOFMainLanguage     = lblText;   break;
                        case "lOFMainLanguagePath": lOFMainLanguagePath = lblText;   break;
                        // Root folders
                        case "lOFMainRoots":       lOFMainRoots       = lblText;   break;
                        case "hOFMainRootGet":     hOFMainRootGet     = lblText;   break;
                        case "lOFMainRootMaps":    lOFMainRootMaps    = lblText;   break;
                        case "lOFMainRootObjects": lOFMainRootObjects = lblText;   break;
                        case "lOFMainRootLinks":   lOFMainRootLinks   = lblText;   break;
                        case "lOFMainRootBoxes":   lOFMainRootBoxes   = lblText;   break;
                        // Behaiour
                        case "lOFMainBehaiour":      lOFMainBehaiour      = lblText;   break;
                        case "lOFMainOnStart":       lOFMainOnStart       = lblText;   break;
                        case "lOFMainOnStart0Empty": lOFMainOnStart0Empty = lblText;   break;
                        case "lOFMainOnStart1Ask":   lOFMainOnStart1Ask   = lblText;   break;
                        case "lOFMainOnStart2Load":  lOFMainOnStart2Load  = lblText;   break;
                        case "lOFMainOnClose":       lOFMainOnClose       = lblText;   break;
                        case "lOFMainOnClose0Exit":  lOFMainOnClose0Exit  = lblText;   break;
                        case "lOFMainOnClose1Ask":   lOFMainOnClose1Ask   = lblText;   break;
                        case "lOFMainOnClose2Save":  lOFMainOnClose2Save  = lblText;   break;
                        case "lOFMainPingPeriod":    lOFMainPingPeriod    = lblText;   break;
                        case "lOFMainPingCount":     lOFMainPingCount     = lblText;   break;
                        //* Map tab
                        case "lOFMapTab":   lOFMapTab   = lblText;   break;
                        case "lOFMapStore": lOFMapStore = lblText;   break;
                        // Grid
                        case "lOFMapGrid":              lOFMapGrid              = lblText;   break;
                        case "lOFMapGridStyle0None":    lOFMapGridStyle0None    = lblText;   break;
                        case "lOFMapGridStyle1Dots":    lOFMapGridStyle1Dots    = lblText;   break;
                        case "lOFMapGridStyle2Corners": lOFMapGridStyle2Corners = lblText;   break;
                        case "lOFMapGridStyle3Crosses": lOFMapGridStyle3Crosses = lblText;   break;
                        case "lOFMapGridStyle4Grid":    lOFMapGridStyle4Grid    = lblText;   break;
                        case "hOFMapGridColor":         hOFMapGridColor         = lblText;   break;
                        case "lOFMapGridThick":         lOFMapGridThick         = lblText;   break;
                        case "lOFMapGridAlign":         lOFMapGridAlign         = lblText;   break;
                        // Background
                        case "lOFMapBack":                    lOFMapBack                   = lblText;   break;
                        case "lOFMapBackStyle0Color":         lOFMapBackStyle0Color        = lblText;   break;
                        case "lOFMapBackStyle1ImageAlign":    lOFMapBackStyle1ImageAlign   = lblText;   break;
                        case "lOFMapBackStyle2ImageTile":     lOFMapBackStyle2ImageTile    = lblText;   break;
                        case "lOFMapBackStyle3ImageStrech":   lOFMapBackStyle3ImageStrech  = lblText;   break;
                        case "lOFMapBackStyle4ImageZInner":   lOFMapBackStyle4ImageZInner  = lblText;   break;
                        case "lOFMapBackStyle5ImageZOutter":  lOFMapBackStyle5ImageZOutter = lblText;   break;
                        case "hOFMapBackColor":               hOFMapBackColor              = lblText;   break;
                        case "lOFMapBackImagePath":           lOFMapBackImagePath          = lblText;   break;
                        case "hOFMapBackImageLoad":           hOFMapBackImageLoad          = lblText;   break;
                        case "lOFMapBackImageAlign":          lOFMapBackImageAlign         = lblText;   break;
                        case "lOFMapBackImageAlign0TL":       lOFMapBackImageAlign0TL      = lblText;   break;
                        case "lOFMapBackImageAlign1T":        lOFMapBackImageAlign1T       = lblText;   break;
                        case "lOFMapBackImageAlign2TR":       lOFMapBackImageAlign2TR      = lblText;   break;
                        case "lOFMapBackImageAlign3L":        lOFMapBackImageAlign3L       = lblText;   break;
                        case "lOFMapBackImageAlign4C":        lOFMapBackImageAlign4C       = lblText;   break;
                        case "lOFMapBackImageAlign5R":        lOFMapBackImageAlign5R       = lblText;   break;
                        case "lOFMapBackImageAlign6BL":       lOFMapBackImageAlign6BL      = lblText;   break;
                        case "lOFMapBackImageAlign7B":        lOFMapBackImageAlign7B       = lblText;   break;
                        case "lOFMapBackImageAlign8BR":       lOFMapBackImageAlign8BR      = lblText;   break;
                        case "lOFMapBackImageFloat":          lOFMapBackImageFloat         = lblText;   break;
                        case "lOFMapBackImageBuildIn":        lOFMapBackImageBuildIn       = lblText;   break;

                        // Dialongs
                        case "dLanguagesLoading": dLanguagesLoading = lblText;   break;
                        case "mErrorsOccurred":   mErrorsOccurred   = lblText;   break;
                        case "dOptionsLoading":   dOptionsLoading   = lblText;   break;
                        case "dOptionsSaving":    dOptionsSaving    = lblText;   break;
                        case "mNoFolders":        mNoFolders        = lblText;   break;
                        case "mCreateThem":       mCreateThem       = lblText;   break;
                        case "dImageLoading":     dImageLoading     = lblText;   break;

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
