using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {
            protected IWebDriver driver;
            private StringBuilder verificationErrors;
            protected string baseURL;

        [SetUp]
            public void SetupTest()
            {
                driver = new FirefoxDriver();
                baseURL = "https://www.google.com/";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }
        protected void goToHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/");
        }
        protected void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        protected void GoToGroupPages()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void SelectGroups(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
        protected void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        protected void FillGroupForm(GroupDate group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        protected void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        protected void FillContactForm(ContactsDate group)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(group.FirstName);
            driver.FindElement(By.Name("lastname")).SendKeys(group.LastName);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(group.Address);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys(group.Mobile);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(group.Email);
        }
        protected void GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        protected void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
        protected void ReturnToAddNewPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}

