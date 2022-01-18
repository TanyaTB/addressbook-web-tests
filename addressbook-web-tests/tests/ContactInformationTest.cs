using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
           ContactsData fromTable = app.Contacts.GetContactInformationFromTable(0);
           ContactsData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
          

            //verification  проверки
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);


        }
        [Test]
        public void ContactDetailTest()
        {
            ContactsData fromDetails = app.Contacts.GetContactInformationProperties();
            ContactsData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromDetails, fromForm);
            Assert.AreEqual(fromDetails.Middlename, fromForm.Middlename);
            Assert.AreEqual(fromDetails.AllDetails, fromForm.AllDetails);
        }

    }
}
