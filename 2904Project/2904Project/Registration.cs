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

            //IJavaScriptExecutor js = (IJavaScriptExecutor)_webDriver;

            //const string JS_DROP_FILE = "for(var b=arguments[0],k=arguments[1],l=arguments[2],c=b.ownerDocument,m=0;;){var e=b.getBoundingClientRect(),g=e.left+(k||e.width/2),h=e.top+(l||e.height/2),f=c.elementFromPoint(g,h);if(f&&b.contains(f))break;if(1<++m)throw b=Error('Element not interractable'),b.code=15,b;b.scrollIntoView({behavior:'instant',block:'center',inline:'center'})}var a=c.createElement('INPUT');a.setAttribute('type','file');a.setAttribute('style','position:fixed;z-index:2147483647;left:0;top:0;');a.onchange=function(){var b={effectAllowed:'all',dropEffect:'none',types:['Files'],files:this.files,setData:function(){},getData:function(){},clearData:function(){},setDragImage:function(){}};window.DataTransferItemList&&(b.items=Object.setPrototypeOf([Object.setPrototypeOf({kind:'file',type:this.files[0].type,file:this.files[0],getAsFile:function(){return this.file},getAsString:function(b){var a=new FileReader;a.onload=function(a){b(a.target.result)};a.readAsText(this.file)}},DataTransferItem.prototype)],DataTransferItemList.prototype));Object.setPrototypeOf(b,DataTransfer.prototype);['dragenter','dragover','drop'].forEach(function(a){var d=c.createEvent('DragEvent');d.initMouseEvent(a,!0,!0,c.defaultView,0,0,0,g,h,!1,!1,!1,!1,0,null);Object.setPrototypeOf(d,null);d.dataTransfer=b;Object.setPrototypeOf(d,DragEvent.prototype);f.dispatchEvent(d)});a.parentElement.removeChild(a)};c.documentElement.appendChild(a);a.getBoundingClientRect();return a;";


            //var target = js.FindElement(By.CssSelector("[class^=FileInput]"));

            //IWebElement input = (IWebElement)js.ExecuteScript(JS_DROP_FILE, target, 15, 15);
            //input.SendKeys(@"C:\Users\User\Pictures\download.jfif");

            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.CssSelector("[type = 'submit']")).Click();        

            System.Threading.Thread.Sleep(3000);            

            var url = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", url);
        }
    }
}