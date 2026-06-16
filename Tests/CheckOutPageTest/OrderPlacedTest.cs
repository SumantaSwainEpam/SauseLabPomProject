using SauseLabPomProject.Pages.PaymentPage;

namespace SauseLabPomProject.Tests.PaymentPageTest
{
    public class OrderPlacedTest : BaseClassTest
    {
        [Test]
        public async Task ShouldPlaceOrderSuccessfully()
        {
            await Login("StandardUser");
            var orderPlaced = GetPage<OrderPlaced>();
            await orderPlaced.AddProductsToCart();
            await orderPlaced.NavigateToCart();
            await orderPlaced.PlaceOrder();
            var verifyElement = await orderPlaced.GetProductPageTitle();
            Assert.That(verifyElement, Is.EqualTo("Thank you for your order!"));
        }
    }
}
