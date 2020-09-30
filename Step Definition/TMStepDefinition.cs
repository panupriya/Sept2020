using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace September2020.Step_Definition
{
    [Binding]
    public sealed class TMStepDefinition
    {
        IWebDriver driver;

        [BeforeScenario]
        public void LoginToTurnup()
        {
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)   
            // web driver
            driver = new ChromeDriver();

            //obj init and define for loginpage
            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);
            Thread.Sleep(1000);
        }

        [AfterScenario]
        public void Dispose()
        {
            // close the window and release the memory
            driver.Dispose();
        }

        /*[Given(@"I navigate to the Hourse portal")]
        public void GivenINavigateToTheHoursePortal()
        {
           driver = new ChromeDriver();

            //obj init and define for loginpage
            LoginPage loginObject = new LoginPage();
            loginObject.LoginSteps(driver);
        }*/

        
        [Given(@"I navigate to the TM")]
        public void GivenINavigateToTheTM()
        {
            var homepage = new HomePage();
            homepage.NavigateToTM(driver);
            Thread.Sleep(1000);
        }
        [Given(@"I navigate to create new page")]
        public void GivenINavigateToCreateNewPage()
        {
            var TMPage = new TMpage();
            TMPage.CreateTM(driver);

        }

        [When(@"I create entry using code : '(.*)' and desc: '(.*)'")]
        public void WhenICreateEntryUsingCodeAndDesc(string code, string desc)
        {
            var TMPage = new TMpage();
            TMPage.CreateTMWithValues(driver, code, desc);
        }

        [Then(@"I am able to verify entry with code : '(.*)'")]
        public void ThenIAmAbleToVerifyEntryWithCode(string code)
        {
            var TMPage = new TMpage();
            var result = TMPage.IsRecordCreated(driver,code);

            Assert.IsTrue(result, "NO TM Record created for code : " + code);
        }


        [When(@"I create entries using values from table :")]
        public void WhenICreateEntriesUsingValuesFromTable(Table table)
        {

            var data = table;
            var TMPage = new TMpage();
            var x = data.Rows[0][0]; // code
            //data.Rows[0].items[1] // desc

            //data.Rows;
            //for (var i = 0; i < data.Rows.Count; i++)
            //{
            //    code = data.Rows[0].Values
            //    TMPage.CreateTMWithValues(driver, code, desc);
            //}
        }

    }
}
