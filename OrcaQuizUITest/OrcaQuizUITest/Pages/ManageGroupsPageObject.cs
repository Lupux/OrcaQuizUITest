using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class ManageGroupsPageObject : PageObject
    {
        public ManageGroupsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnCreateGroup']")]
        private IWebElement BtnCreateGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtnoGroups']")]
        private IWebElement TxtAreGroups { get; set; }

       
        internal bool ThereAreGroups()
        {
            try
            {
                return TxtAreGroups.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        internal EditGroupPageObject EditGroup(string grpName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='btnEdit_" + grpName+"']")).Click();

            return new EditGroupPageObject();
        }

        internal void DeactivateGroup(string grpName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uites*t='btnDeactivate_" + grpName + "']")).Click();
        }
        internal void ActivateGroup(string grpName)
        {
            PropertiesCollection.driver.FindElement(By.CssSelector("[uites*t='btnActivate_" + grpName + "']")).Click();
        }

        internal bool IsDeactivated(string grpName)
        {
            try
            {
                return PropertiesCollection.driver.FindElement(By.CssSelector("[uitest*='txtIsDeactivated_" + grpName + "']")).Displayed;
            }
            catch (Exception)
            {

                return false;
            }
        }
        internal CreateGroupPageObject ClickCreateGroup()
        {
            BtnCreateGroup.Clicks();
            return new CreateGroupPageObject();
        }
    }
}