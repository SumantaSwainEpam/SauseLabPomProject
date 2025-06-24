using SauseLabPomProject.Credentials;
using SauseLabPomProject.Pages;
using SauseLabPomProject.Pages.PaymentPage;
using SauseLabPomProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SauseLabPomProject.Drivers;

namespace SauseLabPomProject.Tests.PaymentPageTest
{ 
    public class CheckOutProductTest : BaseClassTest
    {

        [Test]
        public void CheckOutProductsTest()
        {
          
                Login("StandardUser");
                var _checkOutProduct = GetPage<CheckOutProduct>();
                _checkOutProduct.AddToCheckOut();
                var element = _checkOutProduct.GetCheckoutVerifyElement();
                Assert.That(element.Text, Is.EqualTo("Checkout: Your Information"));

         
      
        }  
    } 
}
