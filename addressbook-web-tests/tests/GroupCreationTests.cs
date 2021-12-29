using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void TheGroupCreationTests()
        {
            GroupData groupData = new GroupData("Test");
            groupData.Header = "new ";
            groupData.Footer = " Test";
            app.Groups.Create(groupData);
           // app.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData groupData = new GroupData("   ");
            groupData.Header = "  ";
            groupData.Footer = "  ";

            app.Groups.Create( groupData);
           // app.Auth.Logout();
        }

    }
}
