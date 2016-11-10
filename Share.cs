using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    static public class Share
    {
        static public void StreamPutImage(BinaryWriter stream, Bitmap image, ImageBPPs BPP)
        {
            // BPP
            var pFormat = PixelFormat.Format32bppArgb;
            if (BPP == ImageBPPs.b24rgb)      pFormat = PixelFormat.Format24bppRgb;
            if (BPP == ImageBPPs.b16a1r5g5b5) pFormat = PixelFormat.Format16bppArgb1555;
            if (BPP == ImageBPPs.b16r5g6b5)   pFormat = PixelFormat.Format16bppRgb565;
            if (BPP == ImageBPPs.b8)          pFormat = PixelFormat.Format8bppIndexed;
            if (BPP == ImageBPPs.b4)          pFormat = PixelFormat.Format4bppIndexed;
            // Prepare
            var bmap = new Bitmap(image.Width, image.Height, pFormat);
            var graphics = Graphics.FromImage(bmap);
            graphics.DrawImageUnscaled(image, 0,0);
            // Get data
            using (MemoryStream ms = new MemoryStream())
            {
                bmap.Save(ms, ImageFormat.Bmp);
                // Write
                stream.Write((int)ms.Length + 4);
                stream.Write((int)pFormat);
                stream.Write(ms.ToArray());
            }
        }

        static public bool StreamGetImage(BinaryReader stream, int bytes, ref ImageBPPs BPP, ref Bitmap image)
        {
            if (bytes < 4)
            {
                stream.ReadBytes(bytes);
                return false;
            }
            // BPP
            BPP = ImageBPPs.b32argb;
            PixelFormat pFormat = (PixelFormat)stream.ReadInt32();
            if (pFormat == PixelFormat.Format24bppRgb)      BPP = ImageBPPs.b24rgb;
            if (pFormat == PixelFormat.Format16bppArgb1555) BPP = ImageBPPs.b16a1r5g5b5;
            if (pFormat == PixelFormat.Format16bppRgb565)   BPP = ImageBPPs.b16r5g6b5;
            if (pFormat == PixelFormat.Format8bppIndexed)   BPP = ImageBPPs.b8;
            if (pFormat == PixelFormat.Format4bppIndexed)   BPP = ImageBPPs.b4;
            // Read data
            Bitmap bmap;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(stream.ReadBytes(bytes - 4), 0, bytes - 4);
                bmap = new Bitmap(ms);
            }
            // Return
            image = new Bitmap(bmap.Width, bmap.Height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(image).DrawImageUnscaled(bmap, 0, 0);
            return true;
        }

        public delegate void GetImageCallBack(Bitmap img);

        static public bool GetFolder(TextBox tb)//Ok
        {
            var dlgFolder = new FolderBrowserDialog();
            if (tb.Text == "")
                tb.Text = Directory.GetCurrentDirectory();
            dlgFolder.SelectedPath = tb.Text;
            if (dlgFolder.ShowDialog() != DialogResult.OK)
                return false;
            tb.Text = dlgFolder.SelectedPath;
            return true;
        }

        static public bool GetFile(TextBox tb)//Ok
        {
            var dlgOpen = new OpenFileDialog();
            if (tb.Text == "")
                tb.Text = Directory.GetCurrentDirectory();
            dlgOpen.InitialDirectory = Path.GetDirectoryName(tb.Text);
            dlgOpen.FileName = Path.GetFileName(tb.Text);
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return false;
            tb.Text = dlgOpen.FileName;
            return true;
        }

        static public bool GetImage(TextBox tb, GetImageCallBack callBack)//Ok
        {
            if (GetFile(tb))
                try
                {
                    callBack?.Invoke(new Bitmap(tb.Text)); // Try to load and return control
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        Options.LangCur.mErrorsOccurred + "\r\n" + ex.Message + "\r\n" + tb.Text,
                        Options.LangCur.dImageLoading);
                    return false;
                }
            return true;
        }

        static public void lvIPs_Add(ListView lvIPs, xIP IP, ref ListViewItem target_lvItem)//Ok
        {
            if (lvIPs == null || IP == null)
                return;
            target_lvItem = lvIPs.Items.Add("");
            target_lvItem.SubItems.Add("");
            target_lvItem.SubItems.Add("");
            target_lvItem.SubItems.Add("");
            target_lvItem.SubItems.Add("");
            lvIPs_Renew(target_lvItem, IP);
            target_lvItem.Tag = IP;
        }

        static public void lvIPs_Renew(ListViewItem lvItem, xIP IP)//Ok
        {
            if (IP == null || lvItem == null)
                return;
            lvItem.Checked = IP.Onn;
            lvItem.SubItems[0].Text = IP.Address;
            lvItem.SubItems[1].Text = IP.Period.ToString();
            lvItem.SubItems[2].Text = IP.TimeNext.ToString(Options.TIME_FORMAT);
            lvItem.SubItems[3].Text = "-//-";
            lvItem.SubItems[4].Text = "-//-";
            lvItem.ImageIndex = 0;
            if (IP.Pings[0] == null)
                return;
            if (IP.Pings[0].State != PingStates.NotSend)
            {
                lvItem.SubItems[3].Text = IP.TimeLast.ToString(Options.TIME_FORMAT);
                if (IP.Pings[0].State == PingStates.Send)
                {
                    lvItem.SubItems[4].Text = Options.LangCur.lIPPingSend;
                    lvItem.ImageIndex = 0;
                }
                else if (IP.Pings[0].State == PingStates.Cancelled)
                {
                    lvItem.SubItems[4].Text = Options.LangCur.lIPPingCancelled;
                    lvItem.ImageIndex = 5;
                }
                else if (IP.Pings[0].Error != "")
                {
                    lvItem.SubItems[4].Text = IP.Pings[0].Error;
                    lvItem.ImageIndex = 5;
                }
                else
                {
                    lvItem.SubItems[4].Text = IP.Pings[0].TripTime.ToString() + " (" + IP.Pings[0].Replayer + ")";
                    if (IP.Pings[0].TripTime < IP.TimeOutGreen)
                        lvItem.ImageIndex = 1;
                    else if (IP.Pings[0].TripTime < IP.TimeOutGreen + IP.TimeOutYellow)
                        lvItem.ImageIndex = 2;
                    else if (IP.Pings[0].TripTime < IP.TimeOutGreen + IP.TimeOutYellow + IP.TimeOutRed)
                        lvItem.ImageIndex = 3;
                    else
                        lvItem.ImageIndex = 4;
                }
            }
        }

        static public void lvIPs_Edit(ListView lvIPs)//Ok
        {
            if (lvIPs == null)
                return;
            if (lvIPs.SelectedItems.Count < 1)
                return;
            xIP ip = (lvIPs.SelectedItems[0].Tag as xIP);
            if (ip == null)
                return;
            new IPEditForm(ip, null).ShowDialog();
            lvIPs_Renew(ip.Obj_lvItem, ip);
            lvIPs_Renew(ip.Map_lvItem, ip);
        }

        static public void lvIPs_Delete(ListView lvIPs)//Ok
        {
            if (lvIPs != null)
                for (int i = lvIPs.SelectedItems.Count - 1; 0 <= i; i--)
                    (lvIPs.SelectedItems[i].Tag as xIP)?.Delete();
        }

        static public void lvPings_Add(ListView lvPings, xIP IP, xPing Ping)//Ok
        {
            if (lvPings == null || Ping == null)
                return;
            var ping_item = lvPings.Items.Insert(0, "");
            ping_item.SubItems.Add("");
            ping_item.SubItems.Add("");
            ping_item.SubItems.Add("");
            if (IP.PingsCount < lvPings.Items.Count)
                lvPings.Items.RemoveAt(IP.PingsCount);
            lvPings_Renew(ping_item, IP, Ping);
            ping_item.Tag = Ping;
        }

        static public void lvPings_Renew(ListViewItem lvItem, xIP IP, xPing Ping)//Ok
        {
            if (lvItem == null || Ping == null)
                return;
            lvItem.SubItems[0].Text = Ping.SendTime.ToString(Options.TIME_FORMAT);
            lvItem.SubItems[2].Text = "";
            if (Ping.State == PingStates.Send)
            {
                lvItem.SubItems[1].Text = Options.LangCur.lIPPingSend;
                lvItem.ImageIndex = 0;
            }
            else if (Ping.State == PingStates.Cancelled)
            {
                lvItem.SubItems[1].Text = Options.LangCur.lIPPingCancelled;
                lvItem.ImageIndex = 5;
            }
            else if (Ping.Error != "")
            {
                lvItem.SubItems[1].Text = Ping.Error;
                lvItem.ImageIndex = 5;
            }
            else
            {
                lvItem.SubItems[1].Text = Ping.Replayer;
                lvItem.SubItems[2].Text = Ping.TripTime.ToString();
                if (Ping.TripTime < IP.TimeOutGreen)
                    lvItem.ImageIndex = 1;
                else if (Ping.TripTime < IP.TimeOutGreen + IP.TimeOutYellow)
                    lvItem.ImageIndex = 2;
                else if (Ping.TripTime < IP.TimeOutGreen + IP.TimeOutYellow + IP.TimeOutRed)
                    lvItem.ImageIndex = 3;
                else
                    lvItem.ImageIndex = 4;
            }
        }

        static public void Library_UpdateNodeName(xPrototype prototype)//
        {
            if (prototype.tvNode != null)
                prototype.tvNode.Text = (prototype.NodeName != "") ? prototype.NodeName : prototype.Name;
            if (prototype.lvItemUsed != null)
            {
                prototype.lvItemUsed.Text = (prototype.NodeName != "") ? prototype.NodeName : prototype.Name;
                if (prototype.IsObject)
                    prototype.lvItemUsed.SubItems[1].Text = (Options.PObjects.Exists(PO => (PO.ID == prototype.ID) && (PO.Revision == prototype.Revision))) ? "Catalog" : "Map";
                if (prototype.IsLink)
                    prototype.lvItemUsed.SubItems[1].Text = (Options.PLinks.Exists  (PL => (PL.ID == prototype.ID) && (PL.Revision == prototype.Revision))) ? "Catalog" : "Map";
                if (prototype.IsBox)
                    prototype.lvItemUsed.SubItems[1].Text = (Options.PBoxes.Exists  (PB => (PB.ID == prototype.ID) && (PB.Revision == prototype.Revision))) ? "Catalog" : "Map";
            }
        }

        static public void DrawBack(Graphics graphics, xBackground Back, xGrid Grid, int drawX, int drawY, int drawW, int drawH, int portX, int portY, int portW, int portH)//Ok
        {
            graphics.Clear(Back.Color);

            int iX, startX, endX,
                iY, startY, endY;

            #region Backgruond
            int imgW = Back.Image.Width,
                imgH = Back.Image.Height;

            switch (Back.Style)
            {
                case BackgroundStyles.Color:
                    // Skip
                    break;

                case BackgroundStyles.ImageAlign:
                    graphics.DrawImageUnscaled(Back.Image,
                        drawX + (portW - imgW) * ((int)Back.Align % 3) / 2,
                        drawY + (portH - imgH) * ((int)Back.Align / 3) / 2);
                    break;

                case BackgroundStyles.ImageTile:
                    int imgOffsetX = 0,
                        imgOffsetY = 0;
                    // Align offset strength/2 -> [0, 0.5, 1]
                    int imgOffsetNX = (int)Back.Align % 3,
                        imgOffsetNY = (int)Back.Align / 3;
                    // Calculate align offset X (Center/Right)
                    if (0 < imgOffsetNX)
                        imgOffsetX = (imgOffsetNX < 2)
                            ? ((portW + imgW) % (imgW * 2)) / 2
                            : portW % imgW;
                    // Calculate align offset Y (Middle/Bottom)
                    if (0 < imgOffsetNY)
                        imgOffsetY = (imgOffsetNY < 2)
                            ? ((portH + imgH) % (imgH * 2)) / 2
                            : portH % imgH;
                    // Calculate first cell
                    startX = (drawX - imgW + 1 - imgOffsetX) / imgW;
                    startY = (drawY - imgH + 1 - imgOffsetY) / imgH;
                    endX = (drawX + drawW - 1 - imgOffsetX) / imgW;
                    endY = (drawY + drawH - 1 - imgOffsetY) / imgH;
                    // Colum/row oscillation for float style
                    portX = portX % imgW + imgOffsetX;
                    portY = portY % imgH + imgOffsetY;
                    // Fill
                    for (iY = startY; iY <= endY; iY++)
                        for (iX = startX; iX <= endX; iX++)
                            graphics.DrawImageUnscaled(Back.Image,
                                portX + iX * imgW,
                                portY + iY * imgH);
                    break;/**/

                case BackgroundStyles.ImageStrech:
                    graphics.DrawImage(Back.Image, portX, portY, portW, portH);
                    break;

                case BackgroundStyles.ImageZInner:
                case BackgroundStyles.ImageZOutter:
                    int imgZW,
                        imgZH;
                    // Find most "tight" side
                    if ((imgH * portW <= imgW * portH) == (Back.Style == BackgroundStyles.ImageZInner))
                    {
                        imgZW = portW;
                        imgZH = (int)(imgH * ((double)portW / imgW));
                    }
                    else
                    {
                        imgZW = (int)(imgW * ((double)portH / imgH));
                        imgZH = portH;
                    }
                    graphics.DrawImage(Back.Image,
                        (portW - imgZW) * ((int)Back.Align % 3) / 2,
                        (portH - imgZH) * ((int)Back.Align / 3) / 2,
                        imgZW, imgZH);
                    break;
            }
            #endregion

            #region Grid
            startX = drawX / Grid.StepX;
            startY = drawY / Grid.StepY;
            endX = (drawX + drawW) / Grid.StepX;
            endY = (drawY + drawH) / Grid.StepY;
            switch (Grid.Style)
            {
                case GridStyles.None:
                    // Skip
                    break;

                case GridStyles.Dots:
                    var brush = new SolidBrush(Grid.Pen.Color);
                    for (iY = startY; iY <= endY; iY++)
                        for (iX = startX; iX <= endX; iX++)
                            graphics.FillRectangle(brush,
                                iX * Grid.StepX, iY * Grid.StepY,
                                Grid.Pen.Width, Grid.Pen.Width);
                    break;

                case GridStyles.Corners:
                    int halfW = Grid.StepX / 2,
                        halfH = Grid.StepY / 2;
                    for (iY = startY; iY <= endY; iY++)
                        for (iX = startX; iX <= endX; iX++)
                        {
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX,         iY * Grid.StepY,
                                iX * Grid.StepX + halfW, iY * Grid.StepY);
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX,         iY * Grid.StepY,
                                iX * Grid.StepX,         iY * Grid.StepY + halfH);
                        }
                    break;

                case GridStyles.Crosses:
                    int quadW = Grid.StepX / 4,
                        quadH = Grid.StepY / 4;
                    for (iY = startY; iY <= endY; iY++)
                        for (iX = startX; iX <= endX; iX++)
                        {
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX - quadW, iY * Grid.StepY,
                                iX * Grid.StepX + quadW, iY * Grid.StepY);
                            graphics.DrawLine(Grid.Pen,
                                iX * Grid.StepX, iY * Grid.StepY - quadH,
                                iX * Grid.StepX, iY * Grid.StepY + quadH);
                        }
                    break;

                case GridStyles.Grid:
                    for (iX = startX; iX <= endX; iX++)
                        graphics.DrawLine(Grid.Pen, iX * Grid.StepX, drawY, iX * Grid.StepX, drawY + drawH);
                    for (iY = startY; iY <= endY; iY++)
                        graphics.DrawLine(Grid.Pen, drawX, iY * Grid.StepY, drawX + drawW, iY * Grid.StepY);
                    break;
            }
            #endregion
        }

        static public Bitmap GetEmptyImage()
        {
            return new Bitmap(1, 1);
        }

        static public Bitmap GetNoImage()//Ok
        {
            var bmap = new Bitmap(16, 16);
            var g = Graphics.FromImage(bmap);
            g.Clear(Color.FromArgb(0,0,0,0));
            g.DrawRectangle(Pens.Red, 0, 0, 15, 15);
            g.DrawLine(Pens.Red, 0, 0, 15, 15);
            g.DrawLine(Pens.Red, 0, 15, 15, 0);
            return bmap;
        }

        static public Bitmap GetDotImage()//Ok
        {
            var bmap = new Bitmap(7, 7);
            var g = Graphics.FromImage(bmap);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.FillRectangle(Brushes.Brown, 1, 1, 5, 5);
            Point[] points =
            {
                new Point(2, 0),
                new Point(4, 0),
                new Point(6, 2),
                new Point(6, 4),
                new Point(4, 6),
                new Point(2, 6),
                new Point(0, 4),
                new Point(0, 2),
                new Point(2, 0)
            };
            g.DrawLines(Pens.Black, points);
            return bmap;
        }
    }
}
