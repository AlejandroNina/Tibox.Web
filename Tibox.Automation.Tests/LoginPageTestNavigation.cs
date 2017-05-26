using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tibox.Automation.Tests
{
    public class LoginPageTestNavigation
    {
        public LoginPageTestNavigation()
        {
            //Seleccionar el webBrowser:
            Driver.GetInstance(DriversOption.Chrome);
            // Driver.GetInstance(DriversOption.InternetExplorer);
        }

        [Fact]
        public void LoginTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("usuario").WithPassword("pass").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.GetUrl().Should().Be("http://localhost/Tibox.Angular/#!/product");
            LoginPage.Logout();
            Driver.CloseInstance(); //Al finalizar cierra todas las instancias.
        }

        [Fact]
        public void LoginWrongTest()
        {
            LoginPage.Go();
            LoginPage.LoginAs("juvega@gmail.com").WithPassword("87654321").Login();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            LoginPage.IsAlertErrorPresent().Should().BeTrue();
            Driver.CloseInstance(); //Al finalizar cierra todas las instancias.
        }

        public void Test()
        {
            // ProductPage.Go();
            // Product.Create().WithData("data del producto").Save();
        }
    }
}