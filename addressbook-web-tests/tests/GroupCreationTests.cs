using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void TheGroupCreationTests()
        {
            GroupData groupData = new GroupData("Test");
            groupData.Header = "new ";
            groupData.Footer = " Test";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData groupData = new GroupData("   ");
            groupData.Header = "  ";
            groupData.Footer = "  ";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create( groupData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

         }

    }
}
