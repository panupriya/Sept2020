using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

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



    }
}
