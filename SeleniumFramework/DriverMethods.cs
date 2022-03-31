using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public static class DriverMethods
    {


        public static IWebElement GetElementWhenClickable(this IWebDriver driver, By by, int timeOut = GlobalVariables.TimeOut.Twenty)
        {
            try
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                //-> To avaid exceptions related to page refreshed
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                IWebElement webElement = wait.Until(Conditions.ElementToBeClickable(by));

                return webElement;
            }
            catch (Exception)
            {
                //log message element not found to be clickable
                throw;
            }
        }
        public static IWebElement GetElementWhenVisible(this IWebDriver driver, By by, int timeOut = 0)
        {
            try
            {

                int totalTime = (timeOut == 0) ? GlobalVariables.TimeOut.Twenty : timeOut;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalTime));

                IWebElement result = wait.Until(Conditions.ElementIsVisible(by));

                return result;
            }
            catch (Exception)
            {
                throw;
            }


        }


        public static IWebElement FindElement(this IWebDriver driver, By by, int timeOut = 0)
        {
            try
            {

                int totalTime = (timeOut == 0) ? GlobalVariables.TimeOut.Twenty : timeOut;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalTime));
                //-> To avaid exceptions related to page refreshed
                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                IWebElement result = wait.Until(Conditions.ElementExists(by));


                return result;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        /// <summary>
        /// Fetches all the elements found matching the locator
        /// </summary>
        /// <param name="driver">.</param>
        /// <param name="by">Criteria by which the elements will be located.</param>
        /// <param name="timeOut">Maximum amount of time to wait for locate the elements.</param>
        /// <returns>Return the elements if they are located, an exception if they are not.</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeOut = 0)
        {
            try
            {
                int totalTime = (timeOut == 0) ? GlobalVariables.TimeOut.Twenty : timeOut;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(totalTime));

                wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                var result = wait.Until(Conditions.PresenceOfAllElementsLocatedBy(by));


                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
