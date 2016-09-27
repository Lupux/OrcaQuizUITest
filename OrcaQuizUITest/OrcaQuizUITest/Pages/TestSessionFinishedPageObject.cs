using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OrcaQuizUITest.Pages
{
    internal class TestSessionFinishedPageObject
    {
        public TestSessionFinishedPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);

        }

        [FindsBy(How = How.CssSelector, Using = "h2[class*= 'UI_test_txt_success']")]
        private IWebElement TxtSuccess { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h2[class*= 'UI_test_txt_fail']")]
        private IWebElement TxtFail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_home']")]
        private IWebElement BtnHome { get; set; }


        internal bool TestSuccsess()
        {
            try
            {
                return TxtSuccess.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal DashboardPageObject ClickHomeBtn()
        {
            BtnHome.Clicks();

            return new DashboardPageObject();
        }




    }
}