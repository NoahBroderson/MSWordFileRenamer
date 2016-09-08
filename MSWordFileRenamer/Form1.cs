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
        //TODO: ReWrite with better object model, Know/Decide/Do + more events
        //ToDo: Add choice of close after rename
        //ToDo: Add choice to open without rename
        //ToDo: Add Results prompt to append to log after test

        Renamer FileRenamer;
        List<WordFile> filesToRename = null;
        List<WordFile> renamedFiles = null;
        Logger LogFile;

        public frmMain()
        {
            InitializeComponent();
            ControlsEnabled(false);
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
                FileRenamer = new Renamer(FolderToProcess);
                FileRenamer.FileRenamed += OnRenamed;
                FileRenamer.FileProcessed += OnFileProcessed;
                DisplaySourceFolderFiles(txtFolderPath.Text);
                ControlsEnabled(false);
                btnNewTest.Enabled = true;
                btnNewTest.Focus();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void OnRenamed(object sender, RenamerEventArgs args)
        {
            string RenameResult = string.Format("File Renamed - {0}:    {1}", args.File, args.ElapsedTime);
            lbRenameResults.Items.Add(RenameResult);
            LogFile.WriteEntry(RenameResult);
        }

        public void OnFileProcessed(object sender, RenamerEventArgs args)
        {
            string ProcessResult = string.Format("File {0} {1}: {2}", args.File, args.ActionTaken, args.ElapsedTime);
            lbRenameResults.Items.Add(ProcessResult);
            LogFile.WriteEntry(ProcessResult);
        }

        private void DisplaySourceFolderFiles(string folderToProcess)
        {
            try
            {
                lbFileList.Items.Clear();
                //lbRenameResults.Items.Clear();
                //FileRenamer = new Renamer(folderToProcess);
                filesToRename = FileRenamer.GetFileList();
                
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


                //FileRenamer.RenameFiles(filesToRename);
                FileRenamer.ProcessFiles(filesToRename, chkRename.Checked, chkCloseAfter.Checked);

                //DisplayRenamedFiles(renamedFiles);
                DisplaySourceFolderFiles(txtFolderPath.Text);
                MessageBox.Show("Rename Complete!");
                
                //btnCloseAll.Focus();
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
                var FilesToCleanup = FileRenamer.GetFileList();
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
               // FileRenamer.CleanupFolder(renamedFiles);
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
            LogFile.LogFolder = Properties.Settings.Default.FolderToProcess;

        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            if (LogFile == null)
            {
                LogFile = new Logger(txtFolderPath.Text);
            }

            if (System.IO.File.Exists(LogFile.FullName))
            {
                System.Diagnostics.Process.Start(System.IO.Path.Combine(LogFile.LogFolder, Environment.MachineName + ".txt"));
            }
            else
            {
                MessageBox.Show("Log file not available.");
            }
            
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            LogFile = new Logger(txtFolderPath.Text);

            LogFile.LogFolder = txtFolderPath.Text;
            LogFile.WriteTestHeader(txtTestDesc.Text);
            ControlsEnabled(true);
        }

        private void ControlsEnabled(bool YesNo)
        {
            
            btnRename.Enabled = YesNo;
            chkRename.Enabled = YesNo;
            chkCloseAfter.Enabled = YesNo;
            btnNewTest.Enabled = YesNo;

        }
    }
}
