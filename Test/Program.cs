using IC_TimeMaterial.Helpers;
using IC_TimeMaterial.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading;

namespace IC_TimeMaterial
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    class Program
    {
        IWebDriver driver;
        static void Main(string[] args)
        {              
        }
        
        [SetUp]
        public void Login()
        {
            //define driver
            driver = new ChromeDriver();

            //Login action
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps(driver);

            //Navigate to TM
            HomePage homeObj = new HomePage();
            homeObj.navigateTM(driver);

        }
        [Test]
        public void CreateTM()
        {
            TMPage tmObj = new TMPage();
            //tmObj.CrtTM(driver);
            tmObj.ValidateTM(driver);
        }
        [Test]
        public void EditTM()
        {
            TMPage tmObj = new TMPage();
            tmObj.EdtTM(driver);

        }
        [Test]
        public void DeleteTM()
        {
            
            TMPage tmObj = new TMPage();
            tmObj.delTM(driver);
        }
        [TearDown]
        public void Finish()
        {
            driver.Quit();
        }
    }
}