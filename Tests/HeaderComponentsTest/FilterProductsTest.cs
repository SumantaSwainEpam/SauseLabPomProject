using OpenQA.Selenium;
using SauseLabPomProject.Pages.HeaderComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Tests.HeaderComponentsTest
{
    [TestFixture]
     public class FilterProductsTest:BaseClassTest
    {

        
        [Test]
        public void FilterOnProductsTest()
        {
            Login("StandardUser");
            var filter = GetPage<FilterProducts>();
            filter.ApplyFilter();
            var product1Name = filter.GetProduct1().Text;
            var product2Name = filter.GetProduct2().Text;
            Assert.That(product1Name, Is.EqualTo("Test.allTheThings() T-Shirt (Red)"));
            Assert.That(product2Name, Is.EqualTo("Sauce Labs Onesie"));


        }
    }
}
