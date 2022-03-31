using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace SeleniumFramework
{
    public class Browser
    {

        [ThreadStatic]
        private static IWebDriver internalDriver;
        static ConcurrentDictionary<Thread, IWebDriver> drivers = new ConcurrentDictionary<Thread, IWebDriver>();



        public static IWebDriver CreateDriver()
        {
            IWebDriver driver;
            CopyDriver();

            var webDriverPath = AppDomain.CurrentDomain.BaseDirectory;
            string browserName = GlobalVariables.BrowserName.ToUpper();

            switch (browserName)
            {
                case "CHROME":
                    ChromeOptions preference = new ChromeOptions();

                    preference.AddArguments("--start-maximized");

                    internalDriver = new ChromeDriver(webDriverPath, preference);
                    break;

                default:
                    driver = new FirefoxDriver(webDriverPath);
                    driver.Manage().Window.Maximize();
                    break;
            }
            if (!drivers.TryAdd(Thread.CurrentThread, internalDriver))
            {
               
            }
            return internalDriver;


        }


        public static IWebDriver GetDriver()
        {
            IWebDriver selectedDriver;
            if (drivers.TryGetValue(Thread.CurrentThread, out selectedDriver))
            {
                return selectedDriver;
            }
            else
            {
                throw new InvalidOperationException($"The thread '{Thread.CurrentThread}' does not exist in the dictionary");
            }
        }

        private static string WebDriverLocation
        {
            get
            {
                IDriverConfig driverConfig = null;
                string browserName = GlobalVariables.BrowserName;// ConfigurationManager.AppSettings["BrowserName"].ToUpper();

                switch (browserName)
                {
                    case "CHROME":
                        driverConfig = new ChromeConfig();
                        break;
                    case "Edge":
                        driverConfig = new EdgeConfig();
                        break;
                    case "InternetExplorer":
                        break;
                    case "Firefox":
                        driverConfig = new FirefoxConfig();
                        break;
                    default:
                        driverConfig = new ChromeConfig();
                        break;
                }

                // Download the latest version
                new DriverManager().SetUpDriver(driverConfig, VersionResolveStrategy.MatchingBrowser);

                // Obtain the location
                string webDriverPath = FileHelper.GetBinDestination(
                driverConfig.GetName(),
                driverConfig.GetMatchingBrowserVersion(),
                ArchitectureHelper.GetArchitecture(),
                driverConfig.GetBinaryName());

                return webDriverPath;
            }
        }

        public static void CopyDriver()
        {
            string browserName = GlobalVariables.BrowserName;// ConfigurationManager.AppSettings["BrowserName"].ToUpper();
            string location = WebDriverLocation;
            string targetLocation;
            switch (browserName)
            {
                case "CHROME":
                    targetLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                    break;
                case "Edge":
                    targetLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                    break;
                case "InternetExplorer":
                    targetLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                    break;
                case "Firefox":
                    targetLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                    break;
                default:
                    targetLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chromedriver.exe");
                    break;
            }

            File.Copy(location, targetLocation, true);
            if (!File.Exists(targetLocation))
            {
                throw new Exception("The chromedriver was not found in the bin/debug folder");
            }
        }

        public static void Quit()
        {
            GetDriver().Quit();


        }

        public static void Navigate(string url)
        {
            GetDriver().Navigate().GoToUrl(url);
        }
    }
}
