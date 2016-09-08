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
        private string _NewName = "";

        public string NewName
        {
            get
            {
                if (_NewName != "")
                {
                    return _DisplayName;
                }
                else
                {
                    return _NewName;
                }
            }
            set { _NewName = value; }
        }


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
