using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressBookWebTests
{
    public class ContractData : IEquatable<ContractData>, IComparable<ContractData>
    {
        private string firstname;
        private string lastname;
        private string midlename = "";
        private string nickname = "";
        private string title = "";
        private string cpmpany = "";
        private string address = "";
        private string phonehome = "";
        public string phonemobile = "";
        private string phonework = "";
        private string phonefax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string group = "";


        public ContractData(string firstname, string lastname)
        {
            FirstName = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContractData other)
        {
            if (object.ReferenceEquals(other, null)) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }
            return FirstName == other.FirstName && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstName=" + FirstName + ", " + "lastname=" + Lastname;
        }

        public int CompareTo(ContractData other)
        {
            if (object.ReferenceEquals (other, null)) { return 1; }
            return FirstName.CompareTo(other.FirstName) + Lastname.CompareTo(other.Lastname);
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string PhoneWork { get; set; }

        public string PhoneFax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Group { get; set; }
    }
}
