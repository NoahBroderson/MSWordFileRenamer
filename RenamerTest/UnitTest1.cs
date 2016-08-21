using MSWordFileRenamer;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RenamerTest
{
    [TestClass]
    public class RenamerTests
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

    [TestClass]
    public class WordFileTests
    {
        [TestMethod]
        public void WordFileDisplayName()
        {
            //setup
            MSWordFileRenamer.WordFile wordFile = new MSWordFileRenamer.WordFile("C:\\RenamerTests\\StaticFiles\\temp1.doc");

            //action

            //assert
            Assert.AreEqual(wordFile.ToString(), "temp1.doc");
        }

        [TestMethod]
        public void WordFileFullName()
        {
            {
                //setup
                MSWordFileRenamer.WordFile wordFile = new MSWordFileRenamer.WordFile("C:\\RenamerTests\\StaticFiles\\temp1.doc");

                //action

                //assert
                Assert.AreEqual(wordFile.FullFileName, "C:\\RenamerTests\\StaticFiles\\temp1.doc");
            }
        }
    }
}
