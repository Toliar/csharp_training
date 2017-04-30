using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContact : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            int index = 1;
          //  string index = index1.ToString();

            app.Contacts.DeleteContact(index);
            
        }

    }
}
