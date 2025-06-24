using SauseLabPomProject.Pages.HeaderComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauseLabPomProject.Tests.HeaderComponentsTest
{
     public  class LogOutUserTest:BaseClassTest
    {
        [Test]

        public void userLogoutTest()
        {


            Login("StandardUser");
            var _logoutUser = GetPage<LogOutUser>();
            _logoutUser.LogOutCondition();
            var error = _logoutUser.GetErrorButtonWithWait();
            Assert.That(error.Text, Is.EqualTo("Epic sadface: You can only access '/checkout-step-one.html' when you are logged in."));
            


        }
    }
}
