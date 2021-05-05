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
    public class BaseClassTests
    {
        protected IWebDriver _webDriver;
        By _firstNameLocator = By.CssSelector("[name = 'first_name']");
        By _secondNameLocator = By.CssSelector("[name = 'last_name']");
        By _emailLocator = By.CssSelector("[name = 'email']");
        By _passwordLocator = By.CssSelector("[name = 'password']");
        By _confirmPasswordLocator = By.CssSelector("[name = 'password_confirm']");
        By _phoneNumberLocator = By.CssSelector("[name = 'phone_number']");
        By _submitButtonSelector = By.CssSelector("[type = 'submit']");


        public string MailGenerator()
        {
            DateTime dataTime = DateTime.Now;
            var mailAdd = dataTime.Year.ToString() + dataTime.Month.ToString() + dataTime.Day.ToString() + dataTime.Hour.ToString() + dataTime.Millisecond.ToString();
            string _validMail = $"{mailAdd}b@gmail.com";
            return _validMail;
        }
        
        public BaseClassTests(IWebDriver driver)
        {
            this._webDriver = driver;            
        }

        public BaseClassTests OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

        public BaseClassTests SetFirstName()
        {
            _webDriver.FindElement(_firstNameLocator).SendKeys("Den");
            return this;
        }

        public BaseClassTests SetSecondName()
        {
            _webDriver.FindElement(_secondNameLocator).SendKeys("DenDen");
            return this;
        }

        public BaseClassTests SetEmail()
        {
            _webDriver.FindElement(_emailLocator).SendKeys(MailGenerator());
            return this;
        }

        public BaseClassTests SetPassword()
        {
            _webDriver.FindElement(_passwordLocator).SendKeys("Test123#");
            return this;
        }

        public BaseClassTests SetConfirmPassword()
        {
            _webDriver.FindElement(_confirmPasswordLocator).SendKeys("Test123#");
            return this;
        }

        public BaseClassTests SetPhomeNumber()
        {
            _webDriver.FindElement(_phoneNumberLocator).SendKeys("123.123.1221");
            return this;
        }

        public BaseClassTests ClickSubmit()
        {
            _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();
            return this;
        }

    }
}
