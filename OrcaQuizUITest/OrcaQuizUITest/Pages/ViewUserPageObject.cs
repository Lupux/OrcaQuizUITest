using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Support.UI;

namespace OrcaQuizUITest.Pages
{
    internal class ViewUserPageObject: PageObject
    {
        public ViewUserPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "[uitest='txtViewBag']")]
        public IWebElement TxtViewBag { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtIsAdmin']")]
        public IWebElement TxtIsAdmin { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtSelf']")]
        public IWebElement TxtSelf { get; set; }


        [FindsBy(How = How.CssSelector, Using = "[uitest='btnChangeStatus']")]
        public IWebElement BtnChangeStatus{ get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnBack']")]
        public IWebElement BtnBack { get; set; }

        internal bool CheckSelf()
        {
            return TxtSelf.Displayed;
        }

        internal ManageUserPageObject GoBack()
        {
            BtnBack.Clicks();
            return new ManageUserPageObject();
        }

        internal bool CheckIsAdmin()
        {
            try
            {
                return TxtIsAdmin.Displayed;
            }
            catch (Exception)
            {

                return false;
            } 
        }

        internal void ChangeStatus()
        {
            BtnChangeStatus.Clicks();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector("[uitest='txtViewBag']")));
        }
    }
}