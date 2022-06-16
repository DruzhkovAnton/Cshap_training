using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressBookWebTests
{
    public class AddingContractToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContractToGroup()
        {
            app.Groups.GroupExist();
            app.Contract.ContractExist();
            List<GroupData> groups = GroupData.GetAll();
            app.Contract.InContactsExistGroup(groups[0]);
            List<ContractData> oldList = groups[0].GetContacts();
            ContractData contract = ContractData.GetAll().Except(oldList).First();

            app.Contract.AddContractToGroup(contract, groups[0]);

            List<ContractData> newList = groups[0].GetContacts();
            oldList.Add(contract);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);  
        }

        [Test]
        public void TestRemoveContractFromGroup()
        {

            app.Groups.GroupExist();
            app.Contract.ContractExist();
            GroupData group = GroupData.GetAll()[0];
            app.Contract.NoContractsExistInGroup(group);
            List<ContractData> oldList = group.GetContacts();
            ContractData contact = ContractData.GetAll().First(); 
            ContractData contract = group.GetContacts().First();

            app.Contract.RemoveContractToGroup(contract, group);

            List<ContractData> newList = group.GetContacts();
            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);



        }
    }
}
