﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Threading;

namespace MSWordFileRenamer
{
    public class Renamer
    {
        public Application Word { get; set; }

        public List<WordFile> GetRenameResults(List<WordFile> filesToRename)
        {
            var SavedAsFiles = new List<WordFile>();

            try
            {
                Word = new Application();
                Word.Visible = true;

                foreach (WordFile file in filesToRename)
                {
                    //Word.Documents
                    Document Document = Word.Documents.Open(file.FullFileName);
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error opening Word documents", error);
            }

            foreach (WordFile file in filesToRename)
            {
                try
                {
                    Document CurrentDocument = Word.Documents[file.FullFileName];
                    string SavedAsName = file.FullFileName.Replace(".", "_z.");
                    CurrentDocument.SaveAs(SavedAsName);
                    SavedAsFiles.Add(new WordFile(SavedAsName));
                    //CurrentDocument.Close(false);
                }
                catch (Exception error)
                {
                    throw new Exception("Error renaming Word documents", error);
                }
            }
            
            return SavedAsFiles;
        }

        public List<WordFile> GetFileList(string folderToProcess)
        {
            //testing only
            //folderToProcess = "C:\\RenamerTests\\StaticFiles";
            //folderToProcess = "M:\\RenamerTests\\StaticFiles";
            if (Directory.Exists(folderToProcess))
            {
                try
                {
                    List<string> fileList = new List<string>(Directory.GetFiles(folderToProcess, "*.doc"));
                    var WordFileList = new List<WordFile>();

                    foreach (var file in fileList)
                    {
                        if (!file.ToString().Contains("~"))
                        {
                            WordFileList.Add(new WordFile(file));
                        }
                    }
                    return WordFileList;
                }
                catch (Exception error)
                {
                    throw new Exception("Error getting list of Word files to process", error);
                }
            }
            else
            {
                throw new Exception("Source folder Not Found!");
            }
        }

        public void CleanupFolder(List<WordFile> fileList)
        {
            try
            {
                foreach (WordFile file in fileList)
                {
                    if (file.FullFileName.IndexOf("_z") != -1)
                    {
                        System.IO.File.Delete(file.FullFileName);
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error deleting renamed files", error);
            }
        }

        public void CloseWordDocs(List<WordFile> renamedFiles)
        {
            try
            {
                foreach (WordFile fileToClose in renamedFiles)
                {
                    Word.Documents[fileToClose.FullFileName].Close();
                }
                Word.Quit();
            }
            catch (Exception error)
            {
                throw new Exception("Error closing open Word documents", error);
            }
        }
    }
}
