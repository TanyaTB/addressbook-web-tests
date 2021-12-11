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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("Admin", "secret"));
            navigator.GoToGroupPages();
            groupHelper.SelectGroups(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupPage();
        }
    }
}
