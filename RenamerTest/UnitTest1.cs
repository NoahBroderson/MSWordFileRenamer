using MSWordFileRenamer;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RenamerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetFileList()
        {
            //setup
            MSWordFileRenamer.Renamer fileRenamer = new MSWordFileRenamer.Renamer();
            string FolderPath = "C:\\RenamerTests\\StaticFiles";

            //action
            List<string> FileList = fileRenamer.GetFileList(FolderPath);

            //assert
            int fileCount = 4;
            Assert.AreEqual(fileCount, FileList.Count);
        }
    }
}
