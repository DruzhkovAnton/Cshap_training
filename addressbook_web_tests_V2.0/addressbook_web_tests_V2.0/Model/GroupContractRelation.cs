using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressBookWebTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContractRelation
    {
        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        [Column(Name = "id")]
        public string ContractId { get; set; }
    }
}
