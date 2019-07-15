using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace IC_TimeMaterial.Pages
{
    class TMPage

    {
        public void CrtTM(IWebDriver driver)
        {
            

            //Click on create new button
            driver.FindElement(By.LinkText("Create New")).Click();
           
            //Click type code drop box

            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

            //Enter code value
            driver.FindElement(By.Id("Code")).SendKeys("CS0100");
            //Validate  CodeValue
            string CodeInput = driver.FindElement(By.Id("Code")).GetAttribute("value");
            if (CodeInput == null && CodeInput.Length > 20)
            {
                Console.WriteLine("The Code field is required");
            }
            if (CodeInput.Length > 20)
            {
                Console.WriteLine("The Code field should not be more than 20 character");
            }
            //Enter description Value
            driver.FindElement(By.Id("Description")).SendKeys("ComputerScience");

            //Enter Price per unit
            IWebElement Price = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Scroll to Price unit to make visible to 
            Actions action = new Actions(driver);
            action.MoveToElement(Price).Perform();
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("232");

            //Select FIle
            
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
            driver.FindElement(By.XPath("//*[@id='files']")).SendKeys("G:/Test.txt");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //checked file Successful Upload
            //IWebElement fileuploadsucess = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));


            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            //Validate description value 
            string DesInput = driver.FindElement(By.Id("Description")).GetAttribute("value");
            if (DesInput == null)
            {
                Console.WriteLine("The Description field is required.");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Navigate to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[3]")).Click();

            //Verify record Existing or not
            //Get the xpath for container table
            IWebElement table = driver.FindElement(By.XPath("//div[@id='tmsGrid']//table[1]"));
            //To locate rows of table
            IList<IWebElement> tablerows = new List<IWebElement>(driver.FindElements(By.TagName("tr")));
           // String strRowData = " ";
            foreach(var rowindex in tablerows)
            {
                //To locate columns of table
                IList<IWebElement> tablecell = table.FindElements(By.TagName("td"));
                if(tablecell.Count>0)
                {
                   if(tablecell.Equals("CS0100"))
                    {
                        Console.WriteLine("Records saved successfully!,test passed");
                    }
                }

            }
         }

        internal void ValidateTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            try
            {
                while (true)
                {
                    for (var i = 1; i <= 10; i++)
                    {
                        var textCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
                        Console.WriteLine(textCode);
                        if (textCode == "hai456")
                        {
                            Console.WriteLine("Test passed");
                            return;
                        }

                    }
                    driver.FindElement(By.XPath("//a[@title='Go to the next page']")).Click();
                }
            }
            catch (Exception) {
                Console.WriteLine("Test Failed");
            }

        }

        public void EdtTM(IWebDriver driver)
        {
            //Explicit wait for driver
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Click on EDit button
            driver.FindElement(By.LinkText("Edit")).Click();
            //Edit Type code and Validate
            driver.FindElement(By.XPath("//span[@class='k-widget k-dropdown k-header text-box single-line']"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Edit Code value and Validate
             driver.FindElement(By.Id("Code")).SendKeys("124343edit");
             String CodeValueEdit = driver.FindElement(By.Id("Code")).GetAttribute("Value");
             if (CodeValueEdit == null)
             {
                 Console.WriteLine("The Code field is required");
             }
             if (CodeValueEdit.Length > 20)
             {
                 Console.WriteLine("The Code field should not be more than 20 character");
             }
            //Edit description
            driver.FindElement(By.Id("Description")).SendKeys("ComputerScience001edit");
            //Enter Price per unit
            IWebElement Priceedit = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            //Scroll to Price unit to make visible to 
            Actions actionedit = new Actions(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            actionedit.MoveToElement(Priceedit).Perform();

            //Select FIle
            //driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
            //driver.FindElement(By.XPath("//*[@id='files']")).SendKeys("G:/Test-Copy.txt");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            //checked file Successful Upload
            //IWebElement fileuploadsucess = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));

            //Select Download button
            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
            // driver.FindElement(By.Id("downloadButton")).Click();
            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string DesInputEdit = driver.FindElement(By.Id("Description")).GetAttribute("value");
            if (DesInputEdit == null)
            {
               Console.WriteLine("The Description field is required.");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //Navigate to last page
            try
            {
               // driver.FindElement(By.LinkText("Back to List")).Click();
            }
            catch(NoSuchElementException e)
            {
                Console.WriteLine("" + e);
            }
            //verify the updated records
            /*  if (driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr/td[1]")).Text == "CS0100edit")

              {
                  Console.WriteLine("Record Updated successfully, test passed");
              }
              else
              {
                  Console.WriteLine("Records not updated,Test failed!");
              }*/



        }

        public void delTM(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Click Delete Button
            driver.FindElement(By.LinkText("Delete")).Click();
 
            /*string CodeInputdelete = driver.FindElement(By.Id("Code")).GetAttribute("value");
            string DescInputdelete = driver.FindElement(By.Id("Description")).GetAttribute("value");*/
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Switch the control of 'driver' to the Alert from main Window
                driver.SwitchTo().Alert().Accept();
            }
            
           catch(NoAlertPresentException e)
            {
                Console.WriteLine("delete fails"+e);
            }
        }
           
        }
    }

