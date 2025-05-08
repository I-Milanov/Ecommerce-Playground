using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url => "https://ecommerce-playground.lambdatest.io/index.php?route=product%2Fsearch";

        public override string DomTitle => "Search";

        public IWebElement SearchInput => Driver.GetElementWhenVisible(By.XPath($"//input[@id='input-search']"));

        public IWebElement SearchButton => Driver.GetElementWhenVisible(By.XPath($"//input[@id='button-search']"));

        public IWebElement ProductInGrid(Product product) => Driver.GetElementWhenVisible(By.XPath($"//div[@class='product-thumb' and .//a[contains(@href,'product_id={product.Id}')]]"));

        public IWebElement AddToShoppingCartButton(Product product) => ProductInGrid(product).FindElement(By.XPath(".//*[contains(concat(' ',normalize-space(@class),' '),' fa-shopping-cart ')]"));

        public IWebElement AddToCompareProductButton(Product product) => ProductInGrid(product).FindElement(By.XPath(".//*[contains(concat(' ',normalize-space(@class),' '),' fa-sync-alt ')]"));

        public void AddToCart(Product product)
        {
            ProductInGrid(product).HoverTo();
            AddToShoppingCartButton(product).Click();
        }

        public void AddToCompare(Product product)
        {
            ProductInGrid(product).HoverTo();
            AddToCompareProductButton(product).Click();
        }

        public void Search(Product product)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(product.Name);
            SearchButton.Click();
            Driver.WaitUntilReady();
        }
    }
}
