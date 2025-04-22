using EcommercePlaygroundTests.Extensions;
using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Sections
{
    public class NavigationSection : BaseSection
    {
        public NavigationSection(IWebDriver driver) : base(driver)
        {           
        }

        protected override By WrapperLocator { get; set; } = By.XPath("//header[@class='header']");

        public IWebElement SearchInput => Wrapper.FindElement(By.XPath(".//input[@name = 'search']"));

        public IWebElement CompareButton => Wrapper.FindElement(By.XPath(".//a[@aria-label='Compare']"));

        public IWebElement CartButton => Wrapper.FindElement(By.XPath(".//div[@class='cart-icon']"));


        public void Search(Product product)
        {
            SearchInput.SendKeys(product.Name + Keys.Enter);
        }

        public void ClickOnCompareButton()
        {
            CompareButton.Click();
            Driver.WaitUntilReady();
        }

        public void ClickOnCartButton()
        {
            CartButton.Click();
            Driver.WaitUntilReady();
        }
    }
}
