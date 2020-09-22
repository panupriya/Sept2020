using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.test
{
    [TestFixture]
    class CompanyTests
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
        public void CreateNewCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);

            // Test 1- check if the user is able to create company successfully

            //obj init and define for createTM
            CompanyPage createCompanyObj = new CompanyPage();
            createCompanyObj.CreateCompany(driver);

        }
        [Test]
        public void EditCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);



            // Test 2- check if the user is able to edit company successfully
            CompanyPage editCompanyObj = new CompanyPage();
            editCompanyObj.EditCompany(driver);



        }
        [Test]
        public void DeleteCompanyTests()
        {
            //obj init and define for home page
            HomePage homepageobj = new HomePage();
            homepageobj.NavigateToCompany(driver);


            // Test 3- check if the user is able to delete Company successfully
            CompanyPage deleteCompanyObj = new CompanyPage();
            deleteCompanyObj.DeleteCompany(driver);

        }
        [TearDown]
        public void TestClousure()
        {
            // close instances of open chrome driver
            driver.Quit();

        }
    }
}
