using OpenQA.Selenium;
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
            //input company name
            IWebElement name = driver.FindElement(By.XPath("//*[@id='Name']"));
            name.SendKeys("ABC LTD");
            Thread.Sleep(1000);

            //input contact details
            
        }
        public void EditCompany(IWebDriver driver)
        {

        }
        public void DeleteCompany(IWebDriver driver)
        {

        }
    }
}
