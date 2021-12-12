using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void TheGroupCreationTests()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin","secret"));
            app.Navigator.GoToGroupPages();
            app.Groups.InitNewGroupCreation();
            app.Groups.FillGroupForm(new GroupDate ("Test","1","2"));
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupPage();
            app.Auth.Logout();
        }                     
     
    }
}
