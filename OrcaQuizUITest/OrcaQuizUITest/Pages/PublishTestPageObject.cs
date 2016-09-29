using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace OrcaQuizUITest.Pages
{
    internal class PublishTestPageObject
    {
        public PublishTestPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnBack']")]
        private IWebElement BtnBack { get; set; }


        internal PublishTestPageObject PublishToGroup(string groupName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*= 'btnPublishToGroup_" + groupName + "']")).Clicks();

            return this;
        }

        internal PublishTestPageObject PublishToUser(string usr)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*= 'btnPublishToUser_" + usr + "']")).Clicks();

            return this;
        }

        internal bool isPublishedToUser(string usr)
        {
            PropertiesCollection.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            try
            {
                return PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*= 'btnUnPublishToUser_" + usr + "']")).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }


        internal PublishTestPageObject UnPublishToUser(string usr)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*= 'btnUnPublishToUser_" + usr + "']")).Clicks();

            return this;
        }


        internal DashboardPageObject ReturnBack()
        {
            BtnBack.Clicks();

            return new DashboardPageObject();
        }

    }
}