using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSWordFileRenamer
{
   public class Logger
    {
        private string MachineName = Environment.MachineName;

        public string LogFolder { get; set; }
        public string FullName
        {
            get
            {
                return System.IO.Path.Combine(LogFolder, Environment.MachineName + ".txt");
            }
        }


        public Logger()
        {

        }

        public Logger(string logFolder)
        {
            LogFolder = logFolder;
        }

        public void WriteTestHeader()
        {
            if (System.IO.Directory.Exists(LogFolder))
            {
                using (System.IO.StreamWriter Writer = System.IO.File.AppendText(System.IO.Path.Combine(LogFolder, MachineName + ".txt")))
                {
                    Writer.WriteLine(" ");
                    Writer.WriteLine("**************************");
                    Writer.WriteLine("Test started on Machine: {0}", MachineName);
                    Writer.WriteLine("Source folder: {0}", LogFolder);
                    Writer.WriteLine(DateTime.Now);
                    Writer.WriteLine("**************************");
                }
            }
            else
            {
                throw new Exception("Log folder does not exist: {0}");
            }
        }        

        public void WriteEntry(string entryText)
        {
            if (System.IO.Directory.Exists(LogFolder))
            {
                using (System.IO.StreamWriter Writer = System.IO.File.AppendText(System.IO.Path.Combine(LogFolder, MachineName + ".txt")))
                {
                    Writer.WriteLine("{0}-- {1}", DateTime.Now, entryText);
                }
            }
            else
            {
                throw new Exception("Log folder does not exist: {0}");
            }

        }
    }
}
