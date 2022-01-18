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
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = (GenerateRandomString(100)),
                    Footer = (GenerateRandomString(100))

                });
            }
            return groups;
        }



        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void TheGroupCreationTests(GroupData groupData)
        {
            //GroupData groupData = new GroupData("Test");
            // groupData.Header = "new ";
            //groupData.Footer = " Test";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(groupData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

       // [Test]
        // public void EmptyGroupCreationTests()
        //{
        //   GroupData groupData = new GroupData("");
        //    groupData.Header = "";
        //     groupData.Footer = "";

        //   List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    app.Groups.Create( groupData);

        //   Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

        //   List <GroupData> newGroups = app.Groups.GetGroupList();

        //   oldGroups.Add(groupData);
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);

        //  }

    
}
}
