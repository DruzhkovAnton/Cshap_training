using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressBookWebTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressBookWebTestsGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter sw = new StreamWriter(args[2]);
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContractData> contracts = new List<ContractData>();

            if (typeData == "group")
            {
                
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
            }
            else if(typeData == "contract")
            {
                for (int i = 0; i< count; i++)
                {
                    contracts.Add(new ContractData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                    {
                        MiddleName = TestBase.GenerateRandomString(10),         
                        Nickname = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        Address2 = TestBase.GenerateRandomString(10),
                        PhoneHome = TestBase.GenerateRandomString(10),
                        PhoneMobile = TestBase.GenerateRandomString(10),
                        PhoneWork = TestBase.GenerateRandomString(10),
                        PhoneFax = TestBase.GenerateRandomString(10),
                        Phone2 = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        Homepage = TestBase.GenerateRandomString(10)

                    });
                }
            }
            else
            {
                System.Console.Out.Write("Неправильный Тип Данных - " + typeData);
            }

            if (typeData == "group")
            {
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, sw);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, sw);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, sw);
                }
                else
                {
                    System.Console.Out.Write("Неправильный формат - " + format);
                }
            }
            else if (typeData == "contract")
            {
                if (format == "csv")
                {
                    writeContractsToCsvFile(contracts, sw);
                }
                else if (format == "xml")
                {
                    writeContractsToXmlFile(contracts, sw);
                }
                else if (format == "json")
                {
                    writecontractsToJsonFile(contracts, sw);
                }
                else
                {
                    System.Console.Out.Write("Неправильный формат - " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Неправильный Тип Данных - " + typeData);
            }

            


            sw.Close();
        }

        

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter sw)
        {
            foreach (GroupData group in groups)
            {
                sw.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }

        }

        static void writeContractsToCsvFile(List<ContractData> contracts, StreamWriter sw)
        {
            foreach (ContractData contract in contracts)
            {
                sw.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9},${10},${11},${12},${13},${14},${15},${16}",
                 contract.FirstName
                ,contract.Lastname
                ,contract.MiddleName
                ,contract.Nickname
                ,contract.Title
                ,contract.Company
                ,contract.Address
                ,contract.Address2
                ,contract.PhoneHome 
                ,contract.PhoneMobile
                ,contract.PhoneWork
                ,contract.PhoneFax
                ,contract.Phone2
                ,contract.Email 
                ,contract.Email2
                ,contract.Email3
                ,contract.Homepage
                ));
            }

        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter sw)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(sw, groups);
        }

        static void writeContractsToXmlFile(List<ContractData> contracts, StreamWriter sw)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(sw, contracts);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter sw)
        {
            sw.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writecontractsToJsonFile(List<ContractData> contracts, StreamWriter sw)
        {
            sw.Write(JsonConvert.SerializeObject(contracts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
