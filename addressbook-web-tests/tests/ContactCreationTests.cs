using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void TheContactCreationTests()
        {
            ContactsData contactData = new ContactsData("Tatyana");
            contactData.LastName = "Bogatyreva";
            contactData.Address = "Washington street 1050";
            contactData.Mobile = "88005687925";
            contactData.Email = "TYgr@gmail.com";
            
            app.Contacts.Create(contactData);
            //app.Auth.Logout();
        }


    }
}
