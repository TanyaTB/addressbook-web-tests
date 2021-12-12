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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GoToAddNewPage();
            app.Contacts.FillContactForm(new ContactsDate("Tatyana", "Bogatyreva", "Washington street 1050","88005687925","TYgr@gmail.com"));
            app.Contacts.SubmitContactCreation();
            app.Contacts.ReturnToAddNewPage();
            app.Auth.Logout();
        }

    }
}
