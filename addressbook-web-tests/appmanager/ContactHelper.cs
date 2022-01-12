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
            string allPhones = cells[5].Text;
            return new ContactsData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };

        }

        public ContactsData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactsData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone

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
        public ContactHelper Remove(int v)
        {
            SelectContcats(v);
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
            Type(By.Name("email"), group.Email);
            return this;
        }

        public int GetNumberOfSearchResult()

        {
            manager.Navigator.GoToHomePage();
            string text =driver.FindElement(By.TagName("label")).Text;
            Match m= new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
