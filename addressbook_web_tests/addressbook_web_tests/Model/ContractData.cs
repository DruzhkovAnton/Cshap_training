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
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public bool Equals(ContractData other)
        {
            if (object.ReferenceEquals(other, null)) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }
            return FirstName == other.FirstName && Lastname == other.lastname;
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
            return FirstName.CompareTo(other.FirstName) + Lastname.CompareTo(other.lastname);
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string MiddleName
        {
            get { return midlename; }
            set { midlename = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return cpmpany; }
            set { cpmpany = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneHome
        {
            get { return phonehome; }
            set { phonehome = value; }
        }

        public string PhoneMobile
        {
            get { return phonemobile; }
            set { phonemobile = value; }
        }
        public string PhoneWork
        {
            get { return phonework; }
            set { phonework = value; }
        }
        public string PhoneFax
        {
            get { return phonefax; }
            set { phonefax = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }
        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
