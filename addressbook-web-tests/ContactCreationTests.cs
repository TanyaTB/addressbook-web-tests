using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests :TestBase 
    {
        
        [Test]
        public void TheContactCreationTests()
        {
            goToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            FillContactForm(new ContactsDate("Tatyana", "Bogatyreva", "Washington street 1050","88005687925","TYgr@gmail.com"));
            SubmitContactCreation();
            ReturnToAddNewPage();
            Logout();
        }

    }
}
