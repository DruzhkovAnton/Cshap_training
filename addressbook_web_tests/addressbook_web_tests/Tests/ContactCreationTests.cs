using NUnit.Framework;
using System.Collections.Generic;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractCreationTests : AuthTestBase
    {
        public static IEnumerable<ContractData> RandomContractDataProvider()
        {
            List<ContractData> contracts = new List<ContractData>();
            for (int i = 0; i < 3; i++)
            {
                contracts.Add(new ContractData(GenerateRandomString(10), GenerateRandomString(10))
                {
                    MiddleName = GenerateRandomString(10),
                    Nickname = GenerateRandomString(10),
                    Title = GenerateRandomString(10),
                    Company = GenerateRandomString(10),
                    Address = GenerateRandomString(10),
                    PhoneHome = GenerateRandomString(10),
                    PhoneMobile = GenerateRandomString(10),
                    PhoneWork = GenerateRandomString(10),
                    PhoneFax = GenerateRandomString(10),
                    Email = GenerateRandomString(10),
                    Email2 = GenerateRandomString(10),
                    Email3 = GenerateRandomString(10),
                    Homepage = GenerateRandomString(10)
                });
            }
            return contracts;
        }

        [Test, TestCaseSource("RandomContractDataProvider")]
        public void ContractCreationTest(ContractData contract)
        {
            List<ContractData> oldContracts = app.Contract.GetContractList();

            app.Contract.Сreate(contract);

            Assert.AreEqual(oldContracts.Count + 1, app.Contract.GetContractCount());

            List <ContractData> newContracts = app.Contract.GetContractList();
            oldContracts.Add(contract);
            oldContracts.Sort();
            newContracts.Sort();
            Assert.AreEqual(oldContracts, newContracts);

            app.Auth.LogOut();
        }
    }
}
