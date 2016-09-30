using System;
using NUnit.Framework;
using OrcaQuizUITest.Tests;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace OrcaQuizUITest
{
    [SetUpFixture]
    class UITestFixture
    {
        [OneTimeSetUp]
        public void RunBeforAnyTest()
        {

            ////Local version URL:
            string url = "http://localhost:27015/" + "Maintenance/InitLocalUITestSession";

            // Expect a ready from page to verify that db is cleared and default admin is setup. 
            var result = GetString(url);

            if (result != "Ready")
            {
                throw new InvalidOperationException();

            }


            //PropertiesCollection.driver.Close();

        }

        [OneTimeTearDown]
        public void RunAfterAnyTest()
        {

        }

        private string GetString(string url)
        {
            using (var client = new WebClient())
            {
                return client.DownloadStringTaskAsync(url).Result;
            }
        }



    }
}
