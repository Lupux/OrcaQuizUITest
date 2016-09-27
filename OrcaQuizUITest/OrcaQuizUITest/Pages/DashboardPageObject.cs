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

        [FindsBy(How = How.ClassName, Using = "UI_test_txt_isHome")]
        public IWebElement TxtIsHome { get; set; }

        [FindsBy(How = How.ClassName, Using = "UI_Test_Btn_CreateTest")]
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
                return PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_txt_groupMembership_"+grpName+"']")).Displayed;
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
           return PropertiesCollection.driver.FindElement(By.CssSelector("[class*= '"+quizName + "']")).Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal TestSessionPageObject TakeTestAsAdmin(string quizName)
        {

            PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_takeTestAsAdmin_" + quizName + "']")).Clicks();

            return new TestSessionPageObject();
        }

        internal PublishTestPageObject PublishTest(string quizName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_btn_publish_" + quizName + "']")).Clicks();

            return new PublishTestPageObject();
        }

        internal bool isPublished(string quizName)
        {
            
            try
            {
                return PropertiesCollection.driver.FindElement(By.CssSelector("[class*= 'UI_test_txt_IsPublished_" + quizName + "']")).Displayed;

            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
    }
}