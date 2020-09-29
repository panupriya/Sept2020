using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.helpers
{
    class CommonDriver
    {
        //int driver;
        public static IWebDriver driver;

        [OneTimeSetUp]
      

        [OneTimeTearDown]
        public void TestClousure()
        {
            // close instances of open chrome driver
            driver.Quit();
        }
    }
}
