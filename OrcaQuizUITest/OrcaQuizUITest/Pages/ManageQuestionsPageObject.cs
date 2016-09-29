using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest.Pages
{
    internal class ManageQuestionsPageObject : PageObject
    {
        public ManageQuestionsPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "button[class*= 'UI_test_Btn_Back_top']")]
        private IWebElement BtnBack { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='txtISPublished']")]
        public IWebElement TxtIsPublished { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnAddQuestion']")]
        private IWebElement BtnAddQuestion { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "[uitest='btnImportQuestion']")]
        private IWebElement BtnImportQuestion { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnBackToHome']")]
        private IWebElement BtnBackHome { get; set; }

        
        [FindsBy(How = How.CssSelector, Using = "[uitest='btnManageQuizSettings']")]
        private IWebElement BtnManageQuizSettings { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[uitest='btnPublishTest']")]
        private IWebElement BtnPublish { get; set; }



        internal EditQuestionsPageObject AddQuestion()
        {
            BtnAddQuestion.Clicks();

            return new EditQuestionsPageObject();
        }

        internal  DashboardPageObject ReturnToDashboard()
        {
            BtnBackHome.Clicks();
            return new DashboardPageObject();
        }

        internal CreateTestPageObject ViewQuizSettings()
        {
            BtnManageQuizSettings.Clicks();
            return new CreateTestPageObject();
        }


    }

}