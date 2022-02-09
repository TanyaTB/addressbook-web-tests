using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : ContactTestBase
    {
        [Test]

        public void TestAddingConactToGroup()
        {
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactsData> contactlist = ContactsData.GetAll();
            ContactsData newcontact = new ContactsData("Tatyana", "Bogatyreva");
            newcontact.Middlename = "Dmitrievna";
            GroupData newgroup = new GroupData("New Group");

            if (grouplist.Count == 0)
            {
                app.Groups.Create(newgroup);

                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }
            else
            {
                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactsData> oldList = group.GetContacts();

            if (oldList.SequenceEqual(ContactsData.GetAll()))
            {
                app.Contacts.Create(newcontact);
            }

            ContactsData contact = ContactsData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}