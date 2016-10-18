using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    static public class Share
    {
        public delegate void GetImageCallBack(Image img);

        static public void GetImage(TextBox tb, GetImageCallBack callBack)
        {
            var dlgOpen = new OpenFileDialog();
            if (tb.Text == "")
                dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dlgOpen.InitialDirectory = Path.GetDirectoryName(tb.Text);
            dlgOpen.FileName = Path.GetFileName(tb.Text);
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                try
                {
                    var image = new Bitmap(dlgOpen.FileName);
                    tb.Text = dlgOpen.FileName;
                    // Return control
                    callBack?.Invoke(image);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        options.LangCur.mErrorsOccurred + "\r\n" + ex.Message + "\r\n" + dlgOpen.FileName,
                        options.LangCur.dImageLoading);
                }
        }
    }
}
