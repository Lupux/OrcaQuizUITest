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

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_CreateGroup']")]
        private IWebElement BtnCreateGroup { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_txt_noGroups")]
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
            PropertiesCollection.driver.FindElement(By.CssSelector("button[class*= 'Ui_test_btn_Edit_" + grpName+"']")).Click();

            return new EditGroupPageObject();
        }

        internal void DeactivateGroup(string grpName)
        {
            PropertiesCollection.driver.FindElement(By.Id("btn_Deactivate_" + grpName)).Click();
        }
        internal void ActivateGroup(string grpName)
        {
            PropertiesCollection.driver.FindElement(By.Id("btn_Activate_" + grpName)).Click();
        }

        internal bool IsDeactivated(string grpName)
        {
            try
            {
                return PropertiesCollection.driver.FindElement(By.Id("Txt_IsDeactivated_" + grpName)).Displayed;
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