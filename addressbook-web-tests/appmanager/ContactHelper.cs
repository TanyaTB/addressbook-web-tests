using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactsData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                 .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactsData(firstName, lastName)
            {
                Address = address,
                AllEmail = allEmail,
                AllPhones = allPhones

            };

        }

        internal void AddContactToGroup(ContactsData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContcats(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        public void SelectContcats(string ContactId)
        {
            driver.FindElement(By.Id(ContactId)).Click();
        }

        public string GetContactInformationProperties()
        {
            manager.Navigator.GoToHomePage();
            ContactsDetailsProperties(0);
            string AllDetails = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            return AllDetails;
        }

        public void DeleteContactFromGroup(ContactsData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupInFilter(group.Name);
            SelectContacts(contact.Id);
            CommitDeletingContactFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }
        private void SelectGroupInFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        private void CommitDeletingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public ContactsData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[2]/option[1]")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[1]")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).Text;
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).Text;

            return new ContactsData(firstName.Trim(), lastName.Trim())
            {
                Middlename = middleName,
                Nickname = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                BDay = bday,
                BMonth = bmonth,
                BYear = byear,
                ADay = aday,
                AMonth = amonth,
                AYear = ayear,
                Address2 = address2,
                Phone2 = phone2,
                Notes = notes
            };
        }

    
        public ContactHelper Create(ContactsData contactData)
        {
            InitNewContactCreation();
            FillContactForm(contactData);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;

        }
        private List<ContactsData> contactCache = null;
        public List<ContactsData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactsData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    //IWebElement lastname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    //IWebElement firstname = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    //второй вариант реализации
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    IWebElement lastname = cells[1];
                    IWebElement firstname = cells[2];
                    contactCache.Add(new ContactsData(firstname.Text, lastname.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactsData>(contactCache);
        }
        public ContactHelper Modify(ContactsData newData)
        {
            SelectContcats(0);
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(ContactsData contact, ContactsData newData)
        {
            SelectContcats(0);
            InitContactModification(contact.Id);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            SelectContcats(v);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper Remove(ContactsData contact)
        {
            SelectContacts(contact.Id);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SelectContcats(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
       
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }
        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper ReturnToAddNewPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            //driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper ContactsDetailsProperties(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
       
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactsData group)
        {
            Type(By.Name("firstname"), group.FirstName);
            Type(By.Name("lastname"), group.LastName);
            Type(By.Name("address"), group.Address);
            Type(By.Name("mobile"), group.MobilePhone);
            Type(By.Name("home"), group.HomePhone);
            Type(By.Name("email"), group.Email);
            Type(By.Name("middlename"), group.Middlename);
            Type(By.Name("title"), group.Title);

            return this;
        }

        public int GetNumberOfSearchResult()

        {
            manager.Navigator.GoToHomePage();
            string text =driver.FindElement(By.TagName("label")).Text;
            Match m= new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
        private ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("//tr[./td[./input[@name='selected[]' and @value='" + id + "']]]"))
                .FindElement(By.XPath(".//img[@alt='Edit']")).Click();

            return this;
        }
        public ContactHelper SelectContacts(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value='" + id + "']")).Click();
            return this;
        }
    }
}
