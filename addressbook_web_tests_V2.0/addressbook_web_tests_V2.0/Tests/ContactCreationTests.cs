using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace addressBookWebTests
{
    [TestFixture]
    public class ContractCreationTests : ContractTestBase
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

        public static IEnumerable<ContractData> ContractDataFromCsvFile()
        {
            List<ContractData> contracts = new List<ContractData>();

            string[] lines = File.ReadAllLines(@"contract.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contracts.Add(new ContractData(parts[0], parts[1])
                {
                    MiddleName = parts[2],
                    Nickname = parts[3],
                    Title = parts[4],
                    Company = parts[5],
                    Address = parts[6],
                    Address2 = parts[7],
                    PhoneHome = parts[8],
                    PhoneMobile = parts[9],
                    PhoneWork = parts[10],
                    PhoneFax = parts[11],
                    Phone2 = parts[12],
                    Email = parts[13],
                    Email2 = parts[14],
                    Email3 = parts[15],
                    Homepage = parts[16]
                });

            }


            return contracts;


        }


        public static IEnumerable<ContractData> ContractsDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContractData>>(
                File.ReadAllText(@"D:\repos\addressbook_web_tests_V2.0\addressbook_web_tests_V2.0\contract.JSON"));
        }

        [Test, TestCaseSource("ContractsDataFromJsonFile")]
        public void ContractCreationTest(ContractData contract)
        {
            List<ContractData> oldContracts = ContractData.GetAll();

            app.Contract.Сreate(contract);

            List<ContractData> newContracts = ContractData.GetAll();

            Assert.AreEqual(oldContracts.Count + 1, newContracts.Count);

            
            oldContracts.Add(contract);
            oldContracts.Sort();
            newContracts.Sort();
            Assert.AreEqual(oldContracts, newContracts);

            //app.Auth.LogOut();
        }
    }
}
