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
            GroupData group = GroupData.GetAll()[0];
            List<ContractData> oldList = group.GetContacts();
            ContractData contract = ContractData.GetAll().Except(oldList).First();

            app.Contract.AddContractToGroup(contract, group);

            List<ContractData> newList = group.GetContacts();
            oldList.Add(contract);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);  
        }
    }
}
