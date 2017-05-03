﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;

        }
        public ContactData()
        {
        
        }


        public string Firstname { get; set; } 
        public string Lastname { get; set; }

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
            return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
        }
    }
}
