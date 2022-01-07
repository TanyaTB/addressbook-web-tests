using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void TheContactRemovalTests()
        {
            List<ContactsData> oldContact = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            List<ContactsData> newContact = app.Contacts.GetContactList();

            oldContact.RemoveAt(0);

            Assert.AreEqual(oldContact, newContact);


        }
    }
}
