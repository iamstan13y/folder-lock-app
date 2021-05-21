using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Folder_Lock_2._0
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void closePanels()
        {
            pnlLock.Visible = false;
            pnlDriveIcon.Visible = false;
            pnlHide.Visible = false;
            pnlSec.Visible = false;
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            closePanels();
            pnlLock.Visible = true;
        }

        private void btnChangeIco_Click(object sender, EventArgs e)
        {
            closePanels();
            pnlDriveIcon.Visible = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            closePanels();
            pnlHide.Visible = true;
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            closePanels();
            pnlSec.Visible = true;
        }

        private void btnLockFolder_Click(object sender, EventArgs e)
        {
            folderLock.Lock(txtFolderPath.text);
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.text = folderBrowser.SelectedPath;
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            folderLock.Unlock(txtFolderPath.text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                txtSelectFile.text = fileBrowser.FileName;
            }
        }

        private void btnHideFolder_Click(object sender, EventArgs e)
        {
            folderLock.Hide(txtSelectFile.text);
        }

        private void btnRtrv_Click(object sender, EventArgs e)
        {
            folderLock.Unhide(txtSelectFile.text);
        }
    }
}
