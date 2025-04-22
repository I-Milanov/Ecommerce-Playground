using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class SearchPage : BaseSection
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch";

        public override string DomTitle => "Search";

        public IWebElement ProductInGrid(Product product) =>
            Driver.GetElementWhenVisible(By.XPath($"//div[@class='product-thumb' and .//a[contains(@href,'product_id={product.Id}')]]"));

        public IWebElement ShoppingCart(Product product) => 
            ProductInGrid(product).FindElement(By.XPath(".//*[contains(concat(' ',normalize-space(@class),' '),' fa-shopping-cart ')]"));

        public void AddProductToCart(Product product)
        {
            ProductInGrid(product).HoverTo();
            ShoppingCart(product).Click();
        }
    }
}
