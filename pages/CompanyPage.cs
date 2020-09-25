using NUnit.Framework;
using OpenQA.Selenium;
using September2020.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.pages
{
    class CompanyPage
    {
        public void CreateCompany(IWebDriver driver)
        {
            try
            {
                //click createnew company
                IWebElement createnewCompany = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createnewCompany.Click();

                wait.WaitForElement(driver, "XPath", "//*[@id='Name']", 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("test fails at createnew company", ex.Message);
            }

            //input company name
            IWebElement name = driver.FindElement(By.XPath("//*[@id='Name']"));
            name.SendKeys("ABC LTD");
            
            wait.WaitForElement(driver, "XPath", "//*[@id='EditContactButton']", 5);

            //EditCompany contact
            IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='EditContactButton']"));
            editbutton.Click();

             wait.WaitForElement(driver, "XPath", "//*[@id='contactDetailWindow']/iframe", 20);

            //switch to contact details window
            IWebElement iframe = driver.FindElement(By.XPath("//*[@id='contactDetailWindow']/iframe"));

            driver.SwitchTo().Frame(iframe);

            //input contact details
            IWebElement firstName = driver.FindElement(By.Id("FirstName"));
            firstName.SendKeys("Abc");
            wait.WaitForElementVisibility(driver, "Id", "LastName", 5);


            IWebElement lastName = driver.FindElement(By.Id("LastName"));
            lastName.SendKeys("Def");
            wait.WaitForElementVisibility(driver, "Id", "PreferedName", 5);

            IWebElement preferedName = driver.FindElement(By.Id("PreferedName"));
            preferedName.SendKeys("Abc");
            wait.WaitForElementVisibility(driver, "Id", "Phone", 5);


            IWebElement phone = driver.FindElement(By.Id("Phone"));
            phone.SendKeys("0435407521");
            wait.WaitForElementVisibility(driver, "Id", "Mobile", 5);


            IWebElement mobile = driver.FindElement(By.Id("Mobile"));
            mobile.SendKeys("9746142692");
            /*wait.WaitForElementVisibility(driver, "Id", "mail", 5);

            IWebElement mail = driver.FindElement(By.Id("mail"));
            mobile.SendKeys("abc@gmail.com");*/
            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='autocomplete']", 5);

            IWebElement address = driver.FindElement(By.XPath("//*[@id='autocomplete']"));
            address.SendKeys("50A");
            wait.WaitForElementVisibility(driver, "Id", "Street", 5);

            IWebElement street = driver.FindElement(By.Id("Street"));
            street.SendKeys("ann street");
            wait.WaitForElementVisibility(driver, "Id", "City", 5);

            IWebElement city = driver.FindElement(By.Id("City"));
            address.SendKeys("Brisbane");
            wait.WaitForElementVisibility(driver, "Id", "Postcode", 5);

            IWebElement postcode = driver.FindElement(By.Id("Postcode"));
            postcode.SendKeys("4000");
            wait.WaitForElementVisibility(driver, "Id", "Country", 5);

            IWebElement country = driver.FindElement(By.Id("Country"));
            country.SendKeys("Australia");
            wait.WaitForElement(driver, "Xpath", "//*[@id='submitButton']", 5);

            IWebElement saveContacts = driver.FindElement(By.XPath("//*[@id='submitButton']"));
            saveContacts.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);
             
           /* // check if contact created successfully
            IWebElement contactBox = driver.FindElement(By.XPath("//*[@id='ContactDisplay']"));
            IWebElement billingContactBox = driver.FindElement(By.XPath("//*[@id='BillingContactDisplay']"));
           

            if (contactBox.Text == billingContactBox.Text)
            {
                Assert.Pass("Company contact created succesfully");
                
            }
            else
            {
                Assert.Fail("company contact creattion failed");
            }
            Thread.Sleep(3000);

            // create new group
            wait.WaitForElement(driver, "Xpath", "//*[@id='CreateGroupButton']", 50);

            IWebElement createnewButton = driver.FindElement(By.XPath("//*[@id='CreateGroupButton']"));
            createnewButton.Click();
            wait.WaitForElementVisibility(driver, "Xpath", "//*[@id='groupDetailWindow_wnd_title']/iframe", 5);

            IWebElement iframeAddgroup = driver.FindElement(By.XPath("//*[@id='groupDetailWindow_wnd_title']/iframe"));
            driver.SwitchTo().Frame(iframeAddgroup);
            wait.WaitForElementVisibility(driver, "Xpath", "//*[@id='Name']", 5);

            // input group name
            IWebElement groupName = driver.FindElement(By.XPath("//*[@id='Name']"));
            groupName.SendKeys("Aussie group");
            wait.WaitForElement(driver, "Xpath", "//*[@id='SaveButton']", 5);

            // IWebElement saveGroup = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            IWebElement saveGroup = driver.FindElement(By.XPath("//*[@id='GroupEditForm']/div/div[2]/div/input[1]"));
            saveGroup.Click();
            Thread.Sleep(3000);

            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            //goto groups last page
            IWebElement groupLastPage = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[5]/div/div/div[4]/a[4]"));//*[@id=\"groupGrid\"]/div[4]/a[4]/span")
            groupLastPage.Click();
            Thread.Sleep(2000);

            // validate if the new group has been created successfully
            wait.WaitForElement(driver, "Xpath", "//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]", 5);
            IWebElement lastpageGroupDisplay = driver.FindElement(By.XPath("//*[@id='groupGrid']/div[2]/table/tbody/tr[last()]/td[2]"));
            if (lastpageGroupDisplay.Text == "Aussie group")
            {
                Assert.Pass("group creates Successfully");
                Thread.Sleep(3000);
            }
            else
            {
                Assert.Fail("createnewgroup created test failed");
            }*/

            //save company
            IWebElement saveCompanynew = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            saveCompanynew.Click();
            Thread.Sleep(5000);

            try
            {
                //goto last page
                wait.WaitForElement(driver, "Xpath", "//*[@id=''companiesGrid']/div[4]/a[4]", 400);
                IWebElement saveCompanyEndpage = driver.FindElement(By.XPath("//*[@id=''companiesGrid']/div[4]/a[4]"));
                saveCompanyEndpage.Click();

            }
            catch
            {
                Console.WriteLine("goto last page to last page successfull");
            }
           
            // validating if data stored successfully by checking last page last element
            wait.WaitForElement(driver, "Xpath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
            IWebElement companyLastpageLastelement = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(companyLastpageLastelement.Text, Is.EqualTo("ABC LTD"));


        }
        public void EditCompany(IWebDriver driver)
        {

        }
        public void DeleteCompany(IWebDriver driver)
        {
            //go to last company page
            wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[4]/a[4]", 400);
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]")).Click();

            // select last element to delete
            wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 400);
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]")).Click();

            // click delete button
            wait.WaitForElement(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[9]/td[3]/a[2]", 400);
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[9]/td[3]/a[2]")).Click();
            

            //driver.SwitchTo().Alert().Accept();
            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(1000);

            // Accepting alert		
            alert.Accept();

            // validating deleted data
            try
            {
                IWebElement deleteCompanyText = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(deleteCompanyText.Text != "ABC LTD");
                Console.WriteLine("company details deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("delete method failed");
                Assert.Fail("deleteText failed", ex.Message);

            }
        }
    }
}
