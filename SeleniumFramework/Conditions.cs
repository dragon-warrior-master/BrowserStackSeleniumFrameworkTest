using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework
{
    public class Conditions
    {
        public static Func<IWebDriver, IWebElement> ElementExists(By locator)
        {
            return (driver) =>
            {
                try
                {
                    return driver.FindElement(locator);
                }
                catch (Exception)
                {

                    return null;
                }

            };
        }

        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var elements = driver.FindElements(locator);
                    return elements.Any() ? elements : null;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }


        public static Func<IWebDriver, IWebElement> ElementToBeClickable(By locator)
        {
            return (driver) =>
            {
                try
                {
                    var webElement = ElementIfVisible(driver.FindElement(locator));
                    if (webElement != null && webElement.Enabled)
                        return webElement;
                    else
                        return null;
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }


        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    return ElementIfVisible(driver.FindElement(locator));
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }
        private static IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }

    }
}
