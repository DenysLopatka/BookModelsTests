using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace _2904Project
{
    public class RegistrationPage
    {
        public IWebDriver _webDriver;
        private static readonly By _firstNameLocator = By.CssSelector("[name = 'first_name']");
        private static readonly By _secondNameLocator = By.CssSelector("[name = 'last_name']");
        private static readonly By _emailLocator = By.CssSelector("[name = 'email']");
        private static readonly By _passwordLocator = By.CssSelector("[name = 'password']");
        private static readonly By _confirmPasswordLocator = By.CssSelector("[name = 'password_confirm']");
        private static readonly By _phoneNumberLocator = By.CssSelector("[name = 'phone_number']");
        private static readonly By _submitButtonSelector = By.CssSelector("[type = 'submit']");
        
        private static readonly By _companyNameLocator = By.CssSelector("[name = 'company_name']");
        private static readonly By _companySiteLocator = By.CssSelector("[name = 'company_website']");
        private static readonly By _locationFieldLocator = By.CssSelector("[name = 'location']");
        private static readonly By _industryLocator = By.CssSelector("[name = 'industry']");
        private static readonly By _industryOptionLocator = By.CssSelector("[role = 'option']");
        private static readonly By _secondPageSubmitButton = By.CssSelector("[type = 'submit']");
        public string MailGenerator()
        {
            DateTime dataTime = DateTime.Now;
            var mailAdd = dataTime.Year.ToString() + dataTime.Month.ToString() + dataTime.Day.ToString() + dataTime.Hour.ToString() + dataTime.Millisecond.ToString();
            string _validMail = $"{mailAdd}b@gmail.com";
            return _validMail;
        }
        
        public RegistrationPage(IWebDriver driver)
        {
            this._webDriver = driver;            
        }

        public RegistrationPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

        public RegistrationPage SetFirstName(string name)
        {
            _webDriver.FindElement(_firstNameLocator).SendKeys(name);
            return this;
        }

        public RegistrationPage SetSecondName(string secondname)
        {
            _webDriver.FindElement(_secondNameLocator).SendKeys(secondname);
            return this;
        }

        public RegistrationPage SetEmail()
        {
            _webDriver.FindElement(_emailLocator).SendKeys(MailGenerator());
            return this;
        }

        public RegistrationPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordLocator).SendKeys(password);
            return this;
        }

        public RegistrationPage SetConfirmPassword(string confirmPassword)
        {
            _webDriver.FindElement(_confirmPasswordLocator).SendKeys(confirmPassword);
            return this;
        }

        public RegistrationPage SetPhomeNumber(string number)
        {
            _webDriver.FindElement(_phoneNumberLocator).SendKeys(number);
            return this;
        }

        public RegistrationPage ClickSubmit()
        {
            _webDriver.FindElement(_submitButtonSelector).Click();
            return this;
        }

        public RegistrationPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companySiteLocator).SendKeys(companyName);
            return this;
        }

    }
}
