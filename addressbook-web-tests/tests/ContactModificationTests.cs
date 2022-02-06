using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
        [TestFixture]
        public class ContactModificationTests : ContactTestBase
    {
            [Test]
            public void TheContactModificationTests()
            {
                ContactsData newData = new ContactsData("Rename");
                newData.LastName = "Rename";
                newData.Address = "Washington street 1050";
                newData.MobilePhone = "88005687925";
                newData.Email = "TYgr@gmail.com";

            List<ContactsData> oldContact = ContactsData.GetAll();
            
            ContactsData toBeModified = oldContact[0];
            ContactsData oldData = oldContact[0];

            app.Contacts.Modify(toBeModified,newData);

            Assert.AreEqual(oldContact.Count, app.Contacts.GetContactCount());

            List<ContactsData> newContact = ContactsData.GetAll();          

            oldContact[0].FirstName = newData.FirstName;
            oldContact[0].LastName = newData.LastName;

            oldContact.Sort();
            newContact.Sort();

            Assert.AreEqual(oldContact, oldContact);
            foreach (ContactsData contact in newContact)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, toBeModified.LastName);
                    Assert.AreEqual(newData.FirstName, toBeModified.FirstName);
                }
            }


        }
    }
    }

