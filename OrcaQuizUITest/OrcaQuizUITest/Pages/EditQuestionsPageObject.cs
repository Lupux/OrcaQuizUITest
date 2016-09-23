using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class EditQuestionsPageObject : PageObject
    {
        public EditQuestionsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.Id, Using = "dropQuestionType")]
        private IWebElement DDLQuestionType { get; set; }

        [FindsBy(How = How.Id, Using = "SortOrder")]
        private IWebElement TxtSortOrder { get; set; }

        [FindsBy(How = How.Id, Using = "HasComment")]
        private IWebElement CheckBoxHasComment { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_saveQ']")]
        private IWebElement BtnSaveQuestion { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_btn_backToHome']")]
        private IWebElement BtnBackHome { get; set; }


        [FindsBy(How = How.CssSelector, Using = "button[class*= 'close']")]
        private IWebElement BtnModalX { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Modal_btn_Cancel']")]
        private IWebElement BtnModalCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Modal_btn_RemoveQ']")]
        private IWebElement BtnModalRemoveQuestion { get; set; }

    }
}