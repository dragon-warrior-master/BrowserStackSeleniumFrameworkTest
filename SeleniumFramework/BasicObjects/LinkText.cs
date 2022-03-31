using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.BasicObjects
{
    public class LinkText
    {
        public LinkText(By locator)
        {
            Locator = locator;
        }
        public By Locator { get; set; }

        public virtual void Click()
        {
            CoreMethods.MoveToWebElement(Locator);
            CoreMethods.Click(Locator);
        }

        public virtual string GetAttribute(By by, string attribute, int timeOut = 20)
        {
            string htmlAttribute = Browser.GetDriver().FindElement(by, timeOut).GetAttribute(attribute);
            return htmlAttribute;
        }

    }
}
