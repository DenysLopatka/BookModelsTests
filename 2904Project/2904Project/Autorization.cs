using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using _2904Project;

namespace _2904Project
{
    class Autorization
    {              
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    new Registration().TearDown();
        //}

        [Test]
        public void AutorizationTry()
        {
            var _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            _webDriver.FindElement(By.CssSelector("[name = 'email']")).SendKeys("John.Model@gmail.com");
            _webDriver.FindElement(By.CssSelector("[name = 'password']")).SendKeys("Nicenice123@");

            _webDriver.FindElement(By.CssSelector("[type= 'submit']")).Click();

            System.Threading.Thread.Sleep(3000);

            var url = _webDriver.Url;
            Assert.AreEqual("https://newbookmodels.com/explore", url);
        }
    }           
}
