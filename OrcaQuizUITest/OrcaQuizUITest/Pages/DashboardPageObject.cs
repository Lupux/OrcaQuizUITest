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
                return PropertiesCollection.driver.FindElement(By.ClassName("UI_test_txt_groupMembership_"+grpName)).Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }
    }
}