
using SauseLabPomProject.Pages;
using SauseLabPomProject.Pages.ProductPage;

namespace SauseLabPomProject.Tests.ProductPageTest
{ 
    
    public  class ProductIsAvailableTest:BaseClassTest
    {
/// <summary>
/// Verifies that a product is available on the page after successful login.
/// </summary>

        [Test]
        public void productIsAvailableTest()
        {
            
                Login("StandardUser");
                var _productAvl = GetPage<ProductIsAvailable>();
                bool isAvailable = _productAvl.checkProductAvl();
                Assert.IsTrue(isAvailable, "The Product would be available on the page!");
               
        }

        [Test]
        public void productIsNotAvailableTest()
        {
           
                Login("StandardUser");
                var _productNotAvl = GetPage<ProductIsAvailable>();
                bool isNotAvailable = _productNotAvl.checkProductNotAvl();
                Assert.IsTrue(isNotAvailable, "The Product would not be available on the page!");
               

        }







    } 
}
