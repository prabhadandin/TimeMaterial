using IC_TimeMaterial.Helpers;
using IC_TimeMaterial.Pages;
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

    class Program
    {
        static void Main(string[] args)
        {
            //define driver
            CommonDrivers.driver = new ChromeDriver();

            //Login action
            LoginPage loginObj = new LoginPage();
            loginObj.loginSteps(CommonDrivers.driver);

            //Navigate to TM
            HomePage homeObj = new HomePage();
            homeObj.navigateTM(CommonDrivers.driver);

            //Create TM
            TMPage tmObj = new TMPage();
            tmObj.createTM(CommonDrivers.driver);

        }
    }
}