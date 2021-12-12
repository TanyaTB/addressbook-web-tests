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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("Admin", "secret"));
            app.Navigator.GoToGroupPages();
            app.Groups.SelectGroups(1);
            app.Groups.RemoveGroup();
            app.Groups.ReturnToGroupPage();
        }
    }
}
