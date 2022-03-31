using OpenQA.Selenium;
using SeleniumFramework.BasicObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class SearchResultPage
    {
        public SearchResultPage()
        {
            LoginButton = new Button(By.XPath("//a[text() = 'Login']"));
            SearchBox = new TextBox(By.XPath("//input[@title='Search for products, brands and more']"));
            CloseButton = new Button(By.XPath("(//span[text()='Login'])[1]/ancestor::div//button[1]"));
            SearchButton = new Button(By.XPath("//button[@type='submit']"));
        }


        public Button SearchButton { get; set; }
        public Button CloseButton { get; set; }
        public TextBox SearchBox { get; set; }
        public Button LoginButton { get; set; }
    }
}
