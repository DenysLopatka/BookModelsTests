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
    class MakeChangesPage
    {
        public IWebDriver _webDriver;
        private static readonly By _changeGeneralInfIconLocator = By.CssSelector("nb-account-info-general-information .edit-switcher__icon_type_edit");
        private static readonly By _generalInfoLocator = By.CssSelector()

        public MakeChangesPage(IWebDriver driver)
        {
            this._webDriver = driver;
        }
        public MakeChangesPage OpenPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }
        


    }
}
