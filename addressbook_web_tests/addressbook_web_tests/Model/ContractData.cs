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
        private string midlename;
        private string nickname;
        private string title;
        private string cpmpany;
        private string address;
        private string address2;
        private string phonehome;
        private string phonemobile;
        private string phonework;
        private string phonefax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string group;
        private string allPhones;
        private string allEmails;
        private string fio;
        private string allDetails;

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
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }

        public string PhoneHome { get; set; }

        public string PhoneMobile { get; set; }

        public string PhoneWork { get; set; }

        public string Phone2 { get; set; }

        public string PhoneFax { get; set; }

        public string AllPhones 
        { get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (cleanUp(PhoneHome) + cleanUp(PhoneMobile) + cleanUp(PhoneWork) + cleanUp(Phone2)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            } 
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (cleanUp(Email) + cleanUp(Email2) + cleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Fio
        {
            get
            {
                if (fio != null)
                {
                    return fio;
                }
                else
                {
                    return (FirstName + MiddleName + Lastname).Trim();
                }
            }
            set { fio = value; }


        }

        private string cleanUp(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Group { get; set; }

        public string Alldetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails.Trim();
                }
                else
                {
                    return (FirstName +" "+ MiddleName + " " + Lastname +"\r\n"
                          + Nickname + "\r\n"
                          + Title + "\r\n"
                          + Company + "\r\n"
                          + Address + "\r\n"
                          + "\r\n"
                          + PhoneHome 
                          + PhoneMobile 
                          + PhoneWork 
                          + PhoneFax 
                          + "\r\n"
                          + Email + "\r\n"
                          + Email2 + "\r\n"
                          + Email3 + "\r\n"
                          + Homepage + "\r\n"
                          + "\r\n"
                          + "\r\n"
                          + Address2+"\n").Trim();
                }
            }
            set { allDetails = value; }
        }
        


    }
}
