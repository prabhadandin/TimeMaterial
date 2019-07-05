using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IC_TimeMaterial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lauch chrome driver
            IWebDriver driver = new ChromeDriver();
            //Maximize the browser
            driver.Manage().Window.Maximize();
            //Launch Login Page
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Enter user name using ID
            driver.FindElement(By.Id("UserName")).SendKeys("hari");
            ////Enter password using ID
            driver.FindElement(By.Id("Password")).SendKeys("123123");
            //Click login using xpath
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();

            //Validate Login button
            IWebElement Hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (Hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in Successfully,Test pass!");

            }
            else
            {
                Console.WriteLine("Logged in Failes,Test failed!");
            }


            //TIme and Material Test Automation

            //Click on administration category
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();


            //Click on time and material Option
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();

            //Click on create new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Click type code drop box
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

                //Enter code value
                driver.FindElement(By.Id("Code")).SendKeys("CS0100");
                //Validate  CodeValue
                 /*string CodeInput = driver.FindElement(By.Id("Code")).GetAttribute("value");
                   if (CodeInput == null && CodeInput.Length >20)
                   {
                     Console.WriteLine("The Code field should not be more than 20 character");
                    }*/
                //Enter description Value
                  driver.FindElement(By.Id("Description")).SendKeys("ComputerScience");
                //Validate description value 
                  /*string DesInput = driver.FindElement(By.Id("Description")).GetAttribute("value");
                  if (DesInput == null )
                     {
                       Console.WriteLine("The Description field is required.");
                     }*/
            //Enter Price per unit
            
             driver.FindElement(By.Id("Price"));
            driver.FindElement(By.Id("Price")).SendKeys(""+12343);
            //Select FIle
            driver.FindElement(By.Id("files")).Click();
            driver.FindElement(By.Id("files")).SendKeys("");


            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(1000);

            //Navigate to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[3]")).Click();

            //Verify record Existing or not

            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[9]/td[1]")).Text == "CS0101")


            {
                Console.WriteLine("Record created successfully, test passed");
            }
            else
            {
                Console.WriteLine("Record not created ,test failed!");
            }
            

            //Click on EDit button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));

            //Click the Type code 
  
            //driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();
            //driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]")).Click();
            driver.FindElement(By.Id("TycodeCode")).Click();


            //Edit Type code and Validae it
            driver.FindElement(By.Id("Code")).SendKeys("CS0100edit");
           /* string CodeInputEdit = driver.FindElement(By.Id("Code")).GetAttribute("value");
            if (CodeInputEdit == null && CodeInputEdit.Length > 20)
            {
                Console.WriteLine("The Code field should not be more than 20 character");
            }*/
            //Edit description
            driver.FindElement(By.Id("Description")).SendKeys("ComputerScience001edit");
            /*string DesInputEdit = driver.FindElement(By.Id("Description")).GetAttribute("value");
            if (DesInputEdit == null)
            {
                Console.WriteLine("The Description field is required.");
            }*/
            //Edit Price per unit
            driver.FindElement(By.Id("Price")).SendKeys("" + 12435);
            // Edit Select FIle
            driver.FindElement(By.Id("files")).Click();
            driver.FindElement(By.Id("files")).SendKeys("");

            //Select Download button
            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
             driver.FindElement(By.Id("downloadButton")).Click();
            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(1000);

            //navigate to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[2]")).Click();

            //verify the updated records
            if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[1]")).Text == "CS0100edit")

            {
                Console.WriteLine("Record Updated successfully, test passed");
            }
            else
            {
                Console.WriteLine("Records not updated,Test failed!");
            }

           
            //Click Delete Button
            driver.FindElement(By.XPath("//*[[@id='tmsGrid']/div[3]/table/tbody/tr[6]/td[5]/a[2]")).Click();

            string CodeInputdelete = driver.FindElement(By.Id("Code")).GetAttribute("value");
            string DescInputdelete = driver.FindElement(By.Id("Description")).GetAttribute("value");

            // Switch the control of 'driver' to the Alert from main Window

            IAlert confirmationAlert = driver.SwitchTo().Alert();

            String alertText = confirmationAlert.Text;
            if (alertText == "Ok")
            {
                Console.WriteLine("Alert text is " + confirmationAlert);


                confirmationAlert.Accept();

            }
            else
            {
                confirmationAlert.Dismiss();
            }





        }
    }
}
