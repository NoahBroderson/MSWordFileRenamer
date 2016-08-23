using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSWordFileRenamer
{
    public partial class frmMain : Form
    {
        Renamer FileRenamer = new Renamer();
        List<WordFile> filesToRename = null;
        List<WordFile> renamedFiles = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.SelectedPath = txtFolderPath.Text;
            DialogResult result = folderBrowser.ShowDialog();

            if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                txtFolderPath.Text = folderBrowser.SelectedPath;
            }

            DisplaySourceFolderFiles();
        }

        private void DisplaySourceFolderFiles()
        {
            lbFileList.Items.Clear();
            string folderToProcess = txtFolderPath.Text;
            filesToRename = FileRenamer.GetFileList(folderToProcess);
            foreach (WordFile name in filesToRename)
            {
                lbFileList.Items.Add(name);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            renamedFiles = FileRenamer.GetRenameResults(filesToRename);
            DisplayRenamedFiles(renamedFiles);
            DisplaySourceFolderFiles();
            MessageBox.Show("Rename Complete!");
        }

        public void DisplayRenamedFiles(List<WordFile> renameResults)
        {
            foreach (WordFile result in renameResults)
            {
                lbRenameResults.Items.Add(result);
            }
        }

        private void btnCleanUp_Click(object sender, EventArgs e)
        {
            var FilesToCleanup = FileRenamer.GetFileList(txtFolderPath.Text);
            FileRenamer.CleanupFolder(filesToRename);
            DisplaySourceFolderFiles();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            FileRenamer.CloseWordDocs(renamedFiles);
            FileRenamer.CleanupFolder(renamedFiles);
            DisplaySourceFolderFiles();
            renamedFiles.Clear();
            lbRenameResults.Items.Clear();
        }
    }
}
