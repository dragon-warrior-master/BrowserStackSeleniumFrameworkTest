using OpenQA.Selenium;
using SeleniumFramework.BasicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class Brands
    {
        public Brands()
        {
            Samsung = new CheckBox(By.XPath("(//div[@title='SAMSUNG']//following-sibling::div)[1]"));
        }
        public CheckBox Samsung { get; set; }

    }
}
