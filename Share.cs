using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    static public class Share
    {
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
