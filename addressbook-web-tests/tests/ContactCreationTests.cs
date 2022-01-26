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
        public static IEnumerable<ContactsData> RandomContactDataProvider()
        {
            List<ContactsData> contacts = new List<ContactsData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactsData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = (GenerateRandomString(30)),
                    Address = (GenerateRandomString(100)),
                    MobilePhone = (GenerateRandomString(11)),
                    HomePhone = (GenerateRandomString(11)),
                    Email = (GenerateRandomString(15)),
                    Title = (GenerateRandomString(10)),
                });
            }
            return contacts;
            
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void TheContactCreationTests(ContactsData contactData)
        {
           // ContactsData contactData = new ContactsData("Tatyana","Bogatyreva");
           // contactData.Middlename = "Dmitrievna";
           // contactData.Address = "Washington street 1011";
           // contactData.MobilePhone = "88005687925";
          //  contactData.HomePhone = "88005687925";
          //  contactData.Email = "Tgr@gmail.com";
          //  contactData.Title = "123";



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
