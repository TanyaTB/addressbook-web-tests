using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        private string firstname;
        private string lastname;
        private string address;
        private string mobile;
        private string email;


        public ContactsData(string firstname, string lastname, string address, string mobile, string email)
        {

            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.mobile = mobile;
            this.email = email;

        }
        public bool Equals(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName;
            return LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
            return LastName.GetHashCode();
        }
        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
            return LastName.CompareTo(other.LastName);
        }
        public override string ToString()
        {
            return $"contact = {lastname} {firstname}";
        }




        public ContactsData(string name)
        {
            this.firstname = name;

        }

        public ContactsData(string name, string text) : this(name)
        {
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
