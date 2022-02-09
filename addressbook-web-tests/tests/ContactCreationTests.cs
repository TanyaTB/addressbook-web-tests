    using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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
        public static IEnumerable<ContactsData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactsData>>(
            File.ReadAllText(@"contacts.json"));
        }
        public static IEnumerable<ContactsData> ContactDataFromXmlFile()
        {
            return (List<ContactsData>)
                new XmlSerializer(typeof(List<ContactsData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }


        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void TheContactCreationTests(ContactsData contactData)
        {
           // ContactsData contactData = new ContactsData("Tatyana","Bogatyreva");
           // contactData.Middlename = "Dmitrievna";
           // contactData.Address = "Washington street 1011";
           // contactData.MobilePhone = "88005687925";
          //  contactData.HomePhone = "88005687925";
          //  contactData.Email = "Tgr@gmail.com";
          //  contactData.Title = "123";



            List<ContactsData> oldContact = ContactsData.GetAll();

            app.Contacts.Create(contactData);

            Assert.AreEqual(oldContact.Count + 1, app.Contacts.GetContactCount());

            List<ContactsData> newContact = ContactsData.GetAll();
            newContact.Sort();
            contactData.Id = newContact[newContact.Count - 1].Id;
            oldContact.Add(contactData);
            oldContact.Sort();
            
            Assert.AreEqual(oldContact, newContact);

        }


    }
}
