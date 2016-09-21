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

        [FindsBy(How = How.Id, Using = "UI_Test_Btn_CreateTest")]
        public IWebElement CreateTestBtn { get; set; }


        internal bool FindCreateTestBtn()
        {
            bool result;
            try
            {
                result = CreateTestBtn.Displayed;
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
                return PropertiesCollection.driver.FindElement(By.Id("UI_test_txt_groupMembership_"+grpName)).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
    }
}