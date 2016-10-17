using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LibraryForm : Form
    {
        public LibraryForm()
        {
            InitializeComponent();
        }

        private void LibraryForm_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            e.Cancel = true;
            Hide();
        }

        #region Catalog
        private void tpObjects_Enter(object sender, EventArgs e)
        {
            lvObjects.Visible = true;
            lvLinks.Visible =
            lvBoxes.Visible = false;
            CatalogButtons_Check(tvObjects.Tag);
            UsedButtons_Check(lvObjects.Tag);
        }

        private void tpLinks_Enter(object sender, EventArgs e)
        {
            lvLinks.Visible = true;
            lvObjects.Visible =
            lvBoxes.Visible = false;
            CatalogButtons_Check(tvLinks.Tag);
            UsedButtons_Check(lvLinks.Tag);
        }

        private void tpBoxes_Enter(object sender, EventArgs e)
        {
            lvBoxes.Visible = true;
            lvObjects.Visible =
            lvLinks.Visible = false;
            CatalogButtons_Check(tvBoxes.Tag);
            UsedButtons_Check(lvBoxes.Tag);
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            (sender as TreeView).Tag = (sender as TreeView).SelectedNode/*?.Tag*/;
            CatalogButtons_Check((sender as TreeView).Tag);
        }

        private void CatalogButtons_Check(object o)
        {
            tcCatalog.Tag = o;
            btnAdd.Enabled =
            btnEdit.Enabled = (o != null);
        }
        #endregion

        #region Used on map
        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            (sender as ListView).Tag = null;
            if (0 < (sender as ListView).SelectedItems.Count)
                (sender as ListView).Tag = (sender as ListView).SelectedItems[0]/*.Tag*/;
            UsedButtons_Check((sender as ListView).Tag);
        }

        private void UsedButtons_Check(object o)
        {
            btnUsedEdit.Tag = o;
            btnUsedEdit.Enabled = (o != null);
        }
        #endregion
    }
}
