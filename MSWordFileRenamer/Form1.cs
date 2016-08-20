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

        private void btnRename_Click(object sender, EventArgs e)
        {
            string renameResult = "";
            for (int i = 0; i < lbFileList.Items.Count; i++)
            {
                string fileToRename = lbFileList.Items[0].ToString();
                renameResult = FileRenamer.GetRenameResults(fileToRename);
                lbFileList.Items.Remove(fileToRename); // (lbFileList.SelectedItem);
                DisplayResult(renameResult);
            }
            
            //string fileToRename = lbFileList.SelectedItem.ToString();
            //string renameResult = FileRenamer.GetRenameResults(fileToRename);
            //lbFileList.Items.Remove(lbFileList.SelectedItem);
            //DisplayResult(renameResult);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string folderToProcess = txtFolderPath.Text;
            filesToRename = FileRenamer.GetFileList(folderToProcess);
            DisplayFiles(filesToRename);
        }

        private void DisplayFiles(List<string> filesToRename)
        {
            foreach (string name in filesToRename)
            {
                lbFileList.Items.Add(name);
            }
        }
    }
}
