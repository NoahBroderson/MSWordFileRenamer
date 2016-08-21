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
        List<string> filesToRename = null;


        public frmMain()
        {
            InitializeComponent();
            Renamer FileRenamer = new Renamer();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            
            DisplaySourceFolderFiles();
        }

        private void DisplaySourceFolderFiles()
        {
            lbFileList.Items.Clear();
            lbRenameResults.Items.Clear();
            string folderToProcess = txtFolderPath.Text;
            filesToRename = FileRenamer.GetFileList(folderToProcess);
            foreach (string name in filesToRename)
            {
                lbFileList.Items.Add(name);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            //Single file renaming
            //string renameResult = "";
            //for (int i = 0; i < lbFileList.Items.Count; i++)
            //{
            //    string fileToRename = lbFileList.Items[0].ToString();
            //    renameResult = FileRenamer.GetRenameResults(fileToRename);
            //    lbFileList.Items.Remove(fileToRename); // (lbFileList.SelectedItem);
            //    DisplayResult(renameResult);
            //}

            //string fileToRename = lbFileList.SelectedItem.ToString();
            //string renameResult = FileRenamer.GetRenameResults(fileToRename);
            //lbFileList.Items.Remove(lbFileList.SelectedItem);
            //DisplayResult(renameResult);

            var _renameResults = FileRenamer.GetRenameResults(filesToRename);
            DisplayResults(_renameResults);
        }

        public void DisplayResult(string renameResult)
        {
            lbRenameResults.Items.Add(renameResult);
        }


        public void DisplayResults(List<string> renameResults)
        {
            foreach (string result in renameResults)
            {
                lbRenameResults.Items.Add(result);
            }
        }

        private void btnCleanUp_Click(object sender, EventArgs e)
        {
            foreach (string file in lbFileList.Items)
            {
               if (file.IndexOf("_z") != -1)
                {
                    System.IO.File.Delete(file);
                }
            }

            DisplaySourceFolderFiles();
        }
    }
}
