using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.BasicObjects
{
    public class CheckBox
    {
        public CheckBox(By locator)
        {
            Locator = locator;
        }
        public By Locator { get; set; }

        public virtual void Click()
        {
            CoreMethods.MoveToWebElement(Locator);
            CoreMethods.Click(Locator);
        }

      

    }
}
