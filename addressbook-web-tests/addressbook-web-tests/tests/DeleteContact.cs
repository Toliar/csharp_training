﻿using NUnit.Framework;
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
            if (!app.Contacts.IsFirstContactExist(index))
            {
                ContactData defaultcontact = new ContactData();
                defaultcontact.Firstname = "first1";
                defaultcontact.Lastname = "last1";

                app.Contacts.CreateContact(defaultcontact);
            }

            app.Contacts.DeleteContact(index);
            
        }

    }
}
