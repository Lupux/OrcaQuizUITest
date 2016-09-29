using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class ManageUserPageObject: PageObject
    {
        public ManageUserPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "SearchTerm")]
        public IWebElement TxtSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnSearch']")]
        public IWebElement BtnSearch { get; set; }


        internal ManageUserPageObject TestSearch(string SearchTerm)
        {
            TxtSearch.EnterText(SearchTerm);

            BtnSearch.Clicks();

            return this;
        }

        internal ViewUserPageObject GetUserPage(string target)
        {
            PropertiesCollection.driver.FindElement(By.Id(target)).Click();

            return new ViewUserPageObject();
        }
    }
}