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
        public void createTM(IWebDriver driver)
        {

            //Click on create new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Click type code drop box
            
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

            //Enter code value
            driver.FindElement(By.Id("Code")).SendKeys("CS0100");
            //Validate  CodeValue
            string CodeInput = driver.FindElement(By.Id("Code")).GetAttribute("value");
              if (CodeInput == null && CodeInput.Length >20)
              {
                Console.WriteLine("The Code field is required");
            }
              if(CodeInput.Length>20)
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
            //WebDriverWait wait = new WebDriverWait(driver, 20);
            IWebElement uploadfile = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/div/div"));
           // uploadfile.Click();

            driver.FindElement(By.XPath("//*[@id='files']")).SendKeys("G:/Test.txt");
           //uploadfile.Click();
            //uploadfile.SendKeys("{Enter}");
            Thread.Sleep(2000);
            //checked file Successful Upload
            //IWebElement fileuploadsucess = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[6]/div/div/ul/li/span[3]"));
           

            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            //Validate description value 
            string DesInput = driver.FindElement(By.Id("Description")).GetAttribute("value");
            if (DesInput == null )
               {
                 Console.WriteLine("The Description field is required.");
               }
            Thread.Sleep(1000);

            //Navigate to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[3]")).Click();

            //Verify record Existing or not
            // driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[9]/td[1]"));//*[@id="tmsGrid"]/div[2]/div/table/thead/tr/th[1]
            IWebElement table = driver.FindElement(By.XPath("html/body/table/tbody"));
            //To locate rows of table
            IList<IWebElement> tablerows = table.FindElements(By.TagName("tr"));
            //To locate columns of table
            //IList<IWebElement> tablecols = table.FindElements(By.TagName("td"));
            //Console.WriteLine("Total rows." + tablecols.Count);


            Console.WriteLine("Total column." + tablerows.Count);
            int rowcount = tablerows.Count();
            //int colcount = tablecols.Count();

            for (int rowindex = 0;  rowindex <rowcount; rowindex++)
            {
                IList<IWebElement> cols_row = tablerows;
               
            }

            //Click on EDit button
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));

            //Click the Type code 
            
           // driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();
            //driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]")).Click();



            //Edit Type code and Validae it
            driver.FindElement(By.Id("Code")).SendKeys("CS0100edit");
            string CodeInputedit = driver.FindElement(By.Id("Code")).GetAttribute("value");
            if (CodeInputedit == null && CodeInput.Length > 20)
            {
                Console.WriteLine("The Code field is required");
            }
            if (CodeInputedit.Length > 20)
            {
                Console.WriteLine("The Code field should not be more than 20 character");
            }
            //Edit description
            driver.FindElement(By.Id("Description")).SendKeys("ComputerScience001edit");
            //Edit Price per unit
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("12435");
            // Edit Select FIle
            driver.FindElement(By.Id("files")).Click();
            driver.FindElement(By.Id("files")).SendKeys("");

            //Select Download button
            //driver.FindElement(By.Id("downloadButton")).GetAttribute("Value");
            driver.FindElement(By.Id("downloadButton")).Click();
            //click save
            driver.FindElement(By.Id("SaveButton")).Click();
            string DesInputEdit = driver.FindElement(By.Id("Description")).GetAttribute("value");
            if (DesInputEdit == null)
            {
                Console.WriteLine("The Description field is required.");
            }

            if (DesInput == null)
            {
                Console.WriteLine("The Description field is required.");
            }

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
