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
        private string _FullFileName;

        public WordFile(string fullFileName)
        {
            FullFileName = fullFileName;
        }

        public override string ToString()
        {
            return _DisplayName;
        }

        public string FullFileName
        {
            get
            {
                return _FullFileName;
            }
            set
            {
                _FullFileName = value;
                _DisplayName = System.IO.Path.GetFileName(FullFileName);
            }
        }
    }
}
