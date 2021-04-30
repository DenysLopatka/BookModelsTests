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
    public class Registration
    {
        private IWebDriver _webDriver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void FirstRegistrationPage()
        {
            DateTime dataTime = DateTime.Now;
            var mailAdd = dataTime.Year.ToString() + dataTime.Month.ToString() + dataTime.Day.ToString() + dataTime.Hour.ToString() + dataTime.Millisecond.ToString(); 

            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");

            var nameField = _webDriver.FindElement(By.CssSelector("[name = 'first_name']"));
            nameField.SendKeys("Test");

            var lastNameField = _webDriver.FindElement(By.CssSelector("[name = 'last_name']"));
            lastNameField.SendKeys("Test");

            var emailField = _webDriver.FindElement(By.CssSelector("[name = 'email']"));
            emailField.SendKeys($"{mailAdd}b@laraskey.com");

            var password = _webDriver.FindElement(By.CssSelector("[name = 'password']"));
            password.SendKeys("Test123#");

            var confirmPassword = _webDriver.FindElement(By.CssSelector("[name = 'password_confirm']"));
            confirmPassword.SendKeys("Test123#");

            var phoneNumber = _webDriver.FindElement(By.CssSelector("[name = 'phone_number']"));
            phoneNumber.SendKeys("123.123.1221");

            _webDriver.FindElement(By.CssSelector("[type= 'submit']")).Click();

            System.Threading.Thread.Sleep(3000);

            var url = _webDriver.Url;            

            Assert.AreEqual("https://newbookmodels.com/join/company", url);            
        }

        [Test]
        public void SecondRegistrationPage()
        {

        }
    }
}