﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData(string name)
        {
            Name = name;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) { return false; }
            if (Object.ReferenceEquals(this, other)) { return true; }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public string Tostring()
        {
            return "name=" + Name + "\n" + "footer=" + Footer + "\n" + "header=" + Header;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) { return 1; }
            return Name.CompareTo(other.Name);
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public GroupData()
        {
        }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContractData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contracts
                            from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContractId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }

    }
}