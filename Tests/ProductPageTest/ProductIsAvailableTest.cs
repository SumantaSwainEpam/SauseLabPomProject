using SauseLabPomProject.Pages.ProductPage;

namespace SauseLabPomProject.Tests.ProductPageTest
{
    public class ProductIsAvailableTest : BaseClassTest
    {
/// <summary>
/// [API Error: NotFound]
/// </summary>
        [Test]
        public async Task ShouldShowAvailableProduct()
        {
            await Login("StandardUser");
            var productAvl = GetPage<ProductIsAvailable>();
            bool isAvailable = await productAvl.CheckProductAvailable();
            Assert.IsTrue(isAvailable, "The Product should be available on the page.");
        }

        [Test]
        public async Task ProductIsNotAvailableTest()
        {
            await Login("StandardUser");
            var productAvl = GetPage<ProductIsAvailable>();
            bool isNotAvailable = await productAvl.CheckProductNotAvailable();
            Assert.IsTrue(isNotAvailable, "The Product should not be available on the page.");
        }
    }
}
