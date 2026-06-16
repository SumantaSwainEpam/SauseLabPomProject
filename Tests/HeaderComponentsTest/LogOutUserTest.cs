using SauseLabPomProject.Pages.HeaderComponents;

namespace SauseLabPomProject.Tests.HeaderComponentsTest
{
    public class LogOutUserTest : BaseClassTest
    {
        [Test]
        public async Task UserLogoutTest()
        {
            await Login("StandardUser");
            var logoutUser = GetPage<LogOutUser>();
            await logoutUser.LogOutCondition();
            var error = await logoutUser.GetErrorButtonWithWait();
            Assert.That(error.Text, Is.EqualTo("Epic sadface: You can only access '/checkout-step-one.html' when you are logged in."));
        }
    }
}
