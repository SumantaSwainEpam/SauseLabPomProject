using SauseLabPomProject.Pages.HeaderComponents;

namespace SauseLabPomProject.Tests.HeaderComponentsTest
{
    [TestFixture]
    public class FilterProductsTest : BaseClassTest
    {
        [Test]
        public async Task FilterOnProductsTest()
        {
            await Login("StandardUser");
            var filter = GetPage<FilterProducts>();
            await filter.ApplyFilter();
            var product1 = await filter.GetProduct1();
            var product2 = await filter.GetProduct2();
            Assert.That(product1.Text, Is.EqualTo("Test.allTheThings() T-Shirt (Red)"));
            Assert.That(product2.Text, Is.EqualTo("Sauce Labs Onesie"));
        }
    }
}
