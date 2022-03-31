using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.BasicObjects
{
    public class TextBox
    {
        public TextBox(By locator)
        {
            Locator = locator;
        }
        public By Locator { get; set; }

        public virtual void SetText(string text)
        {
            CoreMethods.SetText(Locator, text, 5);
        }

    }
}
