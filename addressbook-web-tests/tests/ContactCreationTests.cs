using System;
using System.Collections.Generic;
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
            ContactsData contactData = new ContactsData("Tatyana","Bogatyreva");
            contactData.Middlename = "Dmitrievna";
            contactData.Address = "Washington street 1011";
            contactData.MobilePhone = "88005687925";
            contactData.Email = "Tgr@gmail.com";
            contactData.Title = "123";



            List<ContactsData> oldContact = app.Contacts.GetContactList();

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContact = app.Contacts.GetContactList();

            oldContact.Add(contactData);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);

        }


    }
}
