using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        
        [Test]
        public void TheGroupRemovalTests()
        {
            goToHomePage();
            Login(new AccountData ("Admin","secret"));
            GoToGroupPages();
            SelectGroups(1);
            RemoveGroup();
            ReturnToGroupPage();
        }
    }
}
