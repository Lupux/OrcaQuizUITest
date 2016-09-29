using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace OrcaQuizUITest.Pages
{
    public class DashboardPageObject : PageObject
    {

        public DashboardPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtIsHome']")]
        public IWebElement TxtIsHome { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "[uitest='txtGroupPermission']")]
        public IWebElement TxtGroupPermission { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtUserPermission']")]
        public IWebElement TxtUserPermission { get; set; }



        [FindsBy(How = How.CssSelector, Using = "[uitest='btnCreateTest']")]
        public IWebElement BtnCreateTest { get; set; }



        internal bool FindIsHome()
        {
            bool result;
            try
            {
                result = TxtIsHome.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
            return result;
        }

        internal bool IsGroupMember(string grpName)
        {
            try
            {
                return PropertiesCollection.driver.FindElement(By.CssSelector("[uitest='txtGroupMembership_"+grpName+"']")).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal CreateTestPageObject CreateTest()
        {
            BtnCreateTest.Clicks();
            return new CreateTestPageObject();
        }

        internal bool FindQuiz(string quizName)
        {
            try
            {
           return PropertiesCollection.driver.FindElement(By.CssSelector("p[uitest*='txtquiz_"+quizName +"']")).Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal TestSessionPageObject TakeTestAsAdmin(string quizName)
        {

            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='btnTakeTestAsAdmin_" + quizName + "']")).Clicks();

            return new TestSessionPageObject();
        }

        internal PublishTestPageObject PublishTest(string quizName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='btnPublish_" + quizName + "']")).Clicks();

            return new PublishTestPageObject();
        }

        internal bool isPublished(string quizName)
        {
            
            try
            {
                return PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='txtIsPublished_" + quizName + "']")).Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal bool HasGroupPermission()
        {

            try
            {
                return TxtGroupPermission.Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
        internal bool HasUserPermission()
        {

            try
            {
                return TxtUserPermission.Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
    }
}