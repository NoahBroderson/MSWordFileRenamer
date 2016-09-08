using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSWordFileRenamer 
{
    public class RenamerEventArgs : EventArgs
    {
        public MSWordFileRenamer.WordFile File { get; set; }
        public string ActionTaken { get; set; }
        public TimeSpan ElapsedTime { get; set; }
                
    }
}
