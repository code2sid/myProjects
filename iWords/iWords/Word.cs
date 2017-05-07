using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iWords
{
    public class Word
    {
        public string Title { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public int Knowthis { get; set; }
        public int knowCnt { get; set; }
        public int dontKnwCnt { get; set; }
    }
}
