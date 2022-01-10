using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        
        public ContactsData(string firstname, string lastname, string address, string mobile, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            Mobile = mobile;
            Email = email;

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
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode() & FirstName.GetHashCode();
        }
        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.FirstName != other.FirstName)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            if (this.LastName != other.LastName)
            {
                return LastName.CompareTo(other.LastName);
            }
            return LastName.CompareTo(other.LastName) & FirstName.CompareTo(other.FirstName);
        }
        public override string ToString()
        {
            return $"contact = {LastName} {FirstName}";
        }




        public ContactsData(string name)
        {
            FirstName = name;

        }

        public ContactsData(string name, string lastName )
        {
            FirstName = name;
            LastName = lastName;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        
        public string Mobile { get; set; }

        public string Email { get; set; }
        
        public string Id { get; set; }
        }
    }

