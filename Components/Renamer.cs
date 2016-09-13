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
                
        public event EventHandler<RenamerEventArgs> FileProcessed;

        public void RenameFiles(List<WordFile> filesToRename)
        {
            var SavedAsFiles = new List<WordFile>();

            try
            {
                Word = new Application();
                Word.Visible = true;

                foreach (WordFile file in filesToRename)
                {
                    if (file.ToString().IndexOf("_z") == -1)
                    {
                        var Timer = new System.Diagnostics.Stopwatch();
                        Timer.Start();
                        Document Document = Word.Documents.Open(file.FullFileName);
                        Timer.Stop();
                        var args = new RenamerEventArgs() { File = file, ElapsedTime = Timer.Elapsed, ActionTaken = "Opened" };
                        if (FileProcessed != null)
                        {
                            FileProcessed(this, args);
                        }
                        try
                        {

                            RenameFile(file);

                        }
                        catch (Exception error)
                        {
                            throw new Exception("Error renaming Word documents", error);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error opening Word documents", error);
            }

            foreach (WordFile file in filesToRename)
            {
                
            }            
        }

        public void ProcessFiles(List<WordFile> filesToRename, bool renameFile, bool saveFile, bool closeFile)
        {
            //var SavedAsFiles = new List<WordFile>();
            CleanupFolder(filesToRename);

            try
            {
                Word = new Application();
                Word.Visible = true;

                foreach (WordFile file in filesToRename)
                {
                    string CurrentFileName = file.FullFileName;

                    if (file.ToString().IndexOf("_z") == -1)
                    {
                        Open(file);

                        if (renameFile)
                        {
                            RenameFile(file);
                        }

                        if (saveFile)
                        {
                            EditAndSave(file);
                        }

                        if (closeFile)
                        {
                            CloseFile(file);
                        }
                    }
                }

                if (Word.Windows.Count == 0)
                {
                    Word.Quit();
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error Processing Word documents", error);
            }
        }

        private void EditAndSave(WordFile file)
        {
            try
            {
                var Timer = new System.Diagnostics.Stopwatch();
                Document currentDocument = Word.Documents[file.FullFileName];
                currentDocument.Range(0, 0).Text = "NewText";
                Timer.Start();
                currentDocument.Save();
                Timer.Stop();
                
                if (FileProcessed != null)
                {
                    var args = new RenamerEventArgs() { File = file, ElapsedTime = Timer.Elapsed, ActionTaken = "Saved" };
                    FileProcessed(this, args);
                }
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("Error saving Word document: {0}", file), error);
            }
            
        }

        private void CloseFile(WordFile file)
        {
            try
            {
                var Timer = new System.Diagnostics.Stopwatch();
                Document currentDocument = Word.Documents[file.FullFileName];
                Timer.Start();
                currentDocument.Close();
                Timer.Stop();

                if (FileProcessed != null)
                {
                    var args = new RenamerEventArgs() { File = file, ElapsedTime = Timer.Elapsed, ActionTaken = "Closed" };
                    FileProcessed(this, args);
                }
                               
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("Error closing document: {0}", file), error);
            }
        }

        private void Open(WordFile file)
        {
            try
            {
                var Timer = new System.Diagnostics.Stopwatch();
                Timer.Start();
                Document Document = Word.Documents.Open(file.FullFileName);
                Timer.Stop();
                
                if (FileProcessed != null)
                {
                    var args = new RenamerEventArgs() { File = file, ElapsedTime = Timer.Elapsed, ActionTaken = "Opened" };
                    FileProcessed(this, args);
                }
            }
            catch (Exception error)
            {
                throw new Exception(string.Format("Error Opening file: {0}", file), error);
            }
            
        }

        private void RenameFile(WordFile file)
        {
            try
            {
                var Timer = new System.Diagnostics.Stopwatch();                
                Document CurrentDocument = Word.Documents[file.FullFileName];
                string SavedAsName = file.FullFileName.Replace(".", "_z.");
                Timer.Start();
                CurrentDocument.SaveAs(SavedAsName);
                Timer.Stop();                
                file.FullFileName = SavedAsName;

                if (FileProcessed != null)
                {
                    RenamerEventArgs args = new RenamerEventArgs();
                    args.File = file;
                    args.ActionTaken = "Renamed";
                    args.ElapsedTime = Timer.Elapsed;
                    FileProcessed(this, args);
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error renaming Word documents", error);
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
