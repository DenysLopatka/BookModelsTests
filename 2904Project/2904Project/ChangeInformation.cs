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
    public class ChangeInformationTests
    {
        private IWebDriver _webDriver;
        public string _validMail = "";
        
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
          public void CheckPersotalInformationChanges()
          {
                 DateTime dataTime = DateTime.Now;
                 var mailAdd = dataTime.Year.ToString() + dataTime.Month.ToString() + dataTime.Day.ToString() + dataTime.Hour.ToString() + dataTime.Millisecond.ToString();
                 _validMail = $"{mailAdd}b@gmail.com";
           
                 _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
           
                 var nameField = _webDriver.FindElement(By.CssSelector("[name = 'first_name']"));
                 nameField.SendKeys("Test");
           
                 var lastNameField = _webDriver.FindElement(By.CssSelector("[name = 'last_name']"));
                 lastNameField.SendKeys("Test");
           
                 var emailField = _webDriver.FindElement(By.CssSelector("[name = 'email']"));
                 emailField.SendKeys(_validMail + "s");
           
                 var password = _webDriver.FindElement(By.CssSelector("[name = 'password']"));
                 password.SendKeys("Test123#");
           
                 var confirmPassword = _webDriver.FindElement(By.CssSelector("[name = 'password_confirm']"));
                 confirmPassword.SendKeys("Test123#");
           
                 var phoneNumber = _webDriver.FindElement(By.CssSelector("[name = 'phone_number']"));
                 phoneNumber.SendKeys("123.123.1221");
           
                 _webDriver.FindElement(By.CssSelector("[type= 'submit']")).Click();
           
                 System.Threading.Thread.Sleep(3000);                      
           
                 var companyName = _webDriver.FindElement(By.CssSelector("[name = 'company_name']"));
                 companyName.SendKeys("Test");
           
                 var companySite = _webDriver.FindElement(By.CssSelector("[name = 'company_website']"));
                 companySite.SendKeys("Test.com");
           
                 var location = _webDriver.FindElement(By.CssSelector("[name = 'location']"));
                 location.SendKeys("b");
                 _webDriver.FindElement(By.CssSelector("[class = 'pac-item-query']")).Click();
           
                 _webDriver.FindElement(By.CssSelector("[name = 'industry']")).Click();
                 System.Threading.Thread.Sleep(1500);
                 _webDriver.FindElements(By.CssSelector("[role = 'option']"))[2].Click();
                 
                 System.Threading.Thread.Sleep(1000);
                 _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();        
           
                 _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
                 
                 System.Threading.Thread.Sleep(4000);
                 
    
                 var verifyEmail = _webDriver.FindElement(By.CssSelector("[class = 'resend-email__root']"));

                 bool visible = verifyEmail.Displayed;
                 if (visible)
                 {
                     _webDriver.FindElements(By.CssSelector("[class = 'modal__close']"))[6].Click();
                 }
                 
                 _webDriver.FindElement(By.CssSelector("nb-account-info-general-information .edit-switcher__icon_type_edit")).Click();
                 
                 _webDriver.FindElements(By.CssSelector("[placeholder = 'Enter First Name']"))[1].SendKeys("Nice");
                 _webDriver.FindElements(By.CssSelector("[placeholder = 'Enter Last Name']"))[1].SendKeys("Nice");
                 _webDriver.FindElements(By.XPath("/html/body/nb-app/ng-component/nb-internal-layout/common-layout/section/div/ng-component/nb-account-info-edit/common-border/div[1]/div/nb-account-info-general-information/form/div[2]/div/common-google-maps-autocomplete/label/input"))[0].SendKeys(" ");
                 System.Threading.Thread.Sleep(1000);
                 _webDriver.FindElements(By.CssSelector("[class = 'pac-item-query']"))[1].Click();
                 _webDriver.FindElements(By.CssSelector("[placeholder='Enter Industry']"))[1].SendKeys("Nice");
                 _webDriver.FindElements(By.CssSelector("[type='submit']"))[0].Click();

                 var actualFirstName = _webDriver
                     .FindElements(By.CssSelector("nb-account-info-general-information .edit-switcher__icon_type_edit"))[1]
                     .GetAttribute("value");
                 
                 var actualLastName = _webDriver
                     .FindElements(By.CssSelector("[placeholder = 'Enter Last Name']"))[1]
                     .GetAttribute("value");
                 
                 var actualIndustry = _webDriver
                     .FindElements(By.CssSelector("[placeholder='Enter Industry']"))[1]
                     .GetAttribute("value");
                 
                 CollectionAssert:
                 {
                     Assert.AreEqual("testNice", actualFirstName);
                     Assert.AreEqual("testNice", actualLastName);
                     Assert.AreEqual("cosmeticsNice", actualFirstName);
                 }
          }
    }
}

