using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        private string allPhones;

        public ContactsData(string firstname, string lastname, string address, string mobile, string email, string work, string home)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            HomePhone = home;
            MobilePhone = mobile;
            WorkPhone = work;
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

        public string HomePhone { get; set; }

        public string MobilePhone { get; set;}

        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null) 
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
                       
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";

              //  (" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";

        }

        public string Email { get; set; }
        
        public string Id { get; set; }
        }
    }

