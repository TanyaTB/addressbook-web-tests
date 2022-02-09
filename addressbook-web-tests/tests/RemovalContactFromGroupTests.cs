using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovalContactFromGroupTests : AuthTestBase
    {
        public class DeletingingContactFromGroupTests : AuthTestBase
        {
            [Test]
            public void TestRemovalContactFromGroupTests()
            {
                List<GroupData> grouplist = GroupData.GetAll();
                List<ContactsData> contactlist = ContactsData.GetAll();
                ContactsData newcontact = new ContactsData("Tanya", "Bogatyreva");
                newcontact.Middlename = "Dmitrievna";
                GroupData newgroup = new GroupData("New Group");
                
                if (grouplist.Count == 0)
                {
                    app.Groups.Create(newgroup);

                    if (contactlist.Count == 0)
                    {
                        app.Contacts.Create(newcontact);
                        GroupData group = GroupData.GetAll()[0];
                        List<ContactsData> contactsInGroup = group.GetContacts();
                        ContactsData contact = ContactsData.GetAll().Except(contactsInGroup).First();
                        app.Contacts.AddContactToGroup(contact, group);
                    }
                }
                else
                {
                    if (contactlist.Count == 0)
                    {
                        app.Contacts.Create(newcontact);
                    }
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactsData> contactsInGroup = group.GetContacts();
                    if (contactsInGroup.Count == 0)
                    {
                        ContactsData contact = ContactsData.GetAll().Except(contactsInGroup).First();
                        app.Contacts.AddContactToGroup(contact, group);
                    }
                }

                GroupData group2 = GroupData.GetAll()[0];
                List<ContactsData> oldList = group2.GetContacts();
                ContactsData contactInGroup = GroupData.GetAll()[0].GetContacts().First();


                app.Contacts.DeleteContactFromGroup(contactInGroup, group2);

                List<ContactsData> newList = group2.GetContacts();
                oldList.Remove(contactInGroup);
                newList.Sort();
                oldList.Sort();


                Assert.AreEqual(oldList, newList);
            }
        }
    }
}
