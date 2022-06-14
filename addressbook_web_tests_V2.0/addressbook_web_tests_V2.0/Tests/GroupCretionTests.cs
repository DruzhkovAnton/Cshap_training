using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LinqToDB;


namespace addressBookWebTests
{
    [TestFixture]
    public class GroupCretionTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvaider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(10),
                    Footer = GenerateRandomString(10)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });

            }


            return groups;


        }


        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"D:\repos\addressbook_web_tests_V2.0\addressbook_web_tests_V2.0\groups.JSON"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            //app.Auth.LogOut();
            
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (ContractData contract in GroupData.GetAll()[0].GetContacts())
            {
                System.Console.Out.WriteLine(contract);
            }

        }
    }
}
