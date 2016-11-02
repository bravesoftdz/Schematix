﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
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
            if (dlgFolder.ShowDialog() == DialogResult.OK)
                tb.Text = dlgFolder.SelectedPath;
            else
                return false;
            return true;
        }

        static public bool GetFile(TextBox tb)//Ok
        {
            var dlgOpen = new OpenFileDialog();
            if (tb.Text == "")
                dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dlgOpen.InitialDirectory = Path.GetDirectoryName(tb.Text);
            dlgOpen.FileName = Path.GetFileName(tb.Text);
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                tb.Text = dlgOpen.FileName;
            else
                return false;
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
            if (lvIPs == null)
                return;
            if (IP == null)
                return;
            var ip_item = new ListViewItem("");
            ip_item.SubItems.Add("");
            ip_item.SubItems.Add("");
            ip_item.SubItems.Add("");
            ip_item.SubItems.Add("");
            lvIPs.Items.Add(ip_item);
            ip_item.Tag = IP;
            target_lvItem = ip_item;
            lvIPs_Renew(target_lvItem, IP);
        }

        static public void lvIPs_Renew(ListViewItem lvItem, xIP IP)//Ok
        {
            if (IP == null)
                return;
            if (lvItem == null)
                return;
            lvItem.Text = IP.Address;
            lvItem.Checked = IP.Onn;
            lvItem.SubItems[0].Text = IP.Period.ToString();
            if (IP.Pings[0].TripTime < 0)
                lvItem.SubItems[1].Text = "-";
            else
                lvItem.SubItems[1].Text = IP.TimeLast.ToString(Options.TIME_FORMAT);
            lvItem.SubItems[2].Text = IP.TimeNext.ToString(Options.TIME_FORMAT);
            String s = "";
            foreach (var ping in IP.Pings)
                if (ping.TripTime < 0)
                    break;
                else if (ping.TripTime < IP.TimeOutGreen)
                    s += "G";
                else if (ping.TripTime < IP.TimeOutYellow)
                    s += "Y";
                else if (ping.TripTime < IP.TimeOutRed)
                    s += "R";
                else
                    s += "-";
            s += "";
            if (s == "")
                s = "-";
            else
                s = IP.Pings[0] + "ms [" + s + "]";
            lvItem.SubItems[3].Text = s;
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
            if (lvIPs == null)
                return;
            for (int i = lvIPs.SelectedItems.Count - 1; 0 <= i; i--)
                (lvIPs.SelectedItems[i].Tag as xIP)?.Delete();
        }

        static public ListViewItem lvPings_Add(ListView lvPings, xIP IP, xPing Ping)//Ok
        {
            if (lvPings == null)
                return null;
            if (Ping == null)
                return null;
            var ping_item = new ListViewItem("");
            ping_item.SubItems.Add("");
            ping_item.SubItems.Add("");
            ping_item.SubItems.Add("");
            lvPings.Items.Add(ping_item);
            ping_item.Tag = Ping;
            lvPings_Renew(ping_item, IP, Ping);
            return ping_item;
        }

        static public void lvPings_Renew(ListViewItem lvItem, xIP IP, xPing Ping)//Ok
        {
            if (lvItem == null)
                return;
            if (Ping == null)
                return;
            lvItem.Text = Ping.SendTime.ToString(Options.TIME_FORMAT);
            lvItem.SubItems[0].Text = Ping.Replayer.ToString();
            if (Ping.State == PingStates.Send)
                lvItem.SubItems[1].Text = Options.LangCur.lIPPingSend;
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
                else if (Ping.TripTime < IP.TimeOutYellow)
                    lvItem.ImageIndex = 2;
                else if (Ping.TripTime < IP.TimeOutRed)
                    lvItem.ImageIndex = 3;
                else
                    lvItem.ImageIndex = 4;
            }
        }

        static public void UpdateNodeName(xPrototype prototype)
        {
            if(prototype.tvNode != null)
                prototype.tvNode.Text = (prototype.NodeName != "") ? prototype.NodeName : prototype.Name;
        }
    }
}
