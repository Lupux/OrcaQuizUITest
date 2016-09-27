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
            SqlSupport.ClearDb1();
            SqlSupport.ClearDb2();
            SqlSupport.ClearDb3();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTest()
        {

        }


    }
}
