using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    
        [TestFixture]
        public class ContactModificationTests : TestBase
        {
            [Test]
            public void TheContactModificationTests()
            {
                ContactsData newData = new ContactsData("Modify");
                newData.LastName = "Bogatyreva";
                newData.Address = "Washington street 1050";
                newData.Mobile = "88005687925";
                newData.Email = "TYgr@gmail.com";

               app.Contacts.Modify(newData);

            }
        }
    }

