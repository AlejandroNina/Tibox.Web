using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tibox.Automation.Tests
{
    public class ProductPageTestNavigation
    {
        public ProductPageTestNavigation()
        {
            Driver.GetInstance(DriversOption.Chrome);
        }

        [Fact]
        public void ProductTest()
        {
            ProductPage.Go();
            ProductPage.Create().WithDataProduct(20, "Product1", 2, 160, "Coins", false).Save();
        }
    }
}
