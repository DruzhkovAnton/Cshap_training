using LinqToDB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {


        public AddressBookDB() : base("AddressBook") { }


        public ITable<GroupData> Groups => this.GetTable<GroupData>();

        public ITable<ContractData> Contracts => this.GetTable<ContractData>();

        public ITable<GroupContractRelation> GCR => this.GetTable<GroupContractRelation>();
    }
}
