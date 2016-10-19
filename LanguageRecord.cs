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

        #region Main Form
            hMFTabNew = "Create new map",
            hMFTabClose   = "Close map",
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
        #endregion

        #region Main Options
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
            lOFMapGridStyle0Default = "Default", // Only for map
            lOFMapGridStyle1None    = "None",
            lOFMapGridStyle2Dots    = "Dots",
            lOFMapGridStyle3Corners = "Corners",
            lOFMapGridStyle4Crosses = "Crosses",
            lOFMapGridStyle5Grid    = "Grid",
            lOFMapGridAlign         = "Align elements to grid",
            // Background
            lOFMapBack = "Background",
            lOFMapBackStyle0Default      = "Default", // Only for map
            lOFMapBackStyle1Color        = "Color",
            lOFMapBackStyle2ImageAlign   = "Image (1:1)",
            lOFMapBackStyle3ImageTile    = "Image (tile)",
            lOFMapBackStyle4ImageStrech  = "Image (strech)",
            lOFMapBackStyle5ImageZInner  = "Image (Zoom inner)",
            lOFMapBackStyle6ImageZOutter = "Image (Zoom outter)",
        #endregion

        #region Library
            lLFTitle         = "Library",
            lLFCatalog       = "Catalog",
            lLFUsed          = "Used on map",
            hLFPinUp         = "Turn top state on",
            hLFPinDown       = "Turn top state off",
            hLFEdit          = "Edit element",
            hLFAdd           = "Add new sub-element",
            lLFColumName     = "Name",
            lLFColumCatalog  = "Catalog",
            lLFColumLocation = "Location",
        #endregion

        #region Element Edit (share)
            lEETitleAdd  = "Add new prototype:",
            lEETitleEdit = "Edit prototype:",
            // +
            lEETitleObject = "object",
            lEETitleLink   = "link",
            lEETitleBox    = "box",
            // Share
            lEENodeName = "Node name",
            lEEName     = "Name",
            lEEID       = "ID",
            lEERevision = "Revision",
            // +
            lEELineThick    = "Line thickness",
            lEELineStyle    = "Line style",
            hEEColorPick    = "Pick color",
            lEEImagePath    = "Path to image",
            hEEImageLoad    = "Load image",
            lEEImageFloat   = "Float image",
            lEEImageBuildIn = "Save to file",
            lEEImageBPP     = "Storing BPP",
            // Align
            lEEAlign    = "Align",
            lEEAlign0TL = "Top Left",
            lEEAlign1TC = "Top",
            lEEAlign2TR = "Top Right",
            lEEAlign3ML = "Left",
            lEEAlign4MC = "Center",
            lEEAlign5MR = "Right",
            lEEAlign6BL = "Bottom Left",
            lEEAlign7BC = "Bottom",
            lEEAlign8BR = "Bottom Right",
        #endregion

        #region Object Edit
            lOETabMain      = "Main",
            //
            lOETabImage       = "Image",
            lOEImageType      = "Type",
            lOEImageType0Load = "Load image",
            lOEImageType1Link = "Link to image",
            lOEUseBackColor   = "Back color on preview",
            //
            lOETabAlpha        = "Transparence",
            lOEAlphaType       = "Type",
            lOEAlphaType0Image = "As is",
            lOEAlphaType1Color = "Color",
            lOEAlphaType2Load  = "Load image",
            lOEAlphaType3Link  = "Link to image",
            //
            lOETabDotes     = "Dotes",
            lOEDot          = "Dot",
            lOEDotName      = "Dot name",
            hOEDotMoveUp    = "Move up",
            hOEDotMoveDown  = "Move down",
            hOEDotAdd       = "Add dot",
            hOEDotSave      = "Save dot",
            hOEDotDelete    = "Delete dot",
            lOEDotLocation  = "Location",
            //...
        #endregion

        /*Link Edit*/

        #region Box Edit
            lBEType           = "Type",
            lBEType0Text      = "Default text",
            lBEType1Rectangle = "Rectangle",
            lBEType2Ellipse   = "Ellipse",
            lBEText           = "Text",
        #endregion

        #region Element Options (share)
            lEOTitle = "Edit exemplar:",
            // Share
            lEOName            = "Name",
            lEOReference       = "Reference",
            hEOGetReference    = "Pick reference",
            // +
            hEOPrototypeDelete = "Delete prototype",
        #endregion

        #region Object Options
            hOOIPAdd         = "Add new IP",
            hOOIPDelete      = "Delete selected IP",
            // List
            lOOColumIP       = "Address",
            lOOColumPeriod   = "Period",
            lOOColumTimeLast = "Last check",
            lOOColumTimeNext = "Next check",
            lOOColumPing     = "Ping",
        #endregion

        /*Link Options*/

        #region Box Options
            lBOText = "Text",
        #endregion

        #region Map Options
            lMOTitle = "Map's options",
            lMOName  = "Name",
            lMOSize  = "Map size",
            lMOAuto  = "Auto",
            // List
            lMOColumName      = "Name",
            lMOColumLocation  = "Location",
            lMOColumPrototype = "Prototype",
            lMOColumReference = "Reference",
        #endregion

        #region IP Edit
            lIPTitleAdd  = "Add new IP address",
            lIPTitleEdit = "Edit IP address",
            lIPAddress   = "Address",
            lIPPeriod    = "Period (ms)",
            lIPTimeOut   = "Time out (ms)",
            lIPTimeNext  = "Next check",
        #endregion

            //...

        #region Dialongs & About
            // Dialongs
            dLanguagesLoading = "Language packs loading",
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
        #endregion

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
                    if (lblName.Length < 3)
                        continue;
                    switch (lblName[1] +""+ lblName[2])
                    {
                        #region Main Form
                        case "MF":
                            switch (lblName)
                            {
                                case "hMFTabNew":       hMFTabNew       = lblText;   break;
                                case "hMFTabClose":     hMFTabClose     = lblText;   break;
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
                            }
                            break;
                        #endregion

                        #region Main Options
                        case "OF":
                            switch (lblName)
                            {
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
                                case "lOFMapGridStyle0Default": lOFMapGridStyle0Default = lblText;   break;
                                case "lOFMapGridStyle1None":    lOFMapGridStyle1None    = lblText;   break;
                                case "lOFMapGridStyle2Dots":    lOFMapGridStyle2Dots    = lblText;   break;
                                case "lOFMapGridStyle3Corners": lOFMapGridStyle3Corners = lblText;   break;
                                case "lOFMapGridStyle4Crosses": lOFMapGridStyle4Crosses = lblText;   break;
                                case "lOFMapGridStyle5Grid":    lOFMapGridStyle5Grid    = lblText;   break;
                                case "lOFMapGridAlign":         lOFMapGridAlign         = lblText;   break;
                                // Background
                                case "lOFMapBack":                    lOFMapBack                   = lblText;   break;
                                case "lOFMapBackStyle0Default":       lOFMapBackStyle0Default      = lblText;   break;
                                case "lOFMapBackStyle1Color":         lOFMapBackStyle1Color        = lblText;   break;
                                case "lOFMapBackStyle2ImageAlign":    lOFMapBackStyle2ImageAlign   = lblText;   break;
                                case "lOFMapBackStyle3ImageTile":     lOFMapBackStyle3ImageTile    = lblText;   break;
                                case "lOFMapBackStyle4ImageStrech":   lOFMapBackStyle4ImageStrech  = lblText;   break;
                                case "lOFMapBackStyle5ImageZInner":   lOFMapBackStyle5ImageZInner  = lblText;   break;
                                case "lOFMapBackStyle6ImageZOutter":  lOFMapBackStyle6ImageZOutter = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Library Form
                        case "LF":
                            switch (lblName)
                            {
                                case "lLFTitle":         lLFTitle          = lblText;   break;
                                case "lLFCatalog":       lLFCatalog        = lblText;   break;
                                case "lLFUsed":          lLFUsed           = lblText;   break;
                                case "hLFPinUp":         hLFPinUp          = lblText;   break;
                                case "hLFPinDown":       hLFPinDown        = lblText;   break;
                                case "hLFEdit":          hLFEdit           = lblText;   break;
                                case "hLFAdd":           hLFAdd            = lblText;   break;
                                case "lLFColumName":     lLFColumName      = lblText;   break;
                                case "lLFColumCatalog":  lLFColumCatalog   = lblText;   break;
                                case "lLFColumLocation": lLFColumLocation  = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Element Edit (share)
                        case "EE":
                            switch (lblName)
                            {
                                case "lEETitleAdd":  lEETitleAdd  = lblText;   break;
                                case "lEETitleEdit": lEETitleEdit = lblText;   break;
                                // +
                                case "lEETitleObject": lEETitleObject = lblText;   break;
                                case "lEETitleLink":   lEETitleLink   = lblText;   break;
                                case "lEETitleBox":    lEETitleBox    = lblText;   break;
                                // Share
                                case "lEENodeName": lEENodeName = lblText;   break;
                                case "lEEName":     lEEName     = lblText;   break;
                                case "lEEID":       lEEID       = lblText;   break;
                                case "lEERevision": lEERevision = lblText;   break;
                                // +
                                case "lEELineThick":    lEELineThick    = lblText;   break;
                                case "lEELineStyle":    lEELineStyle    = lblText;   break;
                                case "hEEColorPick":    hEEColorPick    = lblText;   break;
                                case "lEEImagePath":    lEEImagePath    = lblText;   break;
                                case "hEEImageLoad":    hEEImageLoad    = lblText;   break;
                                case "lEEImageFloat":   lEEImageFloat   = lblText;   break;
                                case "lEEImageBuildIn": lEEImageBuildIn = lblText;   break;
                                case "lEEImageBPP":     lEEImageBPP     = lblText;   break;
                                // Align
                                case "lEEAlign":    lEEAlign    = lblText;   break;
                                case "lEEAlign0TL": lEEAlign0TL = lblText;   break;
                                case "lEEAlign1TC": lEEAlign1TC = lblText;   break;
                                case "lEEAlign2TR": lEEAlign2TR = lblText;   break;
                                case "lEEAlign3ML": lEEAlign3ML = lblText;   break;
                                case "lEEAlign4MC": lEEAlign4MC = lblText;   break;
                                case "lEEAlign5MR": lEEAlign5MR = lblText;   break;
                                case "lEEAlign6BL": lEEAlign6BL = lblText;   break;
                                case "lEEAlign7BC": lEEAlign7BC = lblText;   break;
                                case "lEEAlign8BR": lEEAlign8BR = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Object Edit
                        case "OE":
                            switch (lblName)
                            {
                                case "lOETabMain":        lOETabMain        = lblText;   break;
                                //
                                case "lOETabImage":       lOETabImage       = lblText;   break;
                                case "lOEImageType":      lOEImageType      = lblText;   break;
                                case "lOEImageType0Load": lOEImageType0Load = lblText;   break;
                                case "lOEImageType1Link": lOEImageType1Link = lblText;   break;
                                case "lOEUseBackColor":   lOEUseBackColor   = lblText;   break;
                                //
                                case "lOETabAlpha":        lOETabAlpha        = lblText;   break;
                                case "lOEAlphaType":       lOEAlphaType       = lblText;   break;
                                case "lOEAlphaType0Image": lOEAlphaType0Image = lblText;   break;
                                case "lOEAlphaType1Color": lOEAlphaType1Color = lblText;   break;
                                case "lOEAlphaType2Load":  lOEAlphaType2Load  = lblText;   break;
                                case "lOEAlphaType3Link":  lOEAlphaType3Link  = lblText;   break;
                                //
                                case "lOETabDotes":    lOETabDotes    = lblText;   break;
                                case "lOEDot":         lOEDot         = lblText;   break;
                                case "lOEDotName":     lOEDotName     = lblText;   break;
                                case "hOEDotMoveUp":   hOEDotMoveUp   = lblText;   break;
                                case "hOEDotMoveDown": hOEDotMoveDown = lblText;   break;
                                case "hOEDotAdd":      hOEDotAdd      = lblText;   break;
                                case "hOEDotSave":     hOEDotSave     = lblText;   break;
                                case "hOEDotDelete":   hOEDotDelete   = lblText;   break;
                                case "lOEDotLocation": lOEDotLocation = lblText;   break;
                            }
                            break;
                        #endregion

                        /*Link Options*/

                        #region Box Edit
                        case "BE":
                            switch (lblName)
                            {
                                case "lBEType":           lBEType           = lblText;   break;
                                case "lBEType0Text":      lBEType0Text      = lblText;   break;
                                case "lBEType1Rectangle": lBEType1Rectangle = lblText;   break;
                                case "lBEType2Ellipse":   lBEType2Ellipse   = lblText;   break;
                                case "lBEText":           lBEText           = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Element Options (share)
                        case "EO":
                            switch (lblName)
                            {
                                case "lEOTitle":           lEOTitle           = lblText;   break;
                                // Share
                                case "lEOName":            lEOName            = lblText;   break;
                                case "lEOReference":       lEOReference       = lblText;   break;
                                case "hEOGetReference":    hEOGetReference    = lblText;   break;
                                // +
                                case "hEOPrototypeDelete": hEOPrototypeDelete = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Object Options
                        case "OO":
                            switch (lblName)
                            {
                                case "hOOIPAdd":         hOOIPAdd         = lblText;   break;
                                case "hOOIPDelete":      hOOIPDelete      = lblText;   break;
                                // List
                                case "lOOColumIP":       lOOColumIP       = lblText;   break;
                                case "lOOColumPeriod":   lOOColumPeriod   = lblText;   break;
                                case "lOOColumTimeLast": lOOColumTimeLast = lblText;   break;
                                case "lOOColumTimeNext": lOOColumTimeNext = lblText;   break;
                                case "lOOColumPing":     lOOColumPing     = lblText;   break;
                            }
                            break;
                        #endregion

                        /*Link Options*/

                        #region Box Options
                        case "BO":
                            switch (lblName)
                            {
                                case "lBOText": lBOText = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Map Options
                        case "MO":
                            switch (lblName)
                            {
                                case "lMOTitle": lMOTitle = lblText;   break;
                                case "lMOName":  lMOName  = lblText;   break;
                                case "lMOSize":  lMOSize  = lblText;   break;
                                case "lMOAuto":  lMOAuto  = lblText;   break;
                                // List
                                case "lMOColumName":      lMOColumName      = lblText;   break;
                                case "lMOColumLocation":  lMOColumLocation  = lblText;   break;
                                case "lMOColumPrototype": lMOColumPrototype = lblText;   break;
                                case "lMOColumReference": lMOColumReference = lblText;   break;
                            }
                            break;
                        #endregion

                        #region IP Edit
                        case "IP":
                            switch (lblName)
                            {
                                case "lIPTitleAdd":  lIPTitleAdd  = lblText;   break;
                                case "lIPTitleEdit": lIPTitleEdit = lblText;   break;
                                case "lIPAddress":   lIPAddress   = lblText;   break;
                                case "lIPPeriod":    lIPPeriod    = lblText;   break;
                                case "lIPTimeOut":   lIPTimeOut   = lblText;   break;
                                case "lIPTimeNext":  lIPTimeNext  = lblText;   break;
                            }
                            break;
                        #endregion

                        #region Dialongs & About
                        default:
                            switch (lblName)
                            {
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
                            }
                            break;
                        #endregion
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
