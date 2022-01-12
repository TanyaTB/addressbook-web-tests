using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
           ContactsData fromTable = app.Contacts.GetContactInformationFromTable(0);
           ContactsData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification  проверки
            Assert.AreEqual(fromTable, fromTable);
            Assert.AreEqual(fromTable.Address, fromTable.Address);
            Assert.AreEqual(fromTable.AllPhones, fromTable.AllPhones);

        }

    }
}
