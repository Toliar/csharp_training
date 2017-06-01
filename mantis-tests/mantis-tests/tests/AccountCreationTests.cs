﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{ 
    
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile= File.Open("/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
                
        }

        [Test]
     public void TestAccountReistration()
     {
        AccountData account = new AccountData()
        {
            Name = "testuser",
            Password = "Password",
            Email = "testuser@localhost.localdomain"
        };

        app.Registration.Register(account);
     }
        [TestFixtureTearDown]
        public void restoreUpConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }


    }
}
