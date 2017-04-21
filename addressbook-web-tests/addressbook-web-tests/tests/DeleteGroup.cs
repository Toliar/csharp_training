using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    class DeleteGroup : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            int index = 1;

            app.Groups.DeleteGroup(index);

        }
    }
}
