﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeleteContact : TestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            string lastname = "last";

            app.Contacts.DeleteContact(lastname);
            
        }

    }
}
