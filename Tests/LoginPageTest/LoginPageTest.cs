
using SauseLabPomProject.Pages;
using SauseLabPomProject.Util;

namespace SauseLabPomProject.Tests
{
     public class LoginPageTest:BaseClassTest
    {

        [Test]
        [TestCase("StandardUser")]
        public void LoginPage_Test(string userType)
        {
          
                Login(userType);
                var loginPage=GetPage<LoginPage>();
                var AppLogo=loginPage.GetAppLogoText(); 
                Assert.That(AppLogo, Is.EqualTo("Swag Labs"));
                

        }

        [Test]
        [TestCase("LockedOutUser")]
        public void InValidLoginPage(string userType)
        {
         
                
                Login(userType);
                var loginPage = GetPage<LoginPage>();
                var SignIn = loginPage.isLoginButtonDisplayed();
                Assert.IsTrue(SignIn, "The LogIn button is Available ,That means User is Unsuccessfull to Sign In ");
               

        }



    }
}
