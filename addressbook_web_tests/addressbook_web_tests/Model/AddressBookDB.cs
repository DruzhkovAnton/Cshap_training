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


        public AddressBookDB() : base("addressbook") 
        {
            string ConnectionString = "Server=localhost;Port=3306;Database=addressbook;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime=true";
            LinqToDB.Data.DataConnection con = new LinqToDB.Data.DataConnection();
        }
        

        public ITable<GroupData> Groups => this.GetTable<GroupData>();

        public ITable<ContractData> Contracts => this.GetTable<ContractData>();
    }
}
 