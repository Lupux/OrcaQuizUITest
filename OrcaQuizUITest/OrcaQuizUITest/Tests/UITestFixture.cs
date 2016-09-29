using System;
using NUnit.Framework;
using OrcaQuizUITest.Tests;

namespace OrcaQuizUITest
{
    [SetUpFixture]
    class UITestFixture
    {
        [OneTimeSetUp]
        public void RunBeforAnyTest()
        {
            // here be code for emptying database...
            SqlSupport.ClearDb();
          
        }

        [OneTimeTearDown]
        public void RunAfterAnyTest()
        {

        }


    }
}
