using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages;
using SauseLabPomProject.Pages.PaymentPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SauseLabPomProject.Tests.PaymentPageTest
{ 
    public class OrderPlacedTest : BaseClassTest
    {
        [Test]
        public void orderPlacedTest()
        {
            
            
             
                Login("StandardUser");
                var _orderPlaced = GetPage<OrderPlaced>();
                _orderPlaced.AddProductsToCart();
                _orderPlaced.NavigateToCart();
                _orderPlaced.PlaceOrder();
                var verifyElement = _orderPlaced.GetProductPageTitle();
                Assert.That(verifyElement, Is.EqualTo("Thank you for your order!"));

            
        }
    } 
}
