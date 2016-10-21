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

        public delegate void GetImageCallBack(Image img);

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
    }
}
