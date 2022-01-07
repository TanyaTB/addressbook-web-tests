using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ContactHelper Create(ContactsData contactData)
        {
            InitNewContactCreation();
            FillContactForm(contactData);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public List<ContactsData> GetContactList()
        {
            List<ContactsData> contacts = new List<ContactsData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                contacts.Add(new ContactsData(element.Text, null));
                Console.WriteLine(element.Text);
                IList<IWebElement> lastnames = element.FindElements(By.CssSelector("td:nth-child(2)"));
                IList<IWebElement> firstnames = element.FindElements(By.CssSelector("td:nth-child(3)"));
                foreach (IWebElement lastname in lastnames) foreach (IWebElement firstname in firstnames)
                    {
                        contacts.Add(new ContactsData(firstname.Text, lastname.Text));
                    }

            }
            return contacts;
        }
        public ContactHelper Modify(ContactsData newData)
        {
            GoToAddNewPage();
            FillContactForm(newData);
            SubmitContactCreation();
            ReturnToAddNewPage();
            return this;
                   }
        public ContactHelper Remove(int v)
        {
            SelectContcats(v);
            RemoveContact();
            return this;
        }
        public ContactHelper SelectContcats(int index)
        {
            driver.FindElement(By.LinkText("home")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
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
       
        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactsData group)
        {
            Type(By.Name("firstname"), group.FirstName);
            Type(By.Name("lastname"), group.LastName);
            Type(By.Name("address"), group.Address);
            Type(By.Name("mobile"), group.Mobile);
            Type(By.Name("email"), group.Email);
            return this;
        }
       
    }
}
