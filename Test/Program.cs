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
    class Program
    {
        static void Main(string[] args)
        {
            
      
        }
        [SetUp]
        public void Login()
        {
            //define driver
            CommonDriver.driver = new ChromeDriver();

            //Login action
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps(CommonDriver.driver);

            //Navigate to TM
            HomePage homeObj = new HomePage();
            homeObj.navigateTM(CommonDriver.driver);

        }
        [Test]
        public void CreateTM()
        {
            TMPage tmObj = new TMPage();
            tmObj.CrtTM(CommonDriver.driver);

        }
        [Test]
        public void EditTM()
        {
            TMPage tmObj = new TMPage();
            tmObj.EdtTM(CommonDriver.driver);

        }
        [Test]
        public void DeleteTM()
        {
            
            TMPage tmObj = new TMPage();
            tmObj.delTM(CommonDriver.driver);
        }
        [TearDown]
        public void Finish()
        {
            CommonDriver.driver.Quit();
        }
    }
}