using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;

        }
        public ContactData()
        {
        
        }
        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "id"),PrimaryKey]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp (MobilePhone) + CleanUp (WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone=="" )
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()]","")  + "\r\n";               
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return  Firstname == other.Firstname && Lastname == other.Lastname;
            
        }

        public override int GetHashCode()
        {
            return (Firstname+Lastname).GetHashCode();
        }

        public override string ToString()
        {
          return Firstname + Lastname;
        }

    public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Equals(other))
            {
                return 0;
            }
             if (this.Lastname != other.Lastname)
            {
                return this.Lastname.CompareTo(other.Lastname);
            }
            return this.Firstname.CompareTo(other.Firstname);
        }
        public static List<ContactData> GetAllFromDB()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
