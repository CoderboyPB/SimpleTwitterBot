using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TwitterBot
{
    class CustomFileStream : System.IO.FileStream
    {
        public override int ReadTimeout { get; set; }
        public override int WriteTimeout { get; set; }

        public CustomFileStream(string file, FileMode mode, int tr, int tw): base(file, mode)
        {
            ReadTimeout = tr;
            WriteTimeout = tw;
        }
    }
}
