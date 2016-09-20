using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OrcaQuizUITest.Pages
{
    public class DashboardPageObject
    {

        public DashboardPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "UI_Test_Btn_CreateTest")]
        public IWebElement CreateTestBtn { get; set; }


        #region Generic Admin dropdown

        // Placeholder for dropdown links

        #endregion


        #region Generic all Pages Buttons
        // Generic All pages Button
        // Top Left corner Button
        [FindsBy(How = How.Id, Using = "Home")]
        public IWebElement TL_HomeBtn { get; set; }
        #endregion

        public bool FindCreateTestBtn()
        {
            return CreateTestBtn.Displayed;
        }

    }
}