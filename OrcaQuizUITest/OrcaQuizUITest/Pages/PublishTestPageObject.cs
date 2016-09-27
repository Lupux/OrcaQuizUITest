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

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_back']")]
        private IWebElement BtnBack { get; set; }


        internal PublishTestPageObject PublishToGroup(string groupName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_publishToGroup_" + groupName + "']")).Clicks();

            return this;
        }

        internal PublishTestPageObject PublishToUser(string usr)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_publishToUser_" + usr + "']")).Clicks();

            return this;
        }

        internal bool isPublishedToUser(string usr)
        {
            try
            {
                new Actions(PropertiesCollection.driver).MoveToElement(PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_unPublishToUser_" + usr + "']")))
                    .Release(PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_unPublishToUser_" + usr + "']"))).Build().Perform();
                WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
                wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector("[class*= 'UI_test_btn_unPublishToUser_" + usr + "']")));

                return PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_unPublishToUser_" + usr + "']")).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }


        internal PublishTestPageObject UnPublishToUser(string usr)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_unPublishToUser_" + usr + "']")).Clicks();

            return this;
        }


        internal DashboardPageObject ReturnBack()
        {
            BtnBack.Clicks();

            return new DashboardPageObject();
        }

    }
}