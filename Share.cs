using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Schematix
{
    static public class Share
    {
        static public void StreamImageIn(BinaryWriter stream, Bitmap image, ImageBPPs BPP)
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
            var imageData = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), ImageLockMode.ReadOnly, bmap.PixelFormat);
            int bytes = Math.Abs(imageData.Stride) * imageData.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(imageData.Scan0, buffer, 0, bytes);
            bmap.UnlockBits(imageData);
            // Write
            stream.Write(6 + bytes);
            stream.Write(image.Width);
            stream.Write(image.Height);
            stream.Write((int)pFormat);
            stream.Write(buffer);
        }

        static public Bitmap StreamImageOut(BinaryReader stream, int bytes, ref ImageBPPs BPP)
        {
            BPP = ImageBPPs.b32argb;
            var image = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            if (bytes < 7)
            {
                stream.ReadBytes(bytes);
                return image;
            }
            int w;
            int h;
            PixelFormat pFormat;
            byte[] buffer = new byte[bytes - 6];
            // Read data
            w = stream.ReadInt32();
            h = stream.ReadInt32();
            pFormat = (PixelFormat)stream.ReadInt32();
            buffer = stream.ReadBytes(bytes - 6);
            // Transfer
            var bmap = new Bitmap(w, h, pFormat);
            var imageData = bmap.LockBits(new Rectangle(0, 0, bmap.Width, bmap.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            Marshal.Copy(buffer, 0, imageData.Scan0, bytes);
            bmap.UnlockBits(imageData);
            // Return
            image = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(image);
            graphics.DrawImageUnscaled(bmap, 0, 0);
            // BPP
            if (pFormat == PixelFormat.Format24bppRgb)      BPP = ImageBPPs.b24rgb;
            if (pFormat == PixelFormat.Format16bppArgb1555) BPP = ImageBPPs.b16a1r5g5b5;
            if (pFormat == PixelFormat.Format16bppRgb565)   BPP = ImageBPPs.b16r5g6b5;
            if (pFormat == PixelFormat.Format8bppIndexed)   BPP = ImageBPPs.b8;
            if (pFormat == PixelFormat.Format4bppIndexed)   BPP = ImageBPPs.b4;
            return image;
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
                        options.LangCur.mErrorsOccurred + "\r\n" + ex.Message + "\r\n" + tb.Text,
                        options.LangCur.dImageLoading);
                    return false;
                }
            return true;
        }

        static public void lvIPs_AddIP(ListView lvIPs, xIP IP)//Ok
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
            IP.lvItem = ip_item;
            lvIPs_RenewIP(IP);
        }

        static public void lvIPs_RenewIP(xIP IP)//Ok
        {
            if (IP == null)
                return;
            if (IP.lvItem == null)
                return;
            IP.lvItem.Text = IP.Address;
            IP.lvItem.Checked = IP.Onn;
            IP.lvItem.SubItems[0].Text = IP.Period.ToString();
            if (IP.PingTimeArray[0] < 0)
                IP.lvItem.SubItems[1].Text = "-";
            else
                IP.lvItem.SubItems[1].Text = IP.TimeLast.ToString(options.TIME_FORMAT);
            IP.lvItem.SubItems[2].Text = IP.TimeNext.ToString(options.TIME_FORMAT);
            String s = "";
            foreach (var ping in IP.PingTimeArray)
                if (ping < 0)
                    break;
                else if (ping < IP.TimeOutGreen)
                    s += "G";
                else if (ping < IP.TimeOutYellow)
                    s += "Y";
                else if (ping < IP.TimeOutRed)
                    s += "R";
                else
                    s += "-";
            s += "";
            if (s == "")
                s = "-";
            else
                s = IP.PingTimeArray[0] + "ms [" + s + "]";
            IP.lvItem.SubItems[3].Text = s;
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
            lvIPs_RenewIP(ip);
        }

        static public void lvIPs_Delete(ListView lvIPs)//Ok
        {
            if (lvIPs == null)
                return;
            for (int i = lvIPs.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvIPs.SelectedItems[i].Tag as xIP)?.Delete();
                lvIPs.Items.RemoveAt(i);
            }
        }
    }
}
