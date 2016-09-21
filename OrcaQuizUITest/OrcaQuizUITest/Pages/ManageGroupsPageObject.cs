using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace OrcaQuizUITest.Pages
{
    internal class ManageGroupsPageObject : PageObject
    {
        public ManageGroupsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


    }
}