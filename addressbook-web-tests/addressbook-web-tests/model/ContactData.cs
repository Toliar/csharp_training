using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;

        }
        public ContactData()
        {
        
        }


        public string Firstname { get; set; } 
        public string Lastname { get; set; } 
    }
}
