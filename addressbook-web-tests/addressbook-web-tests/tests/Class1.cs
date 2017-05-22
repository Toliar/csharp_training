using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    class Class1 { 
    
        [Test]
        public void Output()
        {
            string s = "Firstname lastname  " + " /r/n" + "F:";
            Console.Out.WriteLine(Regex.Replace(s, "(F+:)", ""));
        }
    }
}
