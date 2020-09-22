using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Threading;

namespace september2020
{
   
    [TestFixture]
   class Program
    {
       
        //int driver;
        IWebDriver driver;

        [SetUp]
            public void LoginToTurnup()
            {
                //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)   
                // web driver
                driver = new ChromeDriver();

                //obj init and define for loginpage
                LoginPage loginObject = new LoginPage();
                loginObject.LoginSteps(driver);

            }
            [Test]
            public void CreateNewTMTests()
            {
                //obj init and define for home page
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);

                // Test 1- check if the user is able to create time successfully

                //obj init and define for createTM
                TMpage createTmObj = new TMpage();
                createTmObj.CreateTM(driver);

            }
            [Test]
            public void EditTMTests()
            {
                //obj init and define for home page
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);



                // Test 2- check if the user is able to edit time successfully
                TMpage editTmObj = new TMpage();
                editTmObj.EditTM(driver);



            }
            [Test]
            public void DeleteTMTests()
            {
                //obj init and define for home page
                HomePage homepageobj = new HomePage();
                homepageobj.NavigateToTM(driver);


                // Test 3- check if the user is able to delete time successfully
                TMpage deleteTmObj = new TMpage();
                deleteTmObj.DeleteTM(driver);

            }
            [TearDown]
            public void TestClousure()
            {
                // close instances of open chrome driver
                driver.Quit();
            }
        
    }
}









