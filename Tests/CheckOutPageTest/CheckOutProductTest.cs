using SauseLabPomProject.Pages.PaymentPage;

namespace SauseLabPomProject.Tests.PaymentPageTest
{
    public class CheckOutProductTest : BaseClassTest
    {
        [Test]
        public async Task CheckOutProductsTest()
        {
            await Login("StandardUser");
            var checkOutProduct = GetPage<CheckOutProduct>();
            await checkOutProduct.AddToCheckOut();
            var element = await checkOutProduct.GetCheckoutVerifyElement();
            Assert.That(element.Text, Is.EqualTo("Checkout: Your Information"));
        }
    }
}
