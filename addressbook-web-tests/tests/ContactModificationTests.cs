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
                newData.LastName = "Rename";
                newData.Address = "Washington street 1050";
                newData.MobilePhone = "88005687925";
                newData.Email = "TYgr@gmail.com";

            List<ContactsData> oldContact = app.Contacts.GetContactList();
            ContactsData oldData = oldContact[0];

            app.Contacts.Modify(newData);

            Assert.AreEqual(oldContact.Count, app.Contacts.GetContactCount());

            List<ContactsData> newContact = app.Contacts.GetContactList();

            oldContact[0].FirstName = newData.FirstName;
            oldContact[0].LastName = newData.LastName;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
            foreach (ContactsData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }


        }
    }
    }

