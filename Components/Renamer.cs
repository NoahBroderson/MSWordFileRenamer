using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Threading;

namespace MSWordFileRenamer
{

    public class Renamer
    {
        public  string GetRenameResults(string fileToRename)
        {
            var filesToRename = new List<string>{fileToRename};
            return GetRenameResults(filesToRename)[0];
        }

        public List<string> GetRenameResults(List<string> filesToRename)
        {
            List<string> SavedAsFiles = new List<string>();

            Application Word = new Application();
            Word.Visible = true;

            foreach (string file in filesToRename)
            {
                //Word.Documents
                Document Document = Word.Documents.Open(file);
            }

            foreach (string file in filesToRename)
            {
                try
                {
                    Document CurrentDocument = Word.Documents[file];
                    string SavedAsName = file.Replace(".", "_z.");
                    CurrentDocument.SaveAs(SavedAsName);
                    SavedAsFiles.Add(SavedAsName);
                    //CurrentDocument.Close(false);
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
            
            return SavedAsFiles;
        }

        public List<string> GetFileList(string folderToProcess)
        {
            //testing only
            //folderToProcess = "C:\\RenamerTests\\StaticFiles";
            //folderToProcess = "M:\\RenamerTests\\StaticFiles";
            if (Directory.Exists(folderToProcess))
            {
                try
                {
                    List<string> fileList = new List<string>(Directory.GetFiles(folderToProcess));

                    return fileList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("Folder Not Found!");
            }
        }
    }
}
