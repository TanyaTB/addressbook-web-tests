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
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GoToAddNewPage();
            contactHelper.FillContactForm(new ContactsDate("Tatyana", "Bogatyreva", "Washington street 1050","88005687925","TYgr@gmail.com"));
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToAddNewPage();
            loginHelper.Logout();
        }

    }
}
