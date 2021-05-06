using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace _2904Project
{
    public class Registration
    {
        
        public string _validMail = "";
        private ChromeDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);  
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    _webDriver.Quit();
        //}

        [Test]
        public void FirstRegistrationPage()
        {
            var registrationPage = new RegistrationPage(_webDriver);
            registrationPage.OpenPage()
            .SetFirstName("Den")
            .SetSecondName("Dende")
            .SetEmail()
            .SetPassword("Nicenice123#")
            .SetConfirmPassword("Nicenice123#")
            .SetPhomeNumber("111.111.1111")
            .ClickSubmit();

            var url = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", url);            
        }

        [Test]
        public void SecondRegistrationPage()
        {
            var registrationPage = new RegistrationPage(_webDriver);
            registrationPage.OpenPage()
            .SetFirstName("Den")
            .SetSecondName("Dende")
            .SetEmail()
            .SetPassword("Nicenice123#")
            .SetConfirmPassword("Nicenice123#")
            .SetPhomeNumber("111.111.1111")
            .ClickSubmit();
            
            
            System.Threading.Thread.Sleep(3000);



            var registrationSecondPage = new RegistrationPage(_webDriver);
            registrationSecondPage.SetCompanyName("INC inc.")
                .SetCompanySite("incinc.com")
                .SetLocationField("b")
                .SetIndustryLocator()
                .Submit();

               

            System.Threading.Thread.Sleep(3000);            

            var url = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", url);
        }
    }
}