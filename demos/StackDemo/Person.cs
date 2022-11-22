using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackDemo
{
    public class Person
    {
        public Person(string fname, string lname, string catchPhrase)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.CatchPhrase = catchPhrase;
        }


        public string Fname { get; set; } = "";
        public string Lname { get; set; } = "";
        public string CatchPhrase { get; set; } = "";
    }
}