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
        
    }
}
