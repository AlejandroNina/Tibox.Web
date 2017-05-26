using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibox.Automation
{
    public class ProductPage
    {
        public static void Go()
        {
            Driver.Instance.Navigate().GoToUrl("http://localhost/Tibox.Angular/");
            Driver.Instance.FindElement(By.CssSelector("a[href='#!product']")).Click();
        }

        public static ProductCommand Create()
        {
            return new ProductCommand();
        }
    }

    public class ProductCommand
    {
        private string Id;
        private string ProductName;
        private string SupplierId;
        private string UnitPrice;
        private string Package;
        private string IsDiscontinued;

        public ProductCommand()
        {

        }

        public ProductCommand WithDataProduct(int Id, string ProductName, int SupplierId,
            decimal UnitPrice, string Package, bool IsDiscontinued)
        {
            this.Id = Id.ToString();
            this.ProductName = ProductName;
            this.SupplierId = SupplierId.ToString();
            this.UnitPrice = UnitPrice.ToString();
            this.Package = Package;
            this.IsDiscontinued = IsDiscontinued.ToString();
            return this;
        }

        public void Save()
        {
            Driver.Instance.FindElement(By.Id("Id")).Clear();
            Driver.Instance.FindElement(By.Id("Id")).SendKeys(Id);

            Driver.Instance.FindElement(By.Id("ProductName")).Clear();
            Driver.Instance.FindElement(By.Id("ProductName")).SendKeys(ProductName);

            Driver.Instance.FindElement(By.Id("SupplierId")).Clear();
            Driver.Instance.FindElement(By.Id("SupplierId")).SendKeys(SupplierId);

            Driver.Instance.FindElement(By.Id("UnitPrice")).Clear();
            Driver.Instance.FindElement(By.Id("UnitPrice")).SendKeys(UnitPrice);

            Driver.Instance.FindElement(By.Id("Package")).Clear();
            Driver.Instance.FindElement(By.Id("Package")).SendKeys(Package);

            Driver.Instance.FindElement(By.Id("IsDiscontinued")).Clear();
            Driver.Instance.FindElement(By.Id("IsDiscontinued")).SendKeys(IsDiscontinued);

            Driver.Instance.FindElement(By.CssSelector("button.btn.btn-save")).Click();
        }
    }
}
