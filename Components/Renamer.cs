using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Threading;

namespace MSWordFileRenamer
{
    public class Renamer
    {
        private string _sourceFolder;

        public Renamer(string sourceFolder)
        {
            _sourceFolder = sourceFolder;
        }

        public Application Word { get; set; }

        public event EventHandler<RenamerEventArgs> FileRenamed;
        //public event EventHandler<RenamerEventArgs> FileOpened;

        public void RenameFiles(List<WordFile> filesToRename)
        {
            var SavedAsFiles = new List<WordFile>();

            try
            {
                Word = new Application();
                Word.Visible = true;

                foreach (WordFile file in filesToRename)
                {
                    //var Timer = new System.Diagnostics.Stopwatch();
                    //Timer.Start();
                    Document Document = Word.Documents.Open(file.FullFileName);
                    //Timer.Stop();
                    //var args = new RenamerEventArgs() { File = file, ElapsedTime = Timer.Elapsed };
                    //if (FileOpened != null)
                    //{
                    //    FileOpened(this, args);
                    //}
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
                    if (file.ToString().IndexOf("_z") == -1)
                    {
                        RenameFile(file);
                    }
                }
                catch (Exception error)
                {
                    throw new Exception("Error renaming Word documents", error);
                }
            }            
        }

        private void RenameFile(WordFile file)
        {
            var Timer = new System.Diagnostics.Stopwatch();
            var ElapsedTime = new TimeSpan();
            Document CurrentDocument = Word.Documents[file.FullFileName];
            string SavedAsName = file.FullFileName.Replace(".", "_z.");
            Timer.Start();
            CurrentDocument.SaveAs(SavedAsName);
            Timer.Stop();
            ElapsedTime = Timer.Elapsed;
            file.FullFileName = SavedAsName;

            if (FileRenamed != null)
            {
                RenamerEventArgs args = new RenamerEventArgs();
                args.File = file;
                args.ElapsedTime = ElapsedTime;
                FileRenamed(this, args);
            }
            //CurrentDocument.Close(false);
        }

        public List<WordFile> GetFileList()
        {
            //testing only
            //folderToProcess = "C:\\RenamerTests\\StaticFiles";
            //folderToProcess = "M:\\RenamerTests\\StaticFiles";
            if (Directory.Exists(_sourceFolder))
            {
                try
                {
                    List<string> fileList = new List<string>(Directory.GetFiles(_sourceFolder, "*.doc"));
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
                throw new Exception("Error deleting renamed files, are all Word documents closed?", error);
            }
        }

        public void CloseWordDocs(List<WordFile> renamedFiles)
        {
            try
            {
                for (int i = 1; i == this.Word.Documents.Count; i++)
                {
                    Word.Documents[i].Close();
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
