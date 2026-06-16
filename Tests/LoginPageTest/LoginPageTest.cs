using SauseLabPomProject.Pages;

namespace SauseLabPomProject.Tests
{
    public class LoginPageTest : BaseClassTest
    {
        [Test]
        [TestCase("StandardUser")]
        public async Task LoginPage_Test(string userType)
        {
            await Login(userType);
            var loginPage = GetPage<LoginPage>();
            var appLogo = await loginPage.GetAppLogoText();
            Assert.That(appLogo, Is.EqualTo("Swag Labs"));
        }

        [Test]
        [TestCase("LockedOutUser")]
        public async Task InValidLoginPage(string userType)
        {
            await Login(userType);
            var loginPage = GetPage<LoginPage>();
            var signIn = await loginPage.IsLoginButtonDisplayed();
            Assert.IsTrue(signIn, "The LogIn button is Available, that means User is unsuccessful to Sign In.");
        }
    }
}
