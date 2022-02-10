using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {

        [Test]
        public void TheContactRemovalTests()
        {

            app.Contacts.IsContactPresent();

            List<ContactsData> oldContact = ContactsData.GetAll();

            ContactsData toBeRemoved = oldContact[0];

            app.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContact.Count-1, app.Contacts.GetContactCount());

            List<ContactsData> newContact = ContactsData.GetAll();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);
            foreach (ContactsData contact in newContact)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

        }


    }
    }

