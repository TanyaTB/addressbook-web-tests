using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
        [TestFixture]
        public class ContactModificationTests : AuthTestBase
    {
            [Test]
            public void TheContactModificationTests()
            {
                ContactsData newData = new ContactsData("Rename");
                newData.LastName = "Bogatyreva";
                newData.Address = "Washington street 1050";
                newData.Mobile = "88005687925";
                newData.Email = "TYgr@gmail.com";

            List<ContactsData> oldContact = app.Contacts.GetContactList();

            app.Contacts.Modify(newData);

            List<ContactsData> newContact = app.Contacts.GetContactList();

            oldContact[0].FirstName = newData.FirstName;
            oldContact[0].LastName = newData.LastName;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);

        }
        }
    }

