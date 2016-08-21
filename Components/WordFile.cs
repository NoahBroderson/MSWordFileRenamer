using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSWordFileRenamer
{
    public class WordFile
    {
        private string _DisplayName;

        public WordFile(string fullFileName)
        {
            _DisplayName = System.IO.Path.GetFileName(fullFileName);
            FullFileName = fullFileName;
        }

        public override string ToString()
        {
            return _DisplayName;
        }

        public string FullFileName { get; set; }
    }
}
