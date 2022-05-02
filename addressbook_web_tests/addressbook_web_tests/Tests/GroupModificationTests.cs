using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressBookWebTests.Tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("ccc");
            newData.Header = "zzz";
            newData.Footer = "xxxx";

            app.Groups.Modify(1, newData);
        }
    }
}
