using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class ViewUserPageObject: PageObject
    {
        public ViewUserPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.Id, Using = "UI_test_txt_viewBag")]
        public IWebElement TxtViewBag { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_txt_isAdmin")]
        public IWebElement TxtIsAdmin { get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_txt_Self")]
        public IWebElement TxtSelf { get; set; }


        [FindsBy(How = How.Id, Using = "UI_test_btn_ChangeStatus")]
        public IWebElement BtnChangeStatus{ get; set; }

        [FindsBy(How = How.Id, Using = "UI_test_btn_back")]
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
    }
}