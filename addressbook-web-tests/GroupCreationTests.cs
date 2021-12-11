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
            goToHomePage();
            Login(new AccountData ("admin","secret"));
            GoToGroupPages();
            InitNewGroupCreation();
            FillGroupForm(new GroupDate ("Test","1","2"));
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }                     
     
    }
}
