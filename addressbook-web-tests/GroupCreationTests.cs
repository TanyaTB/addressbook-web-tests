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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData ("admin","secret"));
            navigator.GoToGroupPages();
            groupHelper.InitNewGroupCreation();
            groupHelper.FillGroupForm(new GroupDate ("Test","1","2"));
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupPage();
            loginHelper.Logout();
        }                     
     
    }
}
