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
       
        public string firstname;
        public string middlename = "";
        public string lastname = "";
        public string nickname = "";
        public string title = "";
        public string company = "";
        public string address = "";
        public string homephone = "";
        public string mobilephone = "";
        public string workphone = "";
        public string fax = "";
        public string mail1 = "";
        public string mail2 = "";
        public string mail3 = "";
        public string homepage = "";
        public string address2 = "";
        public string phone2 = "";
        public string notes = "";
        public string bday = "";
        public string bmonth = "";
        public string byear = "";
        public string aday = "";
        public string amonth = "";
        public string ayear = "";
        public string group = "";
        public string photo = "";
        private string allPhones;
        private string allDetails;
        private string allEmail;

        public ContactsData(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;
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
            return 0;
                //LastName.CompareTo(other.LastName) & FirstName.CompareTo(other.FirstName);
        }

        public override string ToString()
        {
            return $"contact = {LastName} {FirstName}";
        }  
        

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Middlename { get; set;}
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set;}
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Fax { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string ADay { get; set; }
        public string BYear { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }
       
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (ReturnDetailwithRN(Email)  + ReturnDetailwithRN(Email2)  + ReturnDetailwithRN(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

       

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "")+ "\r\n"; 

        }
              
       
        public string AllDetails
        {
            get
            {
                return ((!string.IsNullOrEmpty(FirstName) ? $"{FirstName} " : string.Empty)
                         + (!string.IsNullOrEmpty(Middlename) ? $"{Middlename} " : string.Empty)
                         + (!string.IsNullOrEmpty(LastName) ? $"{LastName}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Nickname) ? $"{Nickname}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Title) ? $"{Title}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Company) ? $"{Company}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Address) ? $"{Address}\r\n\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(HomePhone) ? $"H: {HomePhone}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(MobilePhone) ? $"M: {MobilePhone}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(WorkPhone) ? $"W: {WorkPhone}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Fax) ? $"F: {Fax}\r\n\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Email) ? $"{Email}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Email2) ? $"{Email2}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Email3) ? $"{Email3}\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Homepage) ? $"Homepage:\r\n{Homepage}\r\n\r\n\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Address2) ? $"{Address2}\r\n\r\n" : string.Empty)
                         + (!string.IsNullOrEmpty(Phone2) ? $"P: {Phone2}\r\n\r\n" : string.Empty)
                         + Notes).Trim();

            }
            
            set
            {
                allDetails = value;
            }
        }
            
        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";

        }
  

     
        } 
    }
  }
    

