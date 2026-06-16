using SauseLabPomProject.Pages.ProductPage;

namespace SauseLabPomProject.Tests.ProductPageTest
{
    public class AddProductToCartTest : BaseClassTest
    {
        [Test]
        public async Task AddProductsToCartTest()
        {
            await Login("StandardUser");
            var addProductToCart = GetPage<AddProductToCart>();
            await addProductToCart.AddTheProduct();
            var cartCount = await addProductToCart.GetCartCount();
            Assert.That(cartCount, Is.EqualTo("2"), "Cart count did not match expected value.");
        }

        [Test]
        public async Task RemoveFromCartTest()
        {
            await Login("StandardUser");
            var addProductToCart = GetPage<AddProductToCart>();

            await addProductToCart.AddTheProduct();
            await addProductToCart.NavigateToCart();

            var countAfterAdd = await addProductToCart.GetCartCount();
            Assert.That(countAfterAdd, Is.EqualTo("2"), "Product count in cart should be 2 after adding products.");

            await addProductToCart.RemoveProducts();

            var countAfterRemove = await addProductToCart.GetCartCount();
            Assert.That(countAfterRemove, Is.EqualTo(""), "Product count in cart should be 0 after removing products.");
        }
    }
}
