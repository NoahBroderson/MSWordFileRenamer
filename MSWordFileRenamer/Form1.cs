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
        //TODO: SAVE LAST SELECTED FOLDER TO CONFIG FILE
        //TODO: LOG FILE RENAMES TO TEXT FILE OR DB WITH TIMES
        Renamer FileRenamer = new Renamer();
        List<WordFile> filesToRename = null;
        List<WordFile> renamedFiles = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string FolderToProcess = "";
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                folderBrowser.SelectedPath = txtFolderPath.Text;
                DialogResult result = folderBrowser.ShowDialog();

                if (string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    FolderToProcess = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                else
                {
                    FolderToProcess = folderBrowser.SelectedPath;
                    Properties.Settings.Default.FolderToProcess = FolderToProcess;
                    Properties.Settings.Default.Save();
                }

                txtFolderPath.Text = FolderToProcess;
                DisplaySourceFolderFiles(txtFolderPath.Text);
                btnRename.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void DisplaySourceFolderFiles(string folderToProcess)
        {
            try
            {
                lbFileList.Items.Clear();
                filesToRename = FileRenamer.GetFileList(folderToProcess);

                foreach (WordFile name in filesToRename)
                {
                    lbFileList.Items.Add(name);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                renamedFiles = FileRenamer.GetRenameResults(filesToRename);
                DisplayRenamedFiles(renamedFiles);
                DisplaySourceFolderFiles(txtFolderPath.Text);
                MessageBox.Show("Rename Complete!");
                btnCloseAll.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
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
            try
            {
                var FilesToCleanup = FileRenamer.GetFileList(txtFolderPath.Text);
                FileRenamer.CleanupFolder(filesToRename);
                DisplaySourceFolderFiles(txtFolderPath.Text);
                btnRename.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                FileRenamer.CloseWordDocs(renamedFiles);
                FileRenamer.CleanupFolder(renamedFiles);
                DisplaySourceFolderFiles(txtFolderPath.Text);
                renamedFiles.Clear();
                lbRenameResults.Items.Clear();
                btnRename.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtFolderPath.Text = Properties.Settings.Default.FolderToProcess;
        }
    }
}
