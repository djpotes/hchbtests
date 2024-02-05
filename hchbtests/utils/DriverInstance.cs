using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace hchbtests.utils
{
	public class DriverInstance
	{
        public static WebDriver driver = null;

        /**
         * Initialize the driver
         */
        public static void init()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "/resources/chromedriver");
            System.Environment.SetEnvironmentVariable("webdriver.chrome.logfile", "chromedriver.log");
            System.Environment.SetEnvironmentVariable("webdriver.chrome.verboseLogging", "true");
            ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://www.google.com/";
        }

        public static void quit()
        {
            driver.Quit();
        }
    }
}

