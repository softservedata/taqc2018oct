using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondA1
{
    public abstract class TestRunner
    {
        protected static Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        protected const string FOLDER_BIN = "bin";
        protected const string ALLURE_CONFIG = "allureConfig.json";
        //
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            PrepareAllureConfig();
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
            log.Info("AfterAllMethods() done");
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("HOME_URL"));
        }

        //[TearDown]
        public void TearDown()
        {
            //driver.Navigate().GoToUrl(Environment.GetEnvironmentVariable("HOME_URL"));
        }

        private void PrepareAllureConfig()
        {
            string runtimePath = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = runtimePath.Remove(runtimePath.IndexOf(FOLDER_BIN)) + ALLURE_CONFIG;
            log.Info("runtimePath: " + runtimePath);
            log.Info("sourcePath: " + sourcePath);
            //
            if (File.Exists(sourcePath))
            {
                if (File.Exists(runtimePath + ALLURE_CONFIG))
                {
                    File.Delete(runtimePath + ALLURE_CONFIG);
                }
                File.Copy(sourcePath, runtimePath + ALLURE_CONFIG);
            }
            else
            {
                log.Warn("File " + sourcePath + " NOT FOUND.");
            }
        }
    }
}
