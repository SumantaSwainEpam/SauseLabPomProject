
using SauseLabPomProject.Pages;
using SauseLabPomProject.Pages.ProductPage;

namespace SauseLabPomProject.Tests.ProductPageTest
{
 
    public class AddProductToCartTest : BaseClassTest
    {
       

        [Test]
        public void AddProductsToCartTest()
        {
           
                 Login("StandardUser");             
                 var _addProductToCart = GetPage<AddProductToCart>();
                _addProductToCart.AddTheProduct();
                Assert.That(_addProductToCart.GetCartCount(), Is.EqualTo("2"), "Cart count did not match expected value.");

        }


        [Test]
        public void RemoveFromCartTest()
        {

                Login("StandardUser");
               
                var _addProductToCart= GetPage<AddProductToCart>(); 
                // Add to Cart
                _addProductToCart.AddTheProduct();

                //Navigate to Cart
                _addProductToCart.NavigateToCart();

                //Count the product that add to cart
            
                var countAfterAdd = _addProductToCart.GetCartCount();
                Assert.That(countAfterAdd, Is.EqualTo("2"), "Product count in cart should be 2 after adding products.");

                //Remove From Cart
                _addProductToCart.RemoveProducts();

                // Count the product that add to cart
                var countAfterRemove = _addProductToCart.GetCartCount();
                Assert.That(countAfterRemove, Is.EqualTo(""), "Product count in cart should be 0 after removing products.");

            

        }
    } 
}
