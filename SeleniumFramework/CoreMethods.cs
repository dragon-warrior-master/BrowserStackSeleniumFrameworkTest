using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public class CoreMethods
    {

        public static void Click(By by, int timeOut = 20)
        {
            try
            {
                var webElement = Browser.GetDriver().GetElementWhenClickable(by, timeOut);
                MoveToWebElement(by, timeOut);
                Actions actions = new Actions(Browser.GetDriver());
                actions.Click(webElement).Perform();
            }
            catch (StaleElementReferenceException)
            {
                //In Case of StaleElementException retry Click
                var webElement = Browser.GetDriver().GetElementWhenClickable(by, timeOut);
                Actions actions = new Actions(Browser.GetDriver());
                actions.Click(webElement).Perform();
            }
            catch (Exception)
            {

                //LogException or use it to reClick on the element
            }

        }

        public static void MoveToWebElement(By by, int timeOut = 20, bool forceOutOfView = false)
        {
            if (ElementExists(by, timeOut))
            {
                if (forceOutOfView || IsOutOfViewPort(by))
                {
                    IJavaScriptExecutor je = (IJavaScriptExecutor)Browser.GetDriver();
                    je.ExecuteScript("arguments[0].scrollIntoView(false)", Browser.GetDriver().FindElement(by));
                }
            }
            else
            {
                throw new Exception("Page can not scroll to the Element as element does not exist");
            }
        }

        public static bool ElementExists(By by, int timeOut = 20)
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(by, timeOut);
                return webElement != null;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool ElementIsDisplayed(By by, int timeout = 20)
        {
            try
            {
                var element = Browser.GetDriver().GetElementWhenVisible(by, timeout);
                return element != null;
            }
            catch (WebDriverException)
            {
                return false;
            }

        }
        public static void SetText(By by, string text, int timeOut = 20)
        {
            try
            {
                var webElement = Browser.GetDriver().FindElement(by, timeOut);
                webElement.Clear();
                webElement.SendKeys(text);
            }
            catch (Exception)
            {

                throw new Exception("Not been able to set text");
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public static bool IsOutOfViewPort(By by)
        {
            try
            {
                IJavaScriptExecutor je = (IJavaScriptExecutor)Browser.GetDriver();
                string result = je.ExecuteScript("var bounding = arguments[0].getBoundingClientRect();" +
                    "var out = bounding.top < 0 || bounding.left < 0 || bounding.bottom > (window.innerHeight || document.documentElement.clientHeight) || bounding.right > (window.innerWidth || document.documentElement.clientWidth);" +
                    "return out;", Browser.GetDriver().FindElement(by)).ToString();
                if (bool.TryParse(result, out bool isOutOfViewPort))
                {
                    return isOutOfViewPort;
                }
                else
                    throw new Exception("The result of the javascript was not a boolean type");
            }
            catch (Exception)
            {
                //Log any exception occured

            }
            return false;
        }

       
    }
}
