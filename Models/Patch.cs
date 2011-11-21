using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC2Scrapbook.Models
{
    class Patch
    {

        public IntPtr Ptr1 { get; set; }
        public int Ptr1Size { get; set; }
        public IntPtr Ptr2 { get; set; }
        public int Ptr2Size { get; set; }
        public string Version { get; set; }
        public Patch() { }

        public Patch(string version, IntPtr ptr1, IntPtr ptr2, int size1, int size2)
        {
            Version = version;
            Ptr1 = ptr1;
            Ptr1Size = size1;
            Ptr2 = ptr2;
            Ptr2Size = size2;
        }

        public override string ToString()
        {
            return string.Format("Patch {0}", Version);
        }
    }
}
