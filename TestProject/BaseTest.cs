using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework;
using PageObjects;
[assembly: LevelOfParallelism(4)]
namespace TestProject
{
    
    public class BaseTest
    {
        internal Flipkart Flipkart;

        [SetUp]
        public void SetUpTest()
        {
            Browser.CreateDriver();
            Browser.Navigate(GlobalVariables.URL);
            Flipkart = new Flipkart();
        }

        [TearDown]
        public void EndTest()
        {
            Browser.GetDriver().Quit();
        }
             


    }
}
