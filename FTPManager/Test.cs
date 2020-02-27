using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    public class Test
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string No { get; set; }
        public Test(string no, string desc, string name)
        {
            Name = name;
            No = no;
            Desc = desc;
        }
    }
}
