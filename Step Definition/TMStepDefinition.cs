using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.helpers;
using September2020.pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace September2020.Step_Definition
{
    [Binding]
    public sealed class TMStepDefinition
    {
        IWebDriver driver;
        private Context _context;

        public TMStepDefinition()
        {
            _context = new Context();
        }

        [BeforeScenario]
        public void LoginToTurnup()
        {
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)   
            // web driver

            // option : NoCookies , Nocache. 

            // If you search of a mouse of Amazon. Dell. 30 seconds. 15 seconds. 

            // Chrome that sohuld replicate a fresh env. 


 

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


        [When(@"I create entry using code code: '(.*)' and desc: '(.*)'")]
        public void WhenICreateEntryUsingCodeCodeAndDesc(string code, string desc)
        {
            var TMPage = new TMpage();
            var randomCode = TMPage.CreateRandomCode();
            // share it with THEN Step below
            _context.Code = randomCode;
            _context.Desc = randomCode + "desc";


            TMPage.CreateTMWithValues(driver, _context.Code, _context.Desc);
        }


        [Then(@"I am able to verify with code: '(.*)'")]
        public void ThenIAmAbleToVerifyWithCode(string code)
        {
            var TMPage = new TMpage();
            
            var result = TMPage.IsRecordCreated(driver, _context.Code);
            Assert.IsTrue(result, "NO TM Record created for code : " +  _context.Code);
        }


      
        [When(@"I created entries using values from table :")]
        public void WhenICreatedEntriesUsingValuesFromTable(Table table)
        {
            var code = string.Empty;
            var desc = string.Empty;
            var data = table;
            var TMPage = new TMpage();

            for (var i = 0; i < data.Rows.Count; i++)
            {
                code = data.Rows[i]["code"];
                desc = data.Rows[i]["desc"];
                TMPage.CreateTMWithValues(driver, code, desc);
            }

        }


    }
}
