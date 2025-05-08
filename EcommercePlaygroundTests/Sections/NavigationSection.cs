using EcommercePlaygroundTests.Models;
using OpenQA.Selenium;

namespace EcommercePlaygroundTests.Sections
{
    public class NavigationSection : BaseSection
    {
        public NavigationSection(IWebDriver driver) : base(driver)
        {
           
        }

        protected override By MainElementBy { get; set; } = By.XPath("//header[@class='header']");

        public IWebElement SearchInput => MainElement.FindElement(By.XPath(".//input[@name = 'search']"));

        public void Search(Product product)
        {
            SearchInput.Clear();
            SearchInput.SendKeys(product.Name + Keys.Enter);
        }
    }
}
