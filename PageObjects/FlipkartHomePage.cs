using OpenQA.Selenium;
using SeleniumFramework;
using SeleniumFramework.BasicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class FlipkartHomePage
    {
        public FlipkartHomePage()
        {
            LoginButton = new Button(By.XPath("//a[text() = 'Login']"));
            SearchBox = new TextBox(By.XPath("//input[@title='Search for products, brands and more']"));
            CloseButton = new Button(By.XPath("(//span[text()='Login'])[1]/ancestor::div//button[1]"));
            SearchButton = new Button(By.XPath("//button[@type='submit']"));

            Filters = new FiltersPage();
        }
        public List<string> GetProductLinks()
        {
            List<string> productLinks = new List<string>();
            By byProductLinks = By.XPath("//div[contains(@data-tkid,'SEARCH')]/a");

            var links = Browser.GetDriver().FindElements(byProductLinks);

            links.ToList().ForEach(link => productLinks.Add(link.GetAttribute("href")));

            return productLinks;
        }

        public List<string> GetProductName()
        {
            List<string> productNames = new List<string>();
            By byProductName = By.XPath("(//span[contains(@id,'productRating')]/parent::div)/parent::div/div[1]");

            var productNamesElements = Browser.GetDriver().FindElements(byProductName);

            productNamesElements.ToList().ForEach(link => productNames.Add(link.Text));

            return productNames;
        }



        public List<string> GetProductPrice()
        {
            List<string> productPrices = new List<string>();
            By byProductPrices = By.XPath("(((((//span[contains(@id,'productRating')]/parent::div)/parent::div)/following-sibling::div)/child::div[1])/div)/child::div[1]");

            var productPricesElements = Browser.GetDriver().FindElements(byProductPrices);

            productPricesElements.ToList().ForEach(link => productPrices.Add(link.Text));

            return productPrices;
        }






        public FiltersPage Filters { get; set; }
        public Button SearchButton { get; set; }
        public Button CloseButton { get; set; }
        public TextBox SearchBox { get; set; }
        public Button LoginButton { get; set; }
    }
}
