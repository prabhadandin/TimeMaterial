using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TimeMaterial.Pages
{
    class LoginPage
    {
        public void loginSteps(IWebDriver driver)
        {
            //Maximize the browser
            driver.Manage().Window.Maximize();

            //Navigate to login page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");

            //Enter user name using ID
            IWebElement Username = driver.FindElement(By.Id("UserName"));
            Username.SendKeys("hari");

            ////Enter password using ID
            driver.FindElement(By.Id("Password")).SendKeys("123123");
            //Click login using xpath
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();
            String LoggedUrl = driver.Url;
            if (LoggedUrl == "http://horse-dev.azurewebsites.net/")
            {
                Console.WriteLine("Logged in Succesful!,testc Passed");

            }
            else
            {
                Console.WriteLine("Logged in Failed!,testc Passed");
            }

        }

        internal void loginSteps(object driver)
        {
            throw new NotImplementedException();
        }
    }
}