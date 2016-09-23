using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OrcaQuizUITest.Tests;
using System;

namespace OrcaQuizUITest.Pages
{
    public class PageObject
    {

        #region Generic Admin dropdown

        // Placeholder for dropdown links UI_test_DDL_Admin
        [FindsBy(How = How.CssSelector, Using = "a[class*= 'UI_test_DDL_Admin']")]
        public IWebElement AdminDropDown { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[class*= 'UI_test_DDL_Admin_Users']")]
        public IWebElement AdminDropDownUser { get; set; }


        [FindsBy(How = How.CssSelector, Using = "a[class*= 'UI_test_DDL_Admin_Groups']")]
        public IWebElement AdminDropDownGroup { get; set; }

        #endregion
        #region Scroll up button
        [FindsBy(How = How.Id, Using = "goTop")]
        public IWebElement BtnGoToTop { get; set; }

        #endregion



        #region Generic all Pages Buttons
        // Generic All pages Button

        [FindsBy(How = How.ClassName, Using = "UI_test_Btn_Home")]
        public IWebElement HomeBtn { get; set; }

        //navbar-brand
        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        public IWebElement TL_HomeBtn { get; set; }
        #endregion

        internal DashboardPageObject TestHomeButton()
        {
            new Actions(PropertiesCollection.driver).MoveToElement(HomeBtn).Release(HomeBtn).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(20));
            wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.ClassName("UI_test_Btn_Home"))).Clicks();

            //HomeBtn.Clicks();

            return new DashboardPageObject();
        }
        internal DashboardPageObject TestHomeLinkButton()
        {
            TL_HomeBtn.Clicks();

            return new DashboardPageObject();
        }

        internal void GoToTop()
        {
            BtnGoToTop.Clicks();
        }

        internal PageObject DDLmenue(AdminChoiseType choice)
        {
            new Actions(PropertiesCollection.driver).MoveToElement(AdminDropDown).Release(AdminDropDown).Build().Perform();
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(10));

            if (choice == AdminChoiseType.ManageGroup)
            {
                wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector("a[class*= 'UI_test_DDL_Admin_Groups']"))).Clicks();
                return new ManageGroupsPageObject();
            }
            if (choice == AdminChoiseType.ManageUsers)
            {
                wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector("a[class*= 'UI_test_DDL_Admin_Users']"))).Clicks();
                return new ManageUserPageObject();
            }
            if (choice == AdminChoiseType.CreateTest)
            {
                return new CreateTestPageObject();
            }
            return null;
        }

    }
}