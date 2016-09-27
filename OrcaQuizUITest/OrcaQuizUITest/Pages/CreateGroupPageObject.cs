using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class CreateGroupPageObject
    {
        public CreateGroupPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "groupName")]
        private IWebElement TxtGroupName { get; set; }

        [FindsBy(How = How.Id, Using = "userEmails")]
        private IWebElement TxtuserEmails { get; set; }

        [FindsBy(How = How.Id, Using = "saveButton")]
        private IWebElement BtnSavebutton { get; set; }


        internal CreateGroupPageObject FillCreateGroupForm(string name, string users)
        {
            TxtGroupName.EnterText(name);
            TxtuserEmails.EnterText(users);

            return this;
        }

        internal EditGroupPageObject SaveNewGroup()
        {
            BtnSavebutton.Clicks();

            return new EditGroupPageObject();
        }


    }
}