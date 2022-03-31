using OpenQA.Selenium;
using SeleniumFramework.BasicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class FiltersPage
    {
        public FiltersPage()
        {
            Mobiles = new LinkText(By.CssSelector("a[title='Mobiles']"));
            Brands = new Brands();
            FlipkartAssured = new CheckBox(By.XPath("(//div[text()='Customer Ratings']//following::section//following::div)[1]"));
            PriceHighToLow = new LinkText(By.XPath("//div[text()='Price -- High to Low']"));
        }
        public LinkText PriceHighToLow { get; set; }
        public CheckBox FlipkartAssured { get; set; }
        public Brands Brands { get; set; }
        public LinkText Mobiles { get; set; }

    }
}
