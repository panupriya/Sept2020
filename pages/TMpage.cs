using NUnit.Framework;
using OpenQA.Selenium;
using September2020.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.pages
{
    class TMpage
    {
       public void CreateTM(IWebDriver driver)
        {
            //click typecode dropdown list
            IWebElement time = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            time.Click();
           
            wait.WaitForElement(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 5);

            // select time
            IWebElement typecode = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            typecode.Click();

            wait.WaitForElement(driver, "Id", "Code", 5);

            //input code
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("Sep2020");


            //input discription
            IWebElement discription = driver.FindElement(By.Id("Description"));
            discription.SendKeys("Test_time");

            //price is overriding so call the first input then call price input
            IWebElement price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.Click();

            IWebElement pricePerUnit = driver.FindElement(By.Id("Price"));
            pricePerUnit.SendKeys("5000");
            
            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 5);

            // select file

            // save data
            IWebElement savebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            savebutton.Click();
            
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            try
            {
                //goto last page
                IWebElement lastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
                lastpage.Click();
            }
            catch(Exception ex)
            {
                Console.WriteLine("last page cannot be loaded", ex.Message);
            }

            //last test element selection
            IWebElement expectedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (expectedcode.Text == "Sep2020")
            {
                //using Aseert pass and fail on if condition
                Assert.Pass("Time record created successfully, test passed");
    
            }
            else
            {
                Assert.Fail("Time record created faild, test faild");
                
            }

            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            
        }
        public void EditTM(IWebDriver driver)
        {
            //data to edit button
            IWebElement editcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            editcode.Click();
            
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 20);

            try
            {
                //edit button
                IWebElement editbutton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editbutton.Click();
                wait.WaitForElement(driver, "Id", "Code", 10);
            }
            catch (Exception ex)
            {
                Console.WriteLine("edit function failed", ex.Message);
            }
                
            //update code
            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys("Sep2020 updated");

            //update discription
            IWebElement editDiscription = driver.FindElement(By.Id("Description"));
            editDiscription.Clear();
            editDiscription.SendKeys("Test_time updated");

            //price is overriding so call the first input then call price input
            IWebElement editPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice.Click();



            // update price
            IWebElement editPricePerUnit = driver.FindElement(By.Id("Price"));
            editPricePerUnit.Clear();


            IWebElement editPrice1 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editPrice1.Click();

            IWebElement editPricePerUnit1 = driver.FindElement(By.Id("Price"));
            editPricePerUnit1.SendKeys("10000");

            wait.WaitForElementVisibility(driver, "XPath", "//*[@id='SaveButton']", 5);

            // select file



            // save edited data
            IWebElement editSavebutton = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            editSavebutton.Click();
            
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            //goto last page
            IWebElement editLastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            editLastpage.Click();

            //edited last test element selection
            IWebElement editedcode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //-- another method assertion
            Assert.That(editedcode.Text, Is.EqualTo("Sep2020 updated")); 
           
        }
        public void DeleteTM(IWebDriver driver)
        {

            // data to delete  
            IWebElement deleteDataCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            deleteDataCode.Click();
            
            wait.WaitForElement(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 10);

            //delete data
            IWebElement delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            delete.Click();
            Thread.Sleep(10000);
           

            //driver.SwitchTo().Alert().Accept();

            IAlert alert = driver.SwitchTo().Alert();
            Thread.Sleep(5000);

            // Accepting alert		
            alert.Accept();
        }
    }
}
