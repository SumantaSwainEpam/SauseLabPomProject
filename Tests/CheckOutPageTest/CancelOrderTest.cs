using SauseLabPomProject.Pages.PaymentPage;

namespace SauseLabPomProject.Tests.PaymentPageTest
{
    public class CancelOrderTest : BaseClassTest
    {
        [Test]
        public async Task ShouldCancelOrderAndReturnToProductsPage()
        {
            await Login("StandardUser");
            var cancelOrder = GetPage<CancelOrder>();
            await cancelOrder.CompleteOrderCancellation("Sumanta", "Swain", "500081");
            var pageTitle = await cancelOrder.GetProductPageTitle();
            Assert.That(pageTitle, Is.EqualTo("Products"), "The page title should be 'Products' after cancelling the order.");
        }
    }
}
