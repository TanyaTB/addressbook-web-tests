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
        private string allEmail;
        private string allDetails;

        public ContactsData (string firstname,string middlename, string lastname, string address, string mobile, string email, string work, string home,string title)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            HomePhone = home;
            MobilePhone = mobile;
            WorkPhone = work;
            Email = email;
            Middlename = middlename;
            Title = title;


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

        public ContactsData(string name)
        {
            FirstName = name;
        }

        public ContactsData(string firstname, string lastName )
        {
            FirstName = firstname;
            LastName = lastName;



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


        public string GetAge(string day, string month, string year, string fieldName)
        {
            int monthNumber = 0;
            int Age;
            switch (month)
            {
                case "January":
                    monthNumber = 1;
                    break;
                case "February":
                    monthNumber = 2;

                    break;
                case "March":
                    monthNumber = 3;

                    break;
                case "April":
                    monthNumber = 4;

                    break;
                case "May":
                    monthNumber = 5;

                    break;
                case "June":
                    monthNumber = 6;

                    break;
                case "July":
                    monthNumber = 7;

                    break;
                case "August":
                    monthNumber = 8;

                    break;
                case "September":
                    monthNumber = 9;

                    break;
                case "October":
                    monthNumber = 10;

                    break;
                case "November":
                    monthNumber = 11;

                    break;
                case "December":
                    monthNumber = 12;

                    break;
            }
            if (year != "")
            {
                if ((DateTime.Now.Month >= monthNumber) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }
        public string GetAnniversary(string day, string month, string year, string fieldName)
        {
            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != null && year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
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
                    return (ReturnDetailwithBr(Email)  + ReturnDetailwithBr(Email2)  + ReturnDetailwithBr(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

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
                    return (ReturnDetailwithRN(HomePhone) + ReturnDetailwithRN(MobilePhone) + ReturnDetailwithRN(WorkPhone)).Trim();
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
            return Regex.Replace(phone, "[ -()]", "")+ "\r\n"; 

            //  (" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";

        }
              
       
        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails.Replace("\r", "").Replace("\n", "");
                }
                else
                {
                    return (ReturnFullName(FirstName, Middlename, LastName)
                        + ReturnDetailwithBr(Title) 
                        + ReturnDetailwithRN(Address) 
                        + ReturnDetailwithBr(HomePhone, "H: ") 
                        + ReturnDetailwithBr(MobilePhone, "M: ") 
                        + ReturnDetailwithBr(WorkPhone, "W: ") 
                        + ReturnDetailwithBr(Email) 
                        + ReturnDetailwithBr(Email2) 
                        + ReturnDetailwithBr(Email3) 
                        + ReturnDetailwithoutBr(Notes)).Replace("\r","").Replace("\n", "");

                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string Nickname { get;set; }
        public string Company { get;set; }
        public string Title { get;set; }
        public string Fax { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get;  set; }
        public string Homepage { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string ADay { get; set; }
        public string BYear { get; set; }
        public string AMonth { get; set; }
        public string AYear { get;  set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get;  set; }

        public string ReturnDetailwithBr(string text, string prefix = "")
        {
            if (text == null || text == "")
            {
                return "";
            }
            return prefix + text;

        }
        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";

        }


       // public string ReturnDetailwithBr(string text, string fieldName)
       // {
       //     if (text == null || text == "")
        //    {
        //        return "";
        //    }
        //    return text + "\r\n";
      //  }

        public string ReturnDetailwithoutBr(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }


        public string ReturnFullName(string name, string middlename, string lastname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
                if (FullName != "")
                {
                    FullName += " " + middlename;
                }
                else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName; 
        } 
    }
  }
    

