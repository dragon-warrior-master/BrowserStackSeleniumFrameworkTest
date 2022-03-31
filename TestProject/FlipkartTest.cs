using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;

namespace TestProject
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class FlipkartTest : BaseTest
    {
        [Test]
        public void Test1()
        {


            Flipkart.HomePage.CloseButton.Click();
            Flipkart.HomePage.SearchBox.SetText("Samsung Galaxy S10");
            Flipkart.HomePage.SearchButton.Click();

            Flipkart.HomePage.Filters.Mobiles.Click();
            Flipkart.HomePage.Filters.Brands.Samsung.Click();

            Flipkart.HomePage.Filters.FlipkartAssured.Click();
            Flipkart.HomePage.Filters.PriceHighToLow.Click();
            List<string> names = Flipkart.HomePage.GetProductName();
            List<string> links = Flipkart.HomePage.GetProductLinks();
            List<string> prices = Flipkart.HomePage.GetProductPrice();

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Name : {names[i]} - Link : {links[i]} - Price : {prices[i]}");
            }


        }

        [Test]
        public void Test2()
        {


            Flipkart.HomePage.CloseButton.Click();
            Flipkart.HomePage.SearchBox.SetText("Samsung Galaxy S10");
            Flipkart.HomePage.SearchButton.Click();

            Flipkart.HomePage.Filters.Mobiles.Click();
            Flipkart.HomePage.Filters.Brands.Samsung.Click();

            Flipkart.HomePage.Filters.FlipkartAssured.Click();
            Flipkart.HomePage.Filters.PriceHighToLow.Click();
            List<string> names = Flipkart.HomePage.GetProductName();
            List<string> links = Flipkart.HomePage.GetProductLinks();
            List<string> prices = Flipkart.HomePage.GetProductPrice();

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Name : {names[i]} - Link : {links[i]} - Price : {prices[i]}");
            }


        }

        [Test]
        public void Test3()
        {


            Flipkart.HomePage.CloseButton.Click();
            Flipkart.HomePage.SearchBox.SetText("Samsung Galaxy S10");
            Flipkart.HomePage.SearchButton.Click();

            Flipkart.HomePage.Filters.Mobiles.Click();
            Flipkart.HomePage.Filters.Brands.Samsung.Click();

            Flipkart.HomePage.Filters.FlipkartAssured.Click();
            Flipkart.HomePage.Filters.PriceHighToLow.Click();
            List<string> names = Flipkart.HomePage.GetProductName();
            List<string> links = Flipkart.HomePage.GetProductLinks();
            List<string> prices = Flipkart.HomePage.GetProductPrice();

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Name : {names[i]} - Link : {links[i]} - Price : {prices[i]}");
            }


        }

    }
}