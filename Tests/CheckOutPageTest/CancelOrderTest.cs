using SauseLabPomProject.Drivers;
using SauseLabPomProject.Pages;
using SauseLabPomProject.Pages.PaymentPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Tests.PaymentPageTest
{
     public  class CancelOrderTest:BaseClassTest
    {

        [Test]
        public void cancelOrderTest()
        { 
            
                Login("StandardUser");
                var _cancelOrder = GetPage<CancelOrder>();
                _cancelOrder.CompleteOrderCancellation("Sumanta", "Swain", "500081");
                var pageTitle = _cancelOrder.GetProductPageTitle();
                Assert.That(pageTitle, Is.EqualTo("Products"), "The page title should be 'Products' after cancelling the order.");

            

        } 

    } 
}
