﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.PageObjects
{
    public class MainPage
    {
        private IWebDriver driver;
        private const string uri = @"https://skay.ua/";
        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        private IWebElement loginLink;

        private MainPage(IWebDriver driver)
        {
            this.driver = driver;

#pragma warning disable CS0618 // Type or member is obsolete
            PageFactory.InitElements(this.driver, this);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static MainPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(uri);

            return new MainPage(driver);
        }

        public LoginPage GoToLogin()
        {
            loginLink.Click();

            return LoginPage.InitializeLoginPage(driver);
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}
